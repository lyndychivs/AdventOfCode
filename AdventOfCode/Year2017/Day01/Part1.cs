namespace AdventOfCode.Year2017.Day01
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int SolveCaptcha(string input)
        {
            var matchingNumbers = new List<int>();

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == input[(index + 1) % input.Length])
                {
                    matchingNumbers.Add(int.Parse(input[index].ToString()));
                }
            }

            return matchingNumbers.Sum();
        }
    }
}