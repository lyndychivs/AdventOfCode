namespace AdventOfCode.Day6
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day6
    {
        private readonly string[] _input;

        public Day6()
        {
            _input = File.ReadAllLines("Day6/input.txt");
        }

        public long Part1()
        {
            List<long> times = GetListOfInts(_input[0]);
            List<long> distances = GetListOfInts(_input[1]);

            if (times.Count != distances.Count)
            {
                throw new Exception("Time and distance counts do not match");
            }

            var raceEngine = new RaceEngine([.. times], [.. distances]);
            return raceEngine.GetNumberOfWaysToBeatAllRecords();
        }

        public long Part2()
        {
            List<long> times = GetListOfInts(_input[0]);
            List<long> distances = GetListOfInts(_input[1]);

            if (times.Count != distances.Count)
            {
                throw new Exception("Time and distance counts do not match");
            }

            var timesString = string.Empty;
            var distancesString = string.Empty;
            for (int i = 0; i < times.Count; i++)
            {
                timesString += times[i];
                distancesString += distances[i];
            }

            var raceEngine = new RaceEngine([long.Parse(timesString)], [long.Parse(distancesString)]);

            return raceEngine.GetNumberOfWaysToBeatAllRecords();
        }

        private List<long> GetListOfInts(string input)
        {
            var matches = Regex.Matches(input, @"(\d+)");

            List<long> list = [];
            list.AddRange(matches.Select(match => long.Parse(match.Value)));

            return list;
        }
    }
}