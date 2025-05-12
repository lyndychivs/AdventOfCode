namespace AdventOfCode.Year2016.Day03
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int GetValidTriangleCount(IEnumerable<string> inputs)
        {
            int triangleCount = 0;

            foreach (string input in inputs)
            {
                string[] sides = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
                if (sides.Length != 3)
                {
                    throw new ArgumentException($"Each line must contain exactly three sides. input='{input}'");
                }

                int side1 = int.Parse(sides[0].Trim());
                int side2 = int.Parse(sides[1].Trim());
                int side3 = int.Parse(sides[2].Trim());

                if (IsValidTriangle(side1, side2, side3))
                {
                    triangleCount++;
                }
            }

            return triangleCount;
        }

        private bool IsValidTriangle(int side1, int side2, int side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }
    }
}