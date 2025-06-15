namespace AdventOfCode.Year2022.Day01
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetTopThreeElfCalories(IEnumerable<string> inputs)
        {
            List<Elf> elfs = [ new Elf() ];

            foreach (string input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    elfs.Add(new Elf());
                }

                elfs.Last().AddFood(input);
            }

            var elfsDesc = elfs.OrderByDescending(e => e.Calories).ToList();

            return elfsDesc[0].Calories + elfsDesc[1].Calories + elfsDesc[2].Calories;
        }

        private class Elf()
        {
            public int Calories { get; private set; } = 0;

            public void AddFood(string calories)
            {
                if (string.IsNullOrWhiteSpace(calories))
                {
                    return;
                }

                Calories += int.Parse(calories);
            }
        }
    }
}