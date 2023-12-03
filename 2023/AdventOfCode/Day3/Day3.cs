namespace AdventOfCode.Day3
{
    using System.IO;

    public class Day3
    {
        private readonly string[] _input;

        public Day3()
        {
            _input = File.ReadAllLines("Day3/input.txt");
        }

        public int GetSumOfAllEnginePartNumbers()
        {
            var engineSchematic = new EngineSchematics(_input);
            return engineSchematic.GetSumOfAllEnginePartNumbers();
        }

        public int GetSumOfAllGearRatios()
        {
            var engineSchematic = new EngineSchematics(_input);
            return engineSchematic.GetSumOfAllGearRatios();
        }
    }
}