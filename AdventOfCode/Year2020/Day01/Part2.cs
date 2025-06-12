namespace AdventOfCode.Year2020.Day01
{
    using System.Collections.Generic;

    public class Part2
    {
        public int FindProductOfTwoValues(IEnumerable<string> inputs, int sumToFind)
        {
            var numbers = new List<int>();
            foreach (string input in inputs)
            {
                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == sumToFind)
                        {
                            return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}