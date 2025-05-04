namespace AdventOfCode.Year2015
{
    using System;

    public class Day2
    {
        public Box GetBoxPerDimensions(string input)
        {
            string[] dimensions = input.Split('x');
            if (dimensions.Length != 3)
            {
                throw new ArgumentException("Invalid input format. Expected format: 'LxWxH'");
            }

            return new Box(int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2]));
        }

        public int CalculateWrappingPaperForAllBoxes(string input)
        {
            string[] boxDimensions = input.Split([ Environment.NewLine ], StringSplitOptions.RemoveEmptyEntries);
            int totalWrappingPaper = 0;

            foreach (string boxDimension in boxDimensions)
            {
                totalWrappingPaper += GetBoxPerDimensions(boxDimension).RequiredWrappingPaperInSquareFeet;
            }

            return totalWrappingPaper;
        }

        public int CalculateRibbonForAllBoxes(string input)
        {
            string[] boxDimensions = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
            int totalRibbon = 0;

            foreach (string boxDimension in boxDimensions)
            {
                totalRibbon += GetBoxPerDimensions(boxDimension).RequiredRibbonInFeet;
            }

            return totalRibbon;
        }
    }

    public class Box(int length, int width, int height)
    {
        private int Lw => length * width;

        private int Wh => width * height;

        private int Hl => height * length;

        public int SurfaceArea => 2 * (Lw + Wh + Hl);

        public int SmallestArea => Math.Min(Math.Min(Lw, Wh), Hl);

        public int RequiredWrappingPaperInSquareFeet => SurfaceArea + SmallestArea;

        public int RequiredRibbonInFeet => (length * width * height) + (2 * Math.Min(Math.Min(length + width, width + height), length + height));
    }
}