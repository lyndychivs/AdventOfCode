namespace AdventOfCode.Year2024.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int GetSumOfSafeReports(IEnumerable<string> inputs)
        {
            int sumOfSafeReports = 0;
            foreach (string input in inputs)
            {
                var report = new Report(input);
                if (report.IsSafe())
                {
                    sumOfSafeReports++;
                }
            }

            return sumOfSafeReports;
        }

        private class Report
        {
            public Report(string input)
            {
                string[] parts = input.Split(" ");
                foreach (string part in parts)
                {
                    Levels.Add(int.Parse(part));
                }
            }

            private List<int> Levels { get; set; } = [];

            public bool IsSafe()
            {
                return IsAllLevelsWithinRange() && IsLevelsEitherAllIncrementingOrDecrementing();
            }

            private bool IsAllLevelsWithinRange()
            {
                for (int i = 0; i < Levels.Count - 1; i++)
                {
                    int diff = Math.Abs(Levels[i] - Levels[i + 1]);

                    if (diff == 0)
                    {
                        return false;
                    }

                    if (diff > 3)
                    {
                        return false;
                    }
                }

                return true;
            }

            private bool IsLevelsEitherAllIncrementingOrDecrementing()
            {
                return IsAllLevelsIncremented() | IsAllLevelsDecremented();
            }

            private bool IsAllLevelsIncremented()
            {
                bool response = true;
                for(int i = 0; i < Levels.Count - 1; i++)
                {
                    if (Levels[i] < Levels[i + 1])
                    {
                        response = false;
                    }
                }

                return response;
            }

            private bool IsAllLevelsDecremented()
            {
                bool response = true;
                for (int i = 0; i < Levels.Count - 1; i++)
                {
                    if (Levels[i] > Levels[i + 1])
                    {
                        response = false;
                    }
                }

                return response;
            }
        }
    }
}