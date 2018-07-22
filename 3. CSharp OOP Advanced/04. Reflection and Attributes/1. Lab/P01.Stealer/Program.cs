using System;

namespace P01.Stealer
{
    class Program
    {
        public static void Main()
        {
            var spy = new Spy();

            string result = spy.StealFieldInfo("Hacker", "username", "password");

            Console.WriteLine(result);
        }
    }
}
