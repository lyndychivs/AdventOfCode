namespace AdventOfCode.Year2015.Day12
{
    public  class Part1
    {
        public int CalculateSumOfJson(string input)
        {
            int sum = 0;

            bool isNegative = false;
            string foundNumber = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && char.IsDigit(input[i + 1]))
                {
                    isNegative = true;

                    continue;
                }
                
                if (char.IsDigit(input[i]))
                {
                    foundNumber += input[i];

                    continue;
                }

                if (foundNumber.Length > 0)
                {
                    if (isNegative)
                    {
                        sum -= int.Parse(foundNumber);
                    }
                    else
                    {
                        sum += int.Parse(foundNumber);
                    }

                    foundNumber = string.Empty;
                    isNegative = false;
                }
            }

            return sum;
        }
    }
}