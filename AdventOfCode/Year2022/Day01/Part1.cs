namespace AdventOfCode.Year2022.Day01
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int FindElfWithMostCalories(IEnumerable<string> inputs)
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

            return elfs.OrderBy(e => e.Calories)
                .Last()
                .Calories;
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