namespace P03.CryptoBlockchain
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CryptoBlockchain
    {
        public static void Main()
        {
            var regex = new Regex(@"((?<bracket>{)|\[)\D*(?<digits>\d{3,})\D*(?(bracket)}|])");

            var matches = GetRegexMatches(regex);

            var text = DecryptBlockchain(matches);

            Console.WriteLine(text);
        }

        private static MatchCollection GetRegexMatches(Regex regex)
        {
            var linesNumber = int.Parse(Console.ReadLine());

            var blockchain = new StringBuilder();

            for (int line = 0; line < linesNumber; line++)
            {
                blockchain.Append(Console.ReadLine());
            }

            return regex.Matches(blockchain.ToString());
        }

        private static StringBuilder DecryptBlockchain(MatchCollection matches)
        {
            var text = new StringBuilder();

            foreach (Match match in matches)
            {
                var digitsLength = match.Groups["digits"].Length;

                if (digitsLength % 3 != 0)
                {
                    continue;
                }

                var digits = match.Groups["digits"].Value;

                var blockLength = match.Length;

                for (int index = 0; index < digitsLength; index += 3)
                {
                    var strNumber = digits.Substring(index, 3);

                    var number = int.Parse(strNumber) - blockLength;

                    text.Append((char)number);
                }
            }

            return text;
        }
    }
}