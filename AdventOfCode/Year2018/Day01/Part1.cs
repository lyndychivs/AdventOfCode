namespace AdventOfCode.Year2018.Day01
{
    using System.Collections.Generic;

    public class Part1
    {
        public int GetFrequency(IEnumerable<string> inputs)
        {
            int frequency = 0;

            foreach (string input in inputs)
            {
                if (int.TryParse(input, out int value))
                {
                    frequency += value;
                }
            }

            return frequency;
        }
    }
}