namespace AdventOfCode.Year2015.Day08
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public partial class Part1
    {
        [GeneratedRegex("\\\\x[a-f0-9]{2}")]
        private partial Regex FindHexadecimalNotation();

        public int CalculateDifferenceBetweenStrings(IEnumerable<string> inputs)
        {
            int countLiteral = 0;
            int countMemory = 0;

            foreach (string i in inputs)
            {
                countLiteral += CountLiteral(i);
                countMemory += CountMemory(i);
            }

            return countLiteral - countMemory;
        }

        private int CountLiteral(string input)
        {
            return input.Length;
        }

        private int CountMemory(string input)
        {
            input = input.Trim('"');
            input = input.Replace("\\\"", "-");
            input = input.Replace("\\\\", "-");
            input = FindHexadecimalNotation().Replace(input, "-");

            return input.Length;
        }
    }
}