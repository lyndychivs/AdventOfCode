namespace AdventOfCode.Year2016.Day03
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        public int GetValidTriangleCount(List<string> inputs)
        {
            int triangleCount = 0;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < inputs.Count; y += 3)
                {
                    string[] row1 = inputs[y].Split("  ", StringSplitOptions.RemoveEmptyEntries);
                    string[] row2 = inputs[y + 1].Split("  ", StringSplitOptions.RemoveEmptyEntries);
                    string[] row3 = inputs[y + 2].Split("  ", StringSplitOptions.RemoveEmptyEntries);

                    if (row1.Length != 3 || row2.Length != 3 || row3.Length != 3)
                    {
                        throw new ArgumentException($"Each line must contain exactly three sides. input1='{inputs[y]}' input2='{inputs[y + 1]}' input3='{inputs[y + 2]}'");
                    }

                    int side1 = int.Parse(row1[x].Trim());
                    int side2 = int.Parse(row2[x].Trim());
                    int side3 = int.Parse(row3[x].Trim());

                    if (IsValidTriangle(side1, side2, side3))
                    {
                        triangleCount++;
                    }
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