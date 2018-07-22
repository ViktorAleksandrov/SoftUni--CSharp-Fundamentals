namespace P06.Animals
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            var animals = new List<Animal>();

            while (true)
            {
                var animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                try
                {
                    CreateAnimal(animals, animalType);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintAnimals(animals);
        }

        private static void CreateAnimal(List<Animal> animals, string animalType)
        {
            var animalInfo = Console.ReadLine().Split();

            var name = animalInfo[0];
            var age = int.Parse(animalInfo[1]);
            var gender = string.Empty;

            if (animalInfo.Length == 3)
            {
                gender = animalInfo[2];
            }

            switch (animalType)
            {
                case "Dog":
                    animals.Add(new Dog(name, age, gender));
                    break;
                case "Cat":
                    animals.Add(new Cat(name, age, gender));
                    break;
                case "Frog":
                    animals.Add(new Frog(name, age, gender));
                    break;
                case "Tomcat":
                    animals.Add(new Tomcat(name, age));
                    break;
                case "Kitten":
                    animals.Add(new Kitten(name, age));
                    break;
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            animals.ForEach(Console.WriteLine);
        }
    }
}