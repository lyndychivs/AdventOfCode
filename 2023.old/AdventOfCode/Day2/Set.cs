namespace AdventOfCode.Day2
{
    using System.Collections.Generic;

    public class Set
    {
        public Set()
        {
            Sets = [];
        }

        public Dictionary<string, int> Sets { get; private set; }

        public void Add(string colour, int amount)
        {
            if (Sets.ContainsKey(colour))
            {
                Sets[colour] += amount;
                return;
            }

            Sets.Add(colour, amount);
        }
    }
}