namespace P05.KingsGambitExtended.Contracts
{
    public interface IKing : INamable, IAttackable
    {
        void AddSubordinate(ISubordinate subordinate);

        ISubordinate GetSubordinate(string subordinateName);
    }
}
