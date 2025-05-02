namespace AdventOfCode.Day5
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class SeedRanges
    {
        public List<Seeds> Seeds { get; private set; }

        public SeedRanges(string[] input)
        {
            Seeds = [];

            var matches = Regex.Matches(input[0], @"\d+");
            if (matches.Count % 2 != 0)
            {
                throw new ArgumentException("Did not find an even number of seeds.");
            }

            for (int i = 0; i < (matches.Count - 1); i+=2)
            {
                int y = i + 1;
                Seeds.Add(new Seeds([$"{matches[i]} {matches[y]}"]));
            }
        }
    }
}