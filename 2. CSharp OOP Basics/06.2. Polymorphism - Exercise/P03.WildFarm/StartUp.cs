namespace P03.WildFarm
{
    using Models.Animals;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            string inputLine;

            var animals = new List<Animal>();

            while ((inputLine = Console.ReadLine()) != "End")
            {
                Animal animal = CreateAnimal(inputLine);
                Food food = CreateFood();

                animal.ProduceSound();

                TryFeedAnimal(animal, food);

                animals.Add(animal);
            }

            PrintAnimals(animals);
        }

        private static Animal CreateAnimal(string inputLine)
        {
            string[] animalInfo = inputLine.Split();

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            string livingRegion = animalInfo[3];
            string breed = animalInfo.Length == 5 ? animalInfo[4] : null;
            double wingSize;

            switch (type)
            {
                case "Cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    return new Tiger(name, weight, livingRegion, breed);
                case "Owl":
                    wingSize = double.Parse(animalInfo[3]);
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    wingSize = double.Parse(animalInfo[3]);
                    return new Hen(name, weight, wingSize);
                case "Mouse":
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    return new Dog(name, weight, livingRegion);
                default:
                    return null;
            }
        }

        private static Food CreateFood()
        {
            string[] foodInfo = Console.ReadLine().Split();

            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    return null;
            }
        }

        private static void TryFeedAnimal(Animal animal, Food food)
        {
            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            animals.ForEach(Console.WriteLine);
        }
    }
}