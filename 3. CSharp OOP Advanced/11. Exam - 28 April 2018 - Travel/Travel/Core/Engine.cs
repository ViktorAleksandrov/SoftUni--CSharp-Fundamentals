namespace Travel.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAirportController airportController;
        private readonly IFlightController flightController;

        public Engine(
            IReader reader, IWriter writer, IAirportController airportController, IFlightController flightController)
        {
            this.reader = reader;
            this.writer = writer;
            this.airportController = airportController;
            this.flightController = flightController;
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
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split();

            string command = tokens.First();

            string[] args = tokens.Skip(1).ToArray();

            switch (command)
            {
                case "RegisterPassenger":
                    {
                        string name = args[0];

                        string output = this.airportController.RegisterPassenger(name);

                        return output;
                    }
                case "RegisterTrip":
                    {
                        string source = args[0];
                        string destination = args[1];
                        string planeType = args[2];

                        string output = this.airportController.RegisterTrip(source, destination, planeType);

                        return output;
                    }
                case "RegisterBag":
                    {
                        string username = args[0];
                        IEnumerable<string> bagItems = args.Skip(1);

                        string output = this.airportController.RegisterBag(username, bagItems);

                        return output;
                    }
                case "CheckIn":
                    {
                        string username = args[0];
                        string tripId = args[1];
                        IEnumerable<int> bagCheckInIndices = args.Skip(2).Select(int.Parse);

                        string output = this.airportController.CheckIn(username, tripId, bagCheckInIndices);

                        return output;
                    }
                case "TakeOff":
                    {
                        string output = this.flightController.TakeOff();

                        return output;
                    }
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }
    }
}