namespace AdventOfCode.Day5
{
    using System.IO;

    public class Day5
    {
        private readonly string[] _input;

        public Day5()
        {
            _input = File.ReadAllLines("Day5/input.txt");
        }

        public long GetLowestLocationNumberForSeeds()
        {
            var gardenEngine = new GardenEngine(_input);
            return gardenEngine.GetLowestLocationNumberForSeeds();
        }

        public long GetSeedNumberWithLowestLocationNumber()
        {
            var gardenEngine = new GardenEngine(_input);
            return gardenEngine.GetSeedNumberWithLowestLocationNumber();
        }
    }
}