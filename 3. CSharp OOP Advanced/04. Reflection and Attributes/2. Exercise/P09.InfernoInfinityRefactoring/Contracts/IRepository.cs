namespace P09.InfernoInfinityRefactoring.Contracts
{
    public interface IRepository
    {
        void CreateWeapon(IWeapon weapon);

        void Add(string weaponName, int socketIndex, IGem gem);

        void Remove(string weaponName, int socketIndex);

        void Print(string weaponName);
    }
}
