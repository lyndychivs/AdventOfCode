namespace AdventOfCode.Year2021.Day01
{
    using System.Collections.Generic;

    public class Part2
    {
        public int CountMeasurementIncreases(IEnumerable<string> inputs)
        {
            int measurementIncreaseCount = 0;
            int previousMeasurement = 0;

            var inputsAsInt = new List<int>();
            foreach (string input in inputs)
            {
                inputsAsInt.Add(int.Parse(input));
            }

            for (int i = 0; i < inputsAsInt.Count - 2; i++)
            {
                var currentMeasurement = new Measurement(
                    inputsAsInt[i],
                    inputsAsInt[i + 1],
                    inputsAsInt[i + 2]);
                
                if (previousMeasurement == 0)
                {
                    previousMeasurement = currentMeasurement.Total;
                    continue;
                }

                if (currentMeasurement.Total > previousMeasurement)
                {
                    measurementIncreaseCount++;
                }

                previousMeasurement = currentMeasurement.Total;
            }

            return measurementIncreaseCount;
        }

        private class Measurement(int depth1, int depth2, int depth3)
        {
            public int Total { get; init; } = depth1 + depth2 + depth3;
        }
    }
}
