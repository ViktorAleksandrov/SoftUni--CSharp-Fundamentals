using System;
using Microsoft.Extensions.DependencyInjection;
using P05.BarrackWarsReturnOfTheDependencies.Contracts;
using P05.BarrackWarsReturnOfTheDependencies.Core;
using P05.BarrackWarsReturnOfTheDependencies.Core.Factories;
using P05.BarrackWarsReturnOfTheDependencies.Data;

namespace P05.BarrackWarsReturnOfTheDependencies
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandIntrepreter(serviceProvider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
