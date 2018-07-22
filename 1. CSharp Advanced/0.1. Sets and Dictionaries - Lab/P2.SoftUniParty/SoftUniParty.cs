namespace P2.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class SoftUniParty
    {
        public static void Main()
        {
            var guests = new SortedSet<string>();

            while (true)
            {
                var guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }

                guests.Add(guest);
            }

            while (true)
            {
                var guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }

                guests.Remove(guest);
            }

            Console.WriteLine(guests.Count);

            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}