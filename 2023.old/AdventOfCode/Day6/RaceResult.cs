namespace AdventOfCode.Day6
{
    using System;

    internal class RaceResult(long time, long distance)
    {
        private long Time { get; set; } = time;
        private long Distance { get; set; } = distance;

        private long ShortestTimeOnButtonForWin { get => GetShortestTimeOnButtonForWin(); }
        private long LongestTimeOnButtonForWin { get => GetLongestTimeOnButtonForWin(); }

        public long CountOfWaysToWin { get => GetCountOfWaysToWin(); }

        private long GetShortestTimeOnButtonForWin()
        {
            for (int i = 1; i < Time; i++)
            {
                if ((i * (Time - i)) > Distance)
                {
                    return i;
                }
            }

            return 0;
        }

        private long GetLongestTimeOnButtonForWin()
        {
            for (long i = Time - 1; i > 0; i--)
            {
                if ((i * (Time - i)) > Distance)
                {
                    return i;
                }
            }

            return 0;
        }

        private long GetCountOfWaysToWin()
        {
            return Math.Abs(LongestTimeOnButtonForWin - ShortestTimeOnButtonForWin) + 1;
        }
    }
}