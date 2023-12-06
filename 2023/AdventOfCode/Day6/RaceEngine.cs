namespace AdventOfCode.Day6
{
    using System;
    using System.Collections.Generic;

    internal class RaceEngine
    {
        private readonly List<RaceResult> _raceResults;

        internal RaceEngine(long[] times, long[] distances)
        {
            if (times.Length != distances.Length)
            {
                throw new Exception("Time and distance counts do not match");
            }

            _raceResults = [];

            for (var i = 0; i < times.Length; i++)
            {
                _raceResults.Add(new RaceResult(times[i], distances[i]));
            }
        }

        public long GetNumberOfWaysToBeatAllRecords()
        {
            long numberOfWaysToBeatRecord = 1;
            foreach (var raceResult in _raceResults)
            {
                numberOfWaysToBeatRecord *= raceResult.CountOfWaysToWin;
            }

            return numberOfWaysToBeatRecord;
        }
    }
}