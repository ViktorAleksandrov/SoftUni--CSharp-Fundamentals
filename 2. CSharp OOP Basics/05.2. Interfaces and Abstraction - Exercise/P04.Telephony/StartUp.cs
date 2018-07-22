namespace P04.Telephony
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var smartphone = new Smartphone();

            var phoneNumbers = Console.ReadLine().Split();

            foreach (var number in phoneNumbers)
            {
                smartphone.Call(number);
            }

            var websites = Console.ReadLine().Split();

            foreach (var site in websites)
            {
                smartphone.Browse(site);
            }
        }
    }
}