namespace AdventOfCode.Year2015.Day08
{
    using System.Collections.Generic;

    public partial class Part2
    {
        public int CalculateDifferenceBetweenStrings(IEnumerable<string> inputs)
        {
            int countLiteral = 0;
            int countMemory = 0;

            foreach (string i in inputs)
            {
                countLiteral += CountLiteral(i);
                countMemory += CountMemory(i);
            }

            return countMemory - countLiteral;
        }

        private int CountLiteral(string input)
        {
            return input.Length;
        }

        private int CountMemory(string input)
        {
            input = input.Replace("\\", "--");
            input = input.Replace("\"", "--");

            return input.Length + 2;
        }
    }
}