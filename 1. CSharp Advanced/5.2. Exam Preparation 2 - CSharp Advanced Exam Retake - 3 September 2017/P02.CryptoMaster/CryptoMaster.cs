namespace P02.CryptoMaster
{
    using System;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var length = numbers.Length;

            var maxSequence = 1;

            for (int index = 0; index < length; index++)
            {
                for (int step = 1; step < length; step++)
                {
                    var currentIndex = index;
                    var nextIndex = (currentIndex + step) % length;

                    var currentSequence = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % length;

                        currentSequence++;
                    }

                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}