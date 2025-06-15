namespace AdventOfCode.Year2021.Day01
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int CountMeasurementIncreases(IEnumerable<string> inputs)
        {
            int measurementIncreaseCount = 0;
            int previousMeasurement = 0;
            foreach (string input in inputs)
            {
                if (!int.TryParse(input, out int measurement))
                {
                    throw new Exception($"Failed to parse: {input}");
                }

                if (previousMeasurement == 0)
                {
                    previousMeasurement = measurement;
                    continue;
                }

                if (measurement > previousMeasurement)
                {
                    measurementIncreaseCount++;
                }

                previousMeasurement = measurement;
            }

            return measurementIncreaseCount;
        }
    }
}
