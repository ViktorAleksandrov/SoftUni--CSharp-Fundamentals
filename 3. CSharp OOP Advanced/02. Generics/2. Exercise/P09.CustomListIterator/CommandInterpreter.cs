using System;

namespace P09.CustomListIterator
{
    public class CommandInterpreter
    {
        private readonly CustomList<string> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<string>();
        }

        public void ParseCommands()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] commandArgs = inputLine.Split();

                string command = commandArgs[0];

                switch (command)
                {
                    case "Add":
                        this.customList.Add(commandArgs[1]);
                        break;
                    case "Remove":
                        int index = int.Parse(commandArgs[1]);
                        this.customList.Remove(index);
                        break;
                    case "Contains":
                        Console.WriteLine(this.customList.Contains(commandArgs[1]));
                        break;
                    case "Swap":
                        int firstIndex = int.Parse(commandArgs[1]);
                        int secondIndex = int.Parse(commandArgs[2]);
                        this.customList.Swap(firstIndex, secondIndex);
                        break;
                    case "Greater":
                        int count = this.customList.CountGreaterThan(commandArgs[1]);
                        Console.WriteLine(count);
                        break;
                    case "Max":
                        Console.WriteLine(this.customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(this.customList.Min());
                        break;
                    case "Print":
                        this.customList.Print();
                        break;
                    case "Sort":
                        this.customList.Sort();
                        break;
                }
            }
        }
    }
}