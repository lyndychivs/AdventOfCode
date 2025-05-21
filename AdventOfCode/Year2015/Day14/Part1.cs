namespace AdventOfCode.Year2015.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int GetWinningReindeerDistance(IEnumerable<string> inputs, int raceDurationInSeconds)
        {
            List<Reindeer> reindeerList = GetReindeerForRace(inputs);
            Dictionary<int, Reindeer> racePositions = GetRacePositionsPerReindeer(raceDurationInSeconds, reindeerList);

            LogRaceResults(racePositions);

            return racePositions.Keys.OrderDescending().First();
        }

        private void LogRaceResults(Dictionary<int, Reindeer> racePositions)
        {
            Console.WriteLine("------- Race -------");

            foreach (int i in racePositions.Keys.OrderDescending())
            {
                Console.WriteLine($"{racePositions[i].Name} - Distance:{i}");
            }

            Console.WriteLine("--------------------");
        }

        private Dictionary<int, Reindeer> GetRacePositionsPerReindeer(int raceDurationInSeconds, List<Reindeer> reindeerList)
        {
            Dictionary<int, Reindeer> racePositions = [];
            foreach (Reindeer reindeer in reindeerList)
            {
                int distance = 0;

                for (int s = 0; s < raceDurationInSeconds; s++)
                {
                    if (s % (reindeer.FlyTimePerSecond + reindeer.RestTimePerSecond) < reindeer.FlyTimePerSecond)
                    {
                        distance += reindeer.SpeedPerSecond;
                    }
                }

                racePositions.Add(distance, reindeer);
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
            public string Name { get; } = name;

            public int SpeedPerSecond { get; } = speedPerSecond;

            public int FlyTimePerSecond { get; } = flyTimePerSecond;

            public int RestTimePerSecond { get; } = restTimePerSecond;
        }
    }
}