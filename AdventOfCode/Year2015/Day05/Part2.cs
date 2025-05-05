namespace AdventOfCode.Year2015.Day05
{
    using System;

    public class Part2
    {
        public bool IsNice(string input)
        {
            bool hasPair = false;
            bool hasRepeat = false;

            for (int i = 0; i < input.Length; i++)
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
    }
}