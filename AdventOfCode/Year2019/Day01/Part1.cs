namespace AdventOfCode.Year2019.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int GetSumOfFuelRequirements(IEnumerable<string> inputs)
        {
            var fuelRequirements = new List<int>();

            foreach (string input in inputs)
            {
                int moduleWeight = int.Parse(input);
                int fuelRequirement = (moduleWeight / 3) - 2;

                if (fuelRequirement < 0)
                {
                    throw new Exception($"Fuel requirement cannot be negative. {input}");
                }

                fuelRequirements.Add(fuelRequirement);
            }

            return fuelRequirements.Sum();
        }
    }
}