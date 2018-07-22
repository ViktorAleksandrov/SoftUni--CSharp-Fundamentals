namespace P1.OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                var lineCounter = 0;

                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (lineCounter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    lineCounter++;
                }
            }
        }
    }
}