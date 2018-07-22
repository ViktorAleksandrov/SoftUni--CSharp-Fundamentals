namespace P04.BarrackWarsTheCommandsStrikeBack.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
