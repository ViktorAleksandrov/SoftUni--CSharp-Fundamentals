using System;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
