using System;

namespace P02.HighQualityMistakes
{
    class Program
    {
        public static void Main()
        {
            var spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
