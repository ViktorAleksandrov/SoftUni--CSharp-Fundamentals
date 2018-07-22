using System.Linq;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core
{
    public class Engine : IRunnable
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "END")
            {
                string[] data = input.Split(';');
                string commandName = data[0];
                data = data.Skip(1).ToArray();

                IExecutable result = this.commandInterpreter.InterpretCommand(data, commandName);

                result.Execute();
            }
        }
    }
}
