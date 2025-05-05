namespace AdventOfCode.Year2015.Day05
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        private readonly List<char> _vowels = ['a', 'e', 'i', 'o', 'u'];

        private readonly List<string> _badStrings = ["ab", "cd", "pq", "xy"];

        public bool IsNice(string input)
        {
            foreach (string badString in _badStrings)
            {
                if (input.Contains(badString))
                {
                    return false;
                }
            }

            int vowelCount = 0;
            bool hasDoubleLetter = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (_vowels.Contains(input[i]))
                {
                    vowelCount++;
                }

                if (i > 0 && input[i] == input[i - 1])
                {
                    hasDoubleLetter = true;
                }
            }

            return vowelCount >= 3 && hasDoubleLetter;
        }

        public int GetNiceCount(string input)
        {
            string[] inputs = input.Split([ Environment.NewLine ], StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string s in inputs)
            {
                if (IsNice(s))
                {
                    count++;
                }
            }

            return count;
        }
    }
}