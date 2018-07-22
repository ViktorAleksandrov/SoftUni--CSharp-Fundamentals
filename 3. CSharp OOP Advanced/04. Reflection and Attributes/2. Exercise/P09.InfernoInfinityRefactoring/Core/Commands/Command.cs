using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core.Commands
{
    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract void Execute();
    }
}
