namespace AdventOfCode.Year2015.Day02
{
    using System;

    public class Part1
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

        public class Box(int length, int width, int height)
        {
            private int Lw => length * width;

            private int Wh => width * height;

            private int Hl => height * length;

            public int SurfaceArea => 2 * (Lw + Wh + Hl);

            public int SmallestArea => Math.Min(Math.Min(Lw, Wh), Hl);

            public int RequiredWrappingPaperInSquareFeet => SurfaceArea + SmallestArea;
        }
    }
}