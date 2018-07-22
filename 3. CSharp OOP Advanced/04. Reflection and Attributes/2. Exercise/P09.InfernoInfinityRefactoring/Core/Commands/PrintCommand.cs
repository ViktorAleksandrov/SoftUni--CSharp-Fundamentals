using P09.InfernoInfinityRefactoring.Attributes;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public PrintCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];

            this.repository.Print(weaponName);
        }
    }
}
