namespace AdventOfCode.Year2015.Day10
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Part2
    {
        public int Solve(string input)
        {
            for (int i = 0; i < 50; i++)
            {
                input = LookAndSay(input);
            }

            return input.Length;
        }

        private string LookAndSay(string input)
        {
            var pairs = new List<Pair>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                int currentCharCount = 0;
                while (i + currentCharCount < input.Length && input[i + currentCharCount] == currentChar)
                {
                    currentCharCount++;
                }

                pairs.Add(new Pair(currentChar, currentCharCount));

                i += currentCharCount - 1;
            }

            var response = new StringBuilder();
            foreach (Pair pair in pairs)
            {
                _ = response.Append(pair.ToString());
            }

            Console.WriteLine(response.ToString());

            return response.ToString();
        }

        private class Pair(char Character, int Count)
        {
            public char Character { get; } = Character;

            public int Count { get; } = Count;

            public override string ToString()
            {
                return $"{Count}{Character}";
            }
        }
    }
}