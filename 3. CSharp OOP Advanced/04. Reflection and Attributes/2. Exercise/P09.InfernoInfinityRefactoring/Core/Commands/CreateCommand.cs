using P09.InfernoInfinityRefactoring.Attributes;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IWeaponFactory weaponFactory;

        public CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory)
            : base(data)
        {
            this.repository = repository;
            this.weaponFactory = weaponFactory;
        }

        public override void Execute()
        {
            string[] weaponArgs = this.Data[0].Split();

            string rarityType = weaponArgs[0];
            string weaponType = weaponArgs[1];

            string weaponName = this.Data[1];

            IWeapon weapon = this.weaponFactory.CreateWeapon(weaponType, weaponName, rarityType);

            this.repository.CreateWeapon(weapon);
        }
    }
}
