namespace AdventOfCode.Year2016.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        private readonly char[,] _screen;

        public Part1(int screenX, int screenY)
        {
            _screen = new char[screenY, screenX];

            for (int y = 0; y < _screen.GetLength(0); y++)
            {
                for (int x = 0; x < _screen.GetLength(1); x++)
                {
                    _screen[y, x] = '.';
                }
            }
        }

        public int GetCountOfLitPixelsPerInputs(IEnumerable<string> inputs)
        {
            foreach (string input in inputs)
            {
                Action(input);
            }

            PrintScreen();

            return GetCountOfLitPixels();
        }

        private void Action(string input)
        {
            if (input.Contains("rect "))
            {
                input = input.Replace("rect ", string.Empty);
                string[] dimensions = input.Split('x');

                int width = int.Parse(dimensions[0]);
                int height = int.Parse(dimensions[1]);

                foreach (int y in Enumerable.Range(0, height))
                {
                    foreach (int x in Enumerable.Range(0, width))
                    {
                        _screen[y, x] = '#';
                    }
                }

                return;
            }

            if (input.Contains("rotate column x="))
            {
                input = input.Replace("rotate column x=", string.Empty);
                string[] dimensions = input.Split([ " by " ], StringSplitOptions.RemoveEmptyEntries);

                int column = int.Parse(dimensions[0]);
                int shift = int.Parse(dimensions[1]);

                char[] columnValues = new char[_screen.GetLength(0)];
                for (int y = 0; y < _screen.GetLength(0); y++)
                {
                    columnValues[y] = _screen[y, column];
                }

                for (int y = 0; y < _screen.GetLength(0); y++)
                {
                    int newY = (y + shift) % _screen.GetLength(0);
                    _screen[newY, column] = columnValues[y];
                }

                return;
            }

            if (input.Contains("rotate row y="))
            {
                input = input.Replace("rotate row y=", string.Empty);
                string[] dimensions = input.Split([" by "], StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(dimensions[0]);
                int shift = int.Parse(dimensions[1]);

                char[] rowValues = new char[_screen.GetLength(1)];
                for (int x = 0; x < _screen.GetLength(1); x++)
                {
                    rowValues[x] = _screen[row, x];
                }

                for (int x = 0; x < _screen.GetLength(1); x++)
                {
                    int newX = (x + shift) % _screen.GetLength(1);
                    _screen[row, newX] = rowValues[x];
                }

                return;
            }
        }

        private void PrintScreen()
        {
            for (int y = 0; y < _screen.GetLength(0); y++)
            {
                for (int x = 0; x < _screen.GetLength(1); x++)
                {
                    Console.Write(_screen[y, x]);
                }

                Console.WriteLine();
            }
        }

        private int GetCountOfLitPixels()
        {
            int count = 0;

            for (int y = 0; y < _screen.GetLength(0); y++)
            {
                for (int x = 0; x < _screen.GetLength(1); x++)
                {
                    if (_screen[y, x] == '#')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}