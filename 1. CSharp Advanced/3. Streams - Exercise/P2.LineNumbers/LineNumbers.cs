namespace P2.LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    var lineCounter = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {lineCounter}: {line}");

                        lineCounter++;
                    }
                }
            }
        }
    }
}