namespace P02.KingsGambit.Contracts
{
    public delegate void BeingAttackedEventHandler();

    public interface IAttackable
    {
        event BeingAttackedEventHandler BeingAttacked;

        void GetAttacked();
    }
}