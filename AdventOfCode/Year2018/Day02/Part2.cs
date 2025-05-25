namespace AdventOfCode.Year2018.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public string GetCommonLettersBetweenTwoCorrectBoxIds(IEnumerable<string> inputs)
        {
            int maxDifferences = int.MaxValue;
            string result = string.Empty;

            for (int baseIndex = 0; baseIndex < inputs.Count(); baseIndex++)
            {
                string baseInput = inputs.ElementAt(baseIndex);

                for (int compareIndex = 0; compareIndex < inputs.Count(); compareIndex++)
                {
                    var sameChars = new List<char>();

                    if (baseIndex == compareIndex)
                    {
                        continue;
                    }

                    string comparisonInput = inputs.ElementAt(compareIndex);

                    if (baseInput.Length != comparisonInput.Length)
                    {
                        continue;
                    }

                    int differencesCount = 0;
                    for (int charIndex = 0; charIndex < baseInput.Length; charIndex++)
                    {
                        if (baseInput[charIndex] != comparisonInput[charIndex])
                        {
                            differencesCount++;

                            continue;
                        }

                        sameChars.Add(baseInput[charIndex]);
                    }

                    if (differencesCount < maxDifferences)
                    {
                        maxDifferences = differencesCount;
                        result = new string([.. sameChars]);
                    }
                }
            }

            return result;
        }
    }
}