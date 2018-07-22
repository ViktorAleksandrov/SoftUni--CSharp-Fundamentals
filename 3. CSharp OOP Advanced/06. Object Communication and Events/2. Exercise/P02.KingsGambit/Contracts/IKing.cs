namespace P02.KingsGambit.Contracts
{
    public interface IKing : INamable, IAttackable
    {
        void AddSubordinate(ISubordinate subordinate);

        void SubordinateDies(string subordinateName);
    }
}
