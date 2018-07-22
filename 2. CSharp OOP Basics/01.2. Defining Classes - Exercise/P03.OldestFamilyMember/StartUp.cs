namespace P03.OldestFamilyMember
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var membersCount = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                var memberArgs = Console.ReadLine().Split();

                var name = memberArgs[0];
                var age = int.Parse(memberArgs[1]);

                var member = new Person(name, age);

                family.AddMember(member);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}