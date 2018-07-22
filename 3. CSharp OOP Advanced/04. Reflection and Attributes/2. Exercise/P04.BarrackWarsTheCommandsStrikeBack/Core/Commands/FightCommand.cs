using System;
using P04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace P04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return null;
        }
    }
}
