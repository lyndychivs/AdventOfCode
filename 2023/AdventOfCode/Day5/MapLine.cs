namespace AdventOfCode.Day5
{
    using System;
    using System.Text.RegularExpressions;

    internal class MapLine
    {
        private readonly long _rangeLength;

        internal MapLine(string line)
        {
            var numberMatches = Regex.Matches(line, @"\d+");
            if (numberMatches.Count != 3)
            {
                throw new Exception($"{nameof(MapLine)} could not extract 3 digits from the line input.");
            }

            DestinationRangeStart = long.Parse(numberMatches[0].ToString());
            SourceRangeStart = long.Parse(numberMatches[1].ToString());
            _rangeLength = long.Parse(numberMatches[2].ToString());
        }

        public long DestinationRangeStart { get; private set; }
        public long SourceRangeStart { get; private set; }
        public long RangeLength { get => GetRangeLength(); }

        private long GetRangeLength()
        {
            if (_rangeLength < 1)
            {
                return 0;
            }

            return _rangeLength - 1;
        }
    }
}