namespace AdventOfCode.Day5
{
    using System.Collections.Generic;

    public class Mapper
    {
        private readonly List<MapLine> _mapLines;

        public Mapper(string[] input)
        {
            _mapLines = [];

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                _mapLines.Add(new MapLine(line));
            }
        }

        public long GetDestinationValue(long sourceValue)
        {
            foreach (var mapLine in _mapLines)
            {
                if (mapLine.SourceRangeStart <= sourceValue && (mapLine.SourceRangeStart + mapLine.RangeLength) >= sourceValue)
                {
                    return mapLine.DestinationRangeStart + (sourceValue - mapLine.SourceRangeStart);
                }
            }

            return sourceValue;
        }
    }
}