namespace AdventOfCode.Year2015.Day01
{
    public class Part2
    {
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