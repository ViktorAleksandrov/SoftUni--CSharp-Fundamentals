namespace P3.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            var wordsOccurences = new Dictionary<string, int>();

            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    wordsOccurences[word] = 0;
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                var wordsArr = reader.ReadToEnd()
                    .ToLower()
                    .Split(" -,.?!\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsArr)
                {
                    if (wordsOccurences.ContainsKey(word))
                    {
                        wordsOccurences[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var pair in wordsOccurences.OrderByDescending(kvp => kvp.Value))
                {
                    var word = pair.Key;
                    var count = pair.Value;

                    writer.WriteLine($"{word} - {count}");
                }
            }
        }
    }
}