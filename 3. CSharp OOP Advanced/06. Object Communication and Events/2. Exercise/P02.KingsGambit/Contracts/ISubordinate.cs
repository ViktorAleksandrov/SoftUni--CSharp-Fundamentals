namespace P02.KingsGambit.Contracts
{
    public interface ISubordinate : INamable
    {
        string Action { get; }

        void OnKingBeingAttacked();
    }
}
