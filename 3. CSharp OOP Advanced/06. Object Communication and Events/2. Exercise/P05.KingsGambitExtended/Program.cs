using System;
using P05.KingsGambitExtended.Contracts;
using P05.KingsGambitExtended.Models;

namespace P05.KingsGambitExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            IKing king = SetUpKing();

            var engine = new Engine(king);
            engine.Run();
        }

        private static IKing SetUpKing()
        {
            string kingName = Console.ReadLine();

            IKing king = new King(kingName);

            string[] royalGuardsNames = Console.ReadLine().Split();

            foreach (string name in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(name);

                king.AddSubordinate(royalGuard);
            }

            string[] footmenNames = Console.ReadLine().Split();

            foreach (string name in footmenNames)
            {
                var footman = new Footman(name);

                king.AddSubordinate(footman);
            }

            return king;
        }
    }
}
