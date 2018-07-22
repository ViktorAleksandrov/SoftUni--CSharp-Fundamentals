using P09.InfernoInfinityRefactoring.Attributes;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IGemFactory gemFactory;

        public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory)
            : base(data)
        {
            this.repository = repository;
            this.gemFactory = gemFactory;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];
            int socketIndex = int.Parse(this.Data[1]);

            string[] gemArgs = this.Data[2].Split();
            string clarityType = gemArgs[0];
            string gemType = gemArgs[1];

            IGem gemToAdd = this.gemFactory.CreateGem(gemType, clarityType);

            this.repository.Add(weaponName, socketIndex, gemToAdd);
        }
    }
}
