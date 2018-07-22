namespace P05.BarrackWarsReturnOfTheDependencies.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
