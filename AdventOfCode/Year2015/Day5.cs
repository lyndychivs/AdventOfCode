namespace AdventOfCode.Year2015
{
    using System;
    using System.Collections.Generic;

    public class Day5
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
            string[] inputs = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);

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

        public bool IsNicePartTwo(string input)
        {
            bool hasPair = false;
            bool hasRepeat = false;

            for(int i = 0; i < input.Length; i++)
            {
                if (!(i + 2 < input.Length))
                {
                    continue;
                }

                string pair = input.Substring(i, 2);

                if (input.IndexOf(pair, i + 2) > 0)
                {
                    hasPair = true;
                }

                if (input[i] == input[i + 2])
                {
                    hasRepeat = true;
                }
            }

            return hasPair && hasRepeat;
        }

        public int GetNiceCountPartTwo(string input)
        {
            string[] inputs = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string s in inputs)
            {
                if (IsNicePartTwo(s))
                {
                    count++;
                }
            }

            return count;
        }
    }
}