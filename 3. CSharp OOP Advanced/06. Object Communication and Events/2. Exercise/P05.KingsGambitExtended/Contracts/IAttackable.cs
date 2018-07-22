namespace P05.KingsGambitExtended.Contracts
{
    public delegate void BeingAttackedEventHandler();

    public interface IAttackable
    {
        event BeingAttackedEventHandler BeingAttacked;

        void GetAttacked();
    }
}