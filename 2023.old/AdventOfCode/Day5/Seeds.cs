namespace AdventOfCode.Day5
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Seeds
    {
        public List<long> SeedValues { get; set; }

        public long RangeLength => GetRangeLength();
        public long RangeStart => SeedValues[0];

        public Seeds(string[] input)
        {
            SeedValues = [];
            foreach (var line in input)
            {
                var numberMatches = Regex.Matches(line, @"\d+");
                foreach (var match in numberMatches)
                {
                    SeedValues.Add(long.Parse(match.ToString()));
                }
            }
        }

        private long GetRangeLength()
        {
            if (SeedValues[1] < 1)
            {
                return 0;
            }

            return SeedValues[1] - 1;
        }
    }
}