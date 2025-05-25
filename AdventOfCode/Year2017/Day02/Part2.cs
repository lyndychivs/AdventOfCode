namespace AdventOfCode.Year2017.Day02
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
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
            string[] numbersAsString = input.Split('\t');
            var numbers = new List<int>();
            
            foreach (string numberAsString in numbersAsString)
            {
                int parsedNumber = int.Parse(numberAsString.Trim());
                numbers.Add(parsedNumber);
            }

            var numbersOrdered = numbers.OrderBy(n => n).ToList();

            for (int lastIndex = numbersOrdered.Count - 1; lastIndex >= 0; lastIndex--)
            {
                for (int firstIndex = 0; firstIndex < numbersOrdered.Count; firstIndex++)
                {
                    if (numbersOrdered[lastIndex] == numbersOrdered[firstIndex])
                    {
                        continue;
                    }

                    if (numbersOrdered[lastIndex] % numbersOrdered[firstIndex] == 0)
                    {
                        return numbersOrdered[lastIndex] / numbersOrdered[firstIndex];
                    }
                }
            }

            return 0;
        }
    }
}