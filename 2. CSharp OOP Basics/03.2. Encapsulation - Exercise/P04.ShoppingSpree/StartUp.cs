namespace P04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            try
            {
                List<Person> persons = AddPersons();

                List<Product> products = AddProducts();

                BuyProducts(persons, products);

                PrintOutput(persons);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }

        }

        private static List<Person> AddPersons()
        {
            var persons = new List<Person>();

            var personsInfo = Console.ReadLine()
                .Split(";=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (var index = 0; index < personsInfo.Length; index += 2)
            {
                var name = personsInfo[index];
                var money = decimal.Parse(personsInfo[index + 1]);

                var person = new Person(name, money);

                persons.Add(person);
            }

            return persons;
        }

        private static List<Product> AddProducts()
        {
            var products = new List<Product>();

            var productsInfo = Console.ReadLine()
                .Split(";=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (var index = 0; index < productsInfo.Length; index += 2)
            {
                var name = productsInfo[index];
                var cost = decimal.Parse(productsInfo[index + 1]);

                var product = new Product(name, cost);

                products.Add(product);
            }

            return products;
        }

        private static void BuyProducts(List<Person> persons, List<Product> products)
        {
            while (true)
            {
                string[] purchaseInfo = Console.ReadLine().Split();

                string personName = purchaseInfo[0];

                if (personName == "END")
                {
                    break;
                }

                string productName = purchaseInfo[1];

                Person person = persons.First(p => p.Name == personName);
                Product product = products.First(p => p.Name == productName);

                person.TryBuyProduct(product);
            }
        }

        private static void PrintOutput(List<Person> persons)
        {
            persons.ForEach(Console.WriteLine);
        }
    }
}