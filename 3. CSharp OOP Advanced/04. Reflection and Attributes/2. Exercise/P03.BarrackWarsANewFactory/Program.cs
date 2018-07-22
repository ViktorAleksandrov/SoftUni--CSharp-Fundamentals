using P03.BarrackWarsANewFactory.Contracts;
using P03.BarrackWarsANewFactory.Core;
using P03.BarrackWarsANewFactory.Core.Factories;
using P03.BarrackWarsANewFactory.Data;

namespace P03.BarrackWarsANewFactory
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
