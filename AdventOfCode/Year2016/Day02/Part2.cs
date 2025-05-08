namespace AdventOfCode.Year2016.Day02
{
    using System.Collections.Generic;

    public class Part2
    {
        private readonly string[,] _keypad = new[,]
        {
            { "0", "0", "1", "0", "0" },
            { "0", "2", "3", "4", "0" },
            { "5", "6", "7", "8", "9" },
            { "0", "A", "B", "C", "0" },
            { "0", "0", "D", "0", "0" }
        };

        private int x = 0;

        private int y = 2;

        public string GetCodes(IEnumerable<string> inputs)
        {
            var codes = new List<string>();
            foreach (string input in inputs)
            {
                codes.Add(GetCode(input));
            }

            return string.Join("", codes);
        }

        public string GetCode(string input)
        {
            foreach (char c in input)
            {
                string value;

                switch (c)
                {
                    case 'U':
                        value = GetKeyValue(x, y - 1);
                        if (value != "0")
                        {
                            y--;
                        }

                        break;

                    case 'D':
                        value = GetKeyValue(x, y + 1);
                        if (value != "0")
                        {
                            y++;
                        }

                        break;

                    case 'L':
                        value = GetKeyValue(x - 1, y);
                        if (value != "0")
                        {
                            x--;
                        }

                        break;

                    case 'R':
                        value = GetKeyValue(x + 1, y);
                        if (value != "0")
                        {
                            x++;
                        }

                        break;
                }
            }

            return _keypad[y, x];
        }

        private string GetKeyValue(int x, int y)
        {
            if (x < 0 || x >= _keypad.GetLength(1) || y < 0 || y >= _keypad.GetLength(0))
            {
                return "0";
            }

            return _keypad[y, x];
        }
    }
}