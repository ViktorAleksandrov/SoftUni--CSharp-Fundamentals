using P04.BarrackWarsTheCommandsStrikeBack.Contracts;
using P04.BarrackWarsTheCommandsStrikeBack.Core;
using P04.BarrackWarsTheCommandsStrikeBack.Core.Factories;
using P04.BarrackWarsTheCommandsStrikeBack.Data;

namespace P04.BarrackWarsTheCommandsStrikeBack
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
