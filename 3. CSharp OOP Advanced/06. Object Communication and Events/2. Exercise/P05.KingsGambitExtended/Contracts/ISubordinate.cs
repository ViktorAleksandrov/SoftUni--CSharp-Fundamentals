namespace P05.KingsGambitExtended.Contracts
{
    public delegate void DiedEventHandler(ISubordinate subordinate);

    public interface ISubordinate : INamable
    {
        event DiedEventHandler Died;

        string Action { get; }

        int Health { get; }

        void TakeHit();

        void OnKingBeingAttacked();
    }
}
