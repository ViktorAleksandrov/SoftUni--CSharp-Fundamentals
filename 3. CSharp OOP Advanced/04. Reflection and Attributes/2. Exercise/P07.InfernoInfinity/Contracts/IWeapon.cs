namespace P07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        void AddGem(IGem gem, int socketIndex);

        void RemoveGem(int socketIndex);
    }
}
