using System;

namespace P04.Collector
{
    class Program
    {
        public static void Main()
        {
            var spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
