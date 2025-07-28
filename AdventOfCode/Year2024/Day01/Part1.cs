namespace AdventOfCode.Year2024.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int GetSumOfDistances(IEnumerable<string> inputs)
        {
            List<int> leftList = [];
            List<int> rightList = [];

            foreach (string input in inputs)
            {
                string[] parts = input.Split("   ");

                if (parts.Length > 2)
                {
                    throw new Exception($"{nameof(parts)} cannot be greater than 2");
                }

                leftList.Add(int.Parse(parts[0]));
                rightList.Add(int.Parse(parts[1]));
            }

            leftList.Sort();
            rightList.Sort();

            List<int> distances = [];

            for (int i = 0; i < leftList.Count; i++)
            {
                distances.Add(Math.Abs(leftList[i] - rightList[i]));
            }

            return distances.Sum();
        }
    }
}