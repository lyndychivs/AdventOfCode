namespace AdventOfCode.Year2015.Day01
{
    public class Part1
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

        private static int TranslateDirection(char input)
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