using System;

namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return null;
        }
    }
}
