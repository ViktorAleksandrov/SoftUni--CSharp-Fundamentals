using P05.BarrackWarsReturnOfTheDependencies.Attributes;
using P05.BarrackWarsReturnOfTheDependencies.Contracts;

namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;

            return output;
        }
    }
}
