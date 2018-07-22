using System;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
