using System;
using P02.KingsGambit.Contracts;

namespace P02.KingsGambit
{
    public class Engine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] commandArgs = inputLine.Split();

                string command = commandArgs[0];

                switch (command)
                {
                    case "Attack":
                        this.king.GetAttacked();
                        break;
                    case "Kill":
                        string subordinateName = commandArgs[1];
                        this.king.SubordinateDies(subordinateName);
                        break;
                }
            }
        }
    }
}
