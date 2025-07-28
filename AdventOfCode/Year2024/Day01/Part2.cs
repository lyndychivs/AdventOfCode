namespace AdventOfCode.Year2024.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetDistancesSimilarityScore(IEnumerable<string> inputs)
        {
            List<Number> numberList = [];
            List<int> occuranceList = [];

            foreach (string input in inputs)
            {
                string[] parts = input.Split("   ");

                if (parts.Length > 2)
                {
                    throw new Exception($"{nameof(parts)} cannot be greater than 2");
                }

                numberList.Add(new Number(int.Parse(parts[0])));
                occuranceList.Add(int.Parse(parts[1]));
            }

            foreach (Number number in numberList)
            {
                for (int i = 0; i < occuranceList.Count; i++)
                {
                    if (number.Value == occuranceList[i])
                    {
                        number.AddSimilarityPoint();
                    }
                }
            }

            List<int> totalScores = [];
            foreach (Number number in numberList)
            {
                totalScores.Add(number.GetSimilarityScore());
            }

            return totalScores.Sum();
        }

        private class Number(int value)
        {
            public int Value { get; init; } = value;

            public int SimilarityPoints { get; private set; } = 0;

            public void AddSimilarityPoint()
            {
                SimilarityPoints++;
            }

            public int GetSimilarityScore()
            {
                return Value * SimilarityPoints;
            }
        }
    }
}