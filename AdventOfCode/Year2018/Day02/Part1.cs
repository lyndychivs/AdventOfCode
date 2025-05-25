namespace AdventOfCode.Year2018.Day02
{
    using System.Collections.Generic;

    public class Part1
    {
        public int GetChecksumForListOfBoxIds(IEnumerable<string> inputs)
        {
            int twiceCount = 0;
            int thriceCount = 0;

            foreach (string input in inputs)
            {
                if (HasNthOccurrences(input, 2))
                {
                    twiceCount++;
                }

                if (HasNthOccurrences(input, 3))
                {
                    thriceCount++;
                }
            }

            return twiceCount * thriceCount;
        }

        private bool HasNthOccurrences(string input, int n)
        {
            var charCount = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (charCount.TryGetValue(c, out int value))
                {
                    charCount[c] = ++value;

                    continue;
                }

                charCount.Add(c, 1);
            }

            foreach (int count in charCount.Values)
            {
                if (count == n)
                {
                    return true;
                }
            }

            return false;
        }
    }
}