namespace AdventOfCode.Year2015.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetWinningReindeerPoints(IEnumerable<string> inputs, int raceDurationInSeconds)
        {
            List<Reindeer> reindeerList = GetReindeerForRace(inputs);

            Dictionary<int, Reindeer> racePositions = GetRacePositionsByPoints(raceDurationInSeconds, reindeerList);

            LogRaceResults(racePositions);

            return racePositions.Keys.OrderDescending().First();
        }

        private void LogRaceResults(Dictionary<int, Reindeer> racePositions)
        {
            Console.WriteLine("------- Race -------");

            foreach (int i in racePositions.Keys.OrderDescending())
            {
                Console.WriteLine($"{racePositions[i].Name} - Points:{i}");
            }

            Console.WriteLine("--------------------");
        }

        private Dictionary<int, Reindeer> GetRacePositionsByPoints(int raceDurationInSeconds, List<Reindeer> reindeerList)
        {
            foreach (int second in Enumerable.Range(1, raceDurationInSeconds))
            {
                Dictionary<Reindeer, int> raceProgress = [];

                int maxDistance = 0;
                foreach (Reindeer reindeer in reindeerList)
                {
                    int distance = reindeer.GetDistance(second);
                    raceProgress.Add(reindeer, distance);

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }

                foreach (KeyValuePair<Reindeer, int> kvp in raceProgress)
                {
                    if (kvp.Value == maxDistance)
                    {
                        kvp.Key.AwardPoint();
                    }
                }
            }

            Dictionary<int, Reindeer> racePositions = [];
            foreach (Reindeer reindeer in reindeerList)
            {
                racePositions.Add(reindeer.GetPoints(), reindeer);
            }

            return racePositions;
        }

        private List<Reindeer> GetReindeerForRace(IEnumerable<string> inputs)
        {
            var reindeerList = new List<Reindeer>();

            foreach (string input in inputs)
            {
                string[] parts = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);

                reindeerList.Add(new Reindeer(
                    parts[0],
                    int.Parse(parts[3]),
                    int.Parse(parts[6]),
                    int.Parse(parts[13])));
            }

            return reindeerList;
        }

        private class Reindeer(string name, int speedPerSecond, int flyTimePerSecond, int restTimePerSecond)
        {
            private int _points = 0;

            private readonly int _speedPerSecond = speedPerSecond;

            private readonly int _flyTimePerSecond = flyTimePerSecond;

            private readonly int _restTimePerSecond = restTimePerSecond;

            public string Name { get; } = name;

            public int GetDistance(int durationInSeconds)
            {
                int distance = 0;
                
                for (int s = 0; s < durationInSeconds; s++)
                {
                    if (s % (_flyTimePerSecond + _restTimePerSecond) < _flyTimePerSecond)
                    {
                        distance += _speedPerSecond;
                    }
                }

                return distance;
            }

            public void AwardPoint()
            {
                _points++;
            }

            public int GetPoints()
            {
                return _points;
            }
        }
    }
}