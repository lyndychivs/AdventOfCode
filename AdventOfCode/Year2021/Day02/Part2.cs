namespace AdventOfCode.Year2021.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        public int GetCordsResult(IEnumerable<string> inputs)
        {
            var cords = new Cords();
            foreach (string input in inputs)
            {
                cords.Move(input);
            }

            return cords.X * cords.Y;
        }

        private class Cords()
        {
            public int Aim { get; set; } = 0;

            public int X { get; set; } = 0;

            public int Y { get; set; } = 0;

            public void Move(string command)
            {
                string[] parts = command.Split(' ');
                int distance = int.Parse(parts[1]);

                switch (parts[0])
                {
                    case "forward":
                        X += distance;
                        Y += Aim * distance;
                        break;
                    case "down":
                        Aim += distance;
                        break;
                    case "up":
                        Aim -= distance;
                        break;
                    default:
                        throw new ArgumentException($"Invalid command: {parts[0]}");
                }
            }
        }
    }
}