using P05.BarrackWarsReturnOfTheDependencies.Attributes;
using P05.BarrackWarsReturnOfTheDependencies.Contracts;

namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);

            this.repository.AddUnit(unitToAdd);

            string output = unitType + " added!";

            return output;
        }
    }
}
