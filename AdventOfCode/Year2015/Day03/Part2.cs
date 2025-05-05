namespace AdventOfCode.Year2015.Day03
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        public int CalulateHousesVisitedBySantaAndRobot(string input)
        {
            var houses = new Dictionary<(int, int), House>();

            var santaHouse = new House(0, 0);
            var robotHouse = new House(0, 0);

            houses.Add((santaHouse.X, santaHouse.Y), santaHouse);
            houses[(0, 0)].Visits++;

            for (int i = 0; i < input.Length; i++)
            {
                char direction = input[i];
                if (i % 2 == 0)
                {
                    santaHouse = GetNextHouse(direction, santaHouse);

                    if (houses.ContainsKey((santaHouse.X, santaHouse.Y)))
                    {
                        houses[(santaHouse.X, santaHouse.Y)].Visits++;

                        continue;
                    }

                    houses.Add((santaHouse.X, santaHouse.Y), new House(santaHouse.X, santaHouse.Y));
                }
                else
                {
                    robotHouse = GetNextHouse(direction, robotHouse);

                    if (houses.ContainsKey((robotHouse.X, robotHouse.Y)))
                    {
                        houses[(robotHouse.X, robotHouse.Y)].Visits++;

                        continue;
                    }

                    houses.Add((robotHouse.X, robotHouse.Y), new House(robotHouse.X, robotHouse.Y));
                }
            }

            return houses.Count;
        }

        private House GetNextHouse(char direction, House house)
        {
            switch (direction)
            {
                case '>':
                    return new House(house.X + 1, house.Y);
                case '<':
                    return new House(house.X - 1, house.Y);
                case '^':
                    return new House(house.X, house.Y + 1);
                case 'v':
                    return new House(house.X, house.Y - 1);
                default:
                    throw new ArgumentException($"Invalid direction: {direction}");
            }
        }

        private class House(int x, int y)
        {
            public int X { get; private set; } = x;

            public int Y { get; private set; } = y;

            public int Visits = 1;
        }
    }
}