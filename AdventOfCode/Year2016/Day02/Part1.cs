namespace AdventOfCode.Year2016.Day02
{
    using System.Collections.Generic;

    public class Part1
    {
        private readonly int[,] _keypad = new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        private int x = 1;

        private int y = 1;

        public string GetCodes(IEnumerable<string> inputs)
        {
            var codes = new List<int>();
            foreach (string input in inputs)
            {
                codes.Add(GetCode(input));
            }

            return string.Join("", codes);
        }

        public int GetCode(string input)
        {
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'U':
                        if (y > 0)
                        {
                            y--;
                        }

                        break;

                    case 'D':
                        if (y < 2)
                        {
                            y++;
                        }

                        break;

                    case 'L':
                        if (x > 0)
                        {
                            x--;
                        }

                        break;

                    case 'R':
                        if (x < 2)
                        {
                            x++;
                        }

                        break;
                }
            }

            return _keypad[y, x];
        }
    }
}