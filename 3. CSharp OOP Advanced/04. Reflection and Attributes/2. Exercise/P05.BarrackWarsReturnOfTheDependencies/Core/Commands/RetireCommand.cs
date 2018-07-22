using P05.BarrackWarsReturnOfTheDependencies.Attributes;
using P05.BarrackWarsReturnOfTheDependencies.Contracts;

namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            this.repository.RemoveUnit(unitType);

            string output = unitType + " retired!";

            return output;
        }
    }
}
