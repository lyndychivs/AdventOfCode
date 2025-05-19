namespace AdventOfCode.Year2016.Day09
{
    using System.Collections.Generic;
    using System.Numerics;

    public class Part2
    {
        private readonly List<int> _weights = [];

        public BigInteger GetDecompressedLength(string input)
        {
            foreach (char _ in input)
            {
                _weights.Add(1);
            }

            return GetWeightsForInput(input);
        }

        private BigInteger GetWeightsForInput(string input)
        {
            BigInteger count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    int crossIndex = input.IndexOf('x', i);
                    int length = int.Parse(input[(i + 1)..crossIndex]);

                    int endBrakcetIndex = input.IndexOf(')', crossIndex);
                    int repeat = int.Parse(input[(crossIndex + 1)..endBrakcetIndex]);

                    i = endBrakcetIndex;

                    for (int j = 0; j < length; j++)
                    {
                        _weights[i + j + 1] = _weights[i + j + 1] * repeat;
                    }
                }
                else
                {
                    count += _weights[i];
                }
            }

            return count;
        }
    }
}