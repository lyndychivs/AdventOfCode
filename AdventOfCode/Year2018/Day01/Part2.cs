namespace AdventOfCode.Year2018.Day01
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetFrequency(IEnumerable<string> inputs)
        {
            var frequencys = new List<int>
            {
                0
            };

            while (true)
            {
                foreach (string input in inputs)
                {
                    if (int.TryParse(input, out int value))
                    {
                        int frequency = frequencys.Last() + value;

                        if (frequencys.Contains(frequency))
                        {
                            return frequency;
                        }

                        frequencys.Add(frequency);
                    }
                }
            }
        }
    }
}