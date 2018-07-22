namespace DungeonsAndCodeWizards.Controllers
{
    using System;
    using System.Linq;

    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (!this.dungeonMaster.IsGameOver())
            {
                string inputLine = Console.ReadLine();

                if (string.IsNullOrEmpty(inputLine))
                {
                    break;
                }

                string[] commandArgs = inputLine.Split();

                string command = commandArgs[0];

                string[] args = commandArgs.Skip(1).ToArray();

                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            output = this.dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            output = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            output = this.dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            output = this.dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            output = this.dungeonMaster.UseItemOn(args);
                            break;
                        case "GiveCharacterItem":
                            output = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            output = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            output = this.dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            output = this.dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            output = this.dungeonMaster.EndTurn(args);
                            break;
                    }

                    if (output != string.Empty)
                    {
                        Console.WriteLine(output);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}