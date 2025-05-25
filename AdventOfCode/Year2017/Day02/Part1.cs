namespace AdventOfCode.Year2017.Day02
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int GetCheckSum(IEnumerable<string> inputs)
        {
            var results = new List<int>();
            foreach (string input in inputs)
            {
                results.Add(GetDiff(input));
            }

            return results.Sum();
        }

        private int GetDiff(string input)
        {
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            foreach (string number in input.Split('\t'))
            {
                int parsedNumber = int.Parse(number.Trim());

                if (parsedNumber > maxNumber)
                {
                    maxNumber = parsedNumber;
                }

                if (parsedNumber < minNumber)
                {
                    minNumber = parsedNumber;
                }
            }

            return maxNumber - minNumber;
        }
    }
}