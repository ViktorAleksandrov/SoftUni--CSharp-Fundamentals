using System;
using Microsoft.Extensions.DependencyInjection;
using P09.InfernoInfinityRefactoring.Contracts;
using P09.InfernoInfinityRefactoring.Core;
using P09.InfernoInfinityRefactoring.Data;
using P09.InfernoInfinityRefactoring.Factories;
using P09.InfernoInfinityRefactoring.IO;

namespace P09.InfernoInfinityRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IReader reader = new Reader();

            IRunnable engine = new Engine(commandInterpreter, reader);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddSingleton<IRepository, Repository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
