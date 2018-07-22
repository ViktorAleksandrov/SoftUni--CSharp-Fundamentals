namespace P09.InfernoInfinityRefactoring.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string gemType, string clarityType);
    }
}
