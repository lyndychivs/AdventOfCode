namespace AdventOfCode.Year2015.Day03
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int CalulateHousesVisited(string input)
        {
            var houses = new Dictionary<(int, int), House>();

            var currentHouse = new House(0, 0);
            houses.Add((currentHouse.X, currentHouse.Y), currentHouse);

            foreach (char direction in input)
            {
                currentHouse = GetNextHouse(direction, currentHouse);

                if (houses.ContainsKey((currentHouse.X, currentHouse.Y)))
                {
                    houses[(currentHouse.X, currentHouse.Y)].Visits++;

                    continue;
                }

                houses.Add((currentHouse.X, currentHouse.Y), new House(currentHouse.X, currentHouse.Y));
            }

            return houses.Count;
        }

        private House GetNextHouse(char direction, House house)
        {
            return direction switch
            {
                '>' => new House(house.X + 1, house.Y),
                '<' => new House(house.X - 1, house.Y),
                '^' => new House(house.X, house.Y + 1),
                'v' => new House(house.X, house.Y - 1),
                _ => throw new ArgumentException($"Invalid direction: {direction}"),
            };
        }

        private class House(int x, int y)
        {
            public int X { get; private set; } = x;

            public int Y { get; private set; } = y;

            public int Visits = 1;
        }
    }
}