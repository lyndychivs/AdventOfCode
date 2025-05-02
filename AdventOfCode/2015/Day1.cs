namespace AdventOfCode
{
    public class Day1
    {
        public int CalculateFloor(string input)
        {
            int floor = 0;
            foreach (char c in input)
            {
                floor += TranslateDirection(c);
            }

            return floor;
        }

        public int CalculateFirstBasementOccurancePosition(string input)
        {
            int floor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                floor += TranslateDirection(input[i]);
                if (floor == -1)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private int TranslateDirection(char input)
        {
            if (input == '(')
            {
                return 1;
            }

            if (input == ')')
            {
                return -1;
            }

            return 0;
        }
    }
}