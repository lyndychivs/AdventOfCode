namespace AdventOfCode.Year2019.Day01
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetSumOfFuelRequirements(IEnumerable<string> inputs)
        {
            var fuelRequirements = new List<int>();

            foreach (string input in inputs)
            {
                fuelRequirements.Add(GetFuelRequirement(int.Parse(input)));
            }

            return fuelRequirements.Sum();
        }

        private int GetFuelRequirement(int moduleWeight)
        {
            int fuelRequirement = (moduleWeight / 3) - 2;

            if (fuelRequirement <= 0)
            {
                return 0;
            }

            return fuelRequirement + GetFuelRequirement(fuelRequirement);
        }
    }
}