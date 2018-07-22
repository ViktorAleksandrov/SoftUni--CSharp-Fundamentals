using System;
using P05.KingsGambitExtended.Contracts;

namespace P05.KingsGambitExtended
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
                        ISubordinate subordinate = this.king.GetSubordinate(subordinateName);
                        subordinate.TakeHit();
                        break;
                }
            }
        }
    }
}
