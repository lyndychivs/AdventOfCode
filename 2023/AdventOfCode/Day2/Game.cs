namespace AdventOfCode.Day2
{
    using System.Collections.Generic;

    public class Game(int id)
    {
        public int Id { get; private set; } = id;
        public List<Set> Sets { get; private set; } = [];

        public int GetMaxCubeCountPerColour(string colour)
        {
            var max = 0;

            foreach (var set in Sets)
            {
                if (set.Sets.TryGetValue(colour, out var colourCount))
                {
                    if (colourCount > max)
                    {
                        max = colourCount;
                    }
                };
            }

            return max;
        }
    }
}