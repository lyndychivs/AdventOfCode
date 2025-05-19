namespace AdventOfCode.Year2016.Day09
{
    using System.Collections.Generic;

    public class Part1
    {
        public int GetDecompressedLength(string inputs)
        {
            var characters = new List<char>();
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == '(')
                {
                    int crossIndex = inputs.IndexOf('x', i);
                    int length = int.Parse(inputs[(i + 1)..crossIndex]);

                    int endBrakcetIndex = inputs.IndexOf(')', crossIndex);
                    int repeat = int.Parse(inputs[(crossIndex + 1)..endBrakcetIndex]);

                    i = endBrakcetIndex + 1;

                    string repeatString = inputs.Substring(i, length);

                    for (int k = 0; k < repeat; k++)
                    {
                        characters.AddRange(repeatString);
                    }

                    i += length - 1;

                    continue;
                }

                characters.Add(inputs[i]);
            }

            return characters.Count;
        }
    }
}