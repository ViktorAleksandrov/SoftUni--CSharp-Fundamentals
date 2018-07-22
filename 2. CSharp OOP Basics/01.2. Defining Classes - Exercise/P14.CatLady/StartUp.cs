namespace P14.CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var cats = new List<Cat>();

            while (true)
            {
                var catInfo = Console.ReadLine().Split();

                var breed = catInfo[0];

                if (breed == "End")
                {
                    break;
                }

                var name = catInfo[1];
                var characteristic = catInfo[2];

                switch (breed)
                {
                    case "Siamese":
                        cats.Add(new Siamese(name, characteristic));
                        break;
                    case "Cymric":
                        cats.Add(new Cymric(name, characteristic));
                        break;
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(name, characteristic));
                        break;
                }
            }

            var catName = Console.ReadLine();

            var cat = cats.First(c => c.Name == catName);

            Console.WriteLine(cat);
        }
    }
}