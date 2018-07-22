namespace P09.InfernoInfinityRefactoring.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string weaponName, string rarityType);
    }
}
