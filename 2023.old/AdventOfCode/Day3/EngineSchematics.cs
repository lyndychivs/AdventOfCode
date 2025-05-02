namespace AdventOfCode.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EngineSchematics(string[] input)
    {
        public List<string> Schematics { get; private set; } = [.. input];

        public int GetSumOfAllEnginePartNumbers()
        {
            var validPartNumbers = new List<int>();
            for (int y = 0; y < Schematics.Count; y++)
            {
                var digitMatches = Regex.EnumerateMatches(Schematics[y], @"\d+");
                foreach (var digitMatch in digitMatches)
                {
                    var isSymbolFound = false;
                    for (int matchX = 0; matchX < digitMatch.Length && !isSymbolFound; matchX++)
                    {
                        var position = new Position(matchX + digitMatch.Index, y);
                        foreach (var adjacentPosition in position.GetAdjacentPosition())
                        {
                            if (IsPositionValueSymbol(adjacentPosition))
                            {
                                validPartNumbers.Add(int.Parse(Schematics[y].AsSpan().Slice(digitMatch.Index, digitMatch.Length)));
                                isSymbolFound = true;
                            }
                        }
                    }
                }
            }

            return validPartNumbers.Sum();
        }

        public int GetSumOfAllGearRatios()
        {
            var listOfGearRatios = new List<int>();

            Dictionary<(int y, int x), List<int>> positionOfGearWithAdjacentValues = [];
            for (int y = 0; y < Schematics.Count; y++)
            {
                var digitMatches = Regex.EnumerateMatches(Schematics[y], @"\d+");
                foreach (var digitMatch in digitMatches)
                {
                    var value = int.Parse(Schematics[y].AsSpan().Slice(digitMatch.Index, digitMatch.Length));

                    var isDigitLinkedToGear = false;
                    for (int matchX = 0; matchX < digitMatch.Length && !isDigitLinkedToGear; matchX++)
                    {
                        var position = new Position(matchX + digitMatch.Index, y);
                        foreach (var adjacentPosition in position.GetAdjacentPosition())
                        {
                            if (IsPositionValueGear(adjacentPosition))
                            {
                                if (!positionOfGearWithAdjacentValues.ContainsKey((adjacentPosition.Y, adjacentPosition.X)))
                                {
                                    positionOfGearWithAdjacentValues[(adjacentPosition.Y, adjacentPosition.X)] = [];
                                }

                                positionOfGearWithAdjacentValues[(adjacentPosition.Y, adjacentPosition.X)].Add(value);
                                isDigitLinkedToGear = true;
                            }
                        }
                    }
                }
            }

            foreach (var positionOfGearWithAdjacentValue in positionOfGearWithAdjacentValues)
            {
                if (positionOfGearWithAdjacentValue.Value.Count == 2)
                {
                    listOfGearRatios.Add(positionOfGearWithAdjacentValue.Value[0] * positionOfGearWithAdjacentValue.Value[1]);
                }
            }

            return listOfGearRatios.Sum();
        }

        private char GetCharAtPosition(Position position)
        {

            if (position.Y < 0 || position.Y >= Schematics.Count)
            {
                return '.';
            }

            if (position.X < 0 || position.X >= Schematics[position.Y].Length)
            {
                return '.';
            }

            return Schematics[position.Y][position.X];
        }

        private bool IsPositionValueSymbol(Position position)
        {
            var c = GetCharAtPosition(position);
            return !char.IsDigit(c) && c != '.';
        }

        private bool IsPositionValueGear(Position position)
        {
            var c = GetCharAtPosition(position);
            return c == '*';
        }
    }
}