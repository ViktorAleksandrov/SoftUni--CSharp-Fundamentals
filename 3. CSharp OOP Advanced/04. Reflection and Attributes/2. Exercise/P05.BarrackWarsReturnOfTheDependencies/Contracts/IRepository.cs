namespace P05.BarrackWarsReturnOfTheDependencies.Contracts
{
    public interface IRepository
    {
        void AddUnit(IUnit unit);
        string Statistics { get; }
        void RemoveUnit(string unitType);
    }
}
