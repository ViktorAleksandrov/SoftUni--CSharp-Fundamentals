using P04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace P04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;

            return output;
        }
    }
}
