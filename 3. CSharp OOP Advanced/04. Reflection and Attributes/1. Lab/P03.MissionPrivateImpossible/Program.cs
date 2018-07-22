using System;

namespace P03.MissionPrivateImpossible
{
    class Program
    {
        public static void Main()
        {
            var spy = new Spy();

            string result = spy.RevealPrivateMethods("Hacker");

            Console.WriteLine(result);
        }
    }
}
