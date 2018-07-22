namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string report = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(report);
        }

        public string ProcessCommand(string input)
        {
            string[] inputTokens = input.Split();

            string commandName = inputTokens.First();

            string[] args = inputTokens.Skip(1).ToArray();

            if (commandName == "LetsRock")
            {
                string setResult = this.setCоntroller.PerformSets();
                return setResult;
            }

            MethodInfo commandMethod = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == commandName);

            string output;

            try
            {
                output = (string)commandMethod.Invoke(this.festivalCоntroller, new object[] { args });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return output;
        }
    }
}