namespace AdventOfCode.Year2015.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        public Box GetBoxPerDimensions(string input)
        {
            string[] dimensions = input.Split('x');
            if (dimensions.Length != 3)
            {
                throw new ArgumentException("Invalid charArray format. Expected format: 'LxWxH'");
            }

            return new Box(int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2]));
        }

        public int CalculateRibbonForAllBoxes(IEnumerable<string> inputs)
        {
            int totalRibbon = 0;

            foreach (string boxDimension in inputs)
            {
                totalRibbon += GetBoxPerDimensions(boxDimension).RequiredRibbonInFeet;
            }

            return totalRibbon;
        }

        public class Box(int length, int width, int height)
        {
            public int RequiredRibbonInFeet => (length * width * height) + (2 * Math.Min(Math.Min(length + width, width + height), length + height));
        }
    }
}