namespace AdventOfCode.Year2019.Day02
{
    using System.Collections.Generic;

    public class Part2
    {
        public string Solve(string input)
        {
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    string result = Solve(input, noun, verb);

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        return result;
                    }
                }
            }

            return string.Empty;
        }

        private string Solve(string input, int noun, int verb)
        {
            var result = new List<int>();

            foreach (string number in input.Split(','))
            {
                result.Add(int.Parse(number));
            }

            result[1] = noun;
            result[2] = verb;

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

                    if (result[position3] == 19690720)
                    {
                        return ((100 * result[1]) + result[2]).ToString();
                    }

                    index += 3;

                    continue;
                }

                if (result[index] == 2)
                {
                    int position1 = result[index + 1];
                    int position2 = result[index + 2];
                    int position3 = result[index + 3];

                    result[position3] = result[position1] * result[position2];

                    if (result[position3] == 19690720)
                    {
                        return ((100 * result[1]) + result[2]).ToString();
                    }

                    index += 3;

                    continue;
                }
            }

            return string.Empty;
        }
    }
}