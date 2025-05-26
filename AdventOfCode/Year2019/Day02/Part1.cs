namespace AdventOfCode.Year2019.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public string Solve(string input)
        {
            var result = new List<int>();

            foreach (string number in input.Split(','))
            {
                result.Add(int.Parse(number));
            }

            result[1] = 12;
            result[2] = 2;

            for (int index = 0; index < result.Count; index++)
            {
                if (result[index] == 99)
                {
                    break;
                }

                if (result[index] == 1)
                {
                    int position1 = result[index + 1];
                    int position2 = result[index + 2];
                    int position3 = result[index + 3];

                    result[position3] = result[position1] + result[position2];

                    index += 3;

                    continue;
                }

                if (result[index] == 2)
                {
                    int position1 = result[index + 1];
                    int position2 = result[index + 2];
                    int position3 = result[index + 3];

                    result[position3] = result[position1] * result[position2];

                    index += 3;

                    continue;
                }
            }

            Console.WriteLine(string.Join(",", result));

            return result[0].ToString();
        }
    }
}