namespace P11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var trainers = new List<Trainer>();

            AddTrainers(trainers);

            ProcessTrainers(trainers);

            PrintTrainersInfo(trainers);
        }

        private static void AddTrainers(List<Trainer> trainers)
        {
            while (true)
            {
                var inputTokens = Console.ReadLine().Split();

                var trainerName = inputTokens[0];

                if (trainerName == "Tournament")
                {
                    break;
                }

                var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);

                    trainers.Add(trainer);
                }

                var pokemonName = inputTokens[1];
                var element = inputTokens[2];
                var health = int.Parse(inputTokens[3]);

                var pokemon = new Pokemon(pokemonName, element, health);

                trainer.Pokemons.Add(pokemon);
            }
        }

        private static void ProcessTrainers(List<Trainer> trainers)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.BadgesAmount++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);

                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }
        }

        private static void PrintTrainersInfo(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(t => t.BadgesAmount))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}