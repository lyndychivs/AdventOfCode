namespace AdventOfCode.Day2
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day2
    {
        private readonly string[] _input;

        private readonly List<Game> _games;

        public Day2()
        {
            _input = File.ReadAllLines("Day2/input.txt");
            _games = [];

            PopulateGameList();
        }

        public int DetermineSumOfPossibleGameIds(Dictionary<string, int> gameConditions)
        {
            var gameIdSum = 0;

            foreach (var game in _games)
            {
                var isGamePossible = true;

                foreach (var gameCondition in gameConditions)
                {
                    var count = game.GetMaxCubeCountPerColour(gameCondition.Key);

                    if (count > gameCondition.Value)
                    {
                        isGamePossible = false;
                        break;
                    }
                }

                if (isGamePossible)
                {
                    gameIdSum += game.Id;
                }
            }

            return gameIdSum;
        }

        public int CalcuateEachGamesPowerAndGetSum(List<string> colours)
        {
            var powerList = new List<int>();

            foreach (var game in _games)
            {
                var colourTotals = new List<int>();

                foreach(var colour in colours)
                {
                    var colourMaxCount = game.GetMaxCubeCountPerColour(colour);

                    if (colourMaxCount == 0)
                    {
                        continue;
                    }

                    colourTotals.Add(colourMaxCount);
                }

                if (colourTotals.Count == 0)
                {
                    continue;
                }

                var power = 1;

                foreach (var colourTotal in colourTotals)
                {
                    power = power * colourTotal;
                }

                powerList.Add(power);
            }

            return powerList.Sum();
        }

        private void PopulateGameList()
        {
            foreach (var line in _input)
            {
                var game = new Game(GetGameId(line));

                PopulateGameSets(game, line);

                _games.Add(game);
            }
        }

        private int GetGameId(string line)
        {
            var gameContext = line.Split(':')[0];
            return GetIntFromString(gameContext);
        }

        private void PopulateGameSets(Game game, string line)
        {
            var allSets = line.Replace($"Game {game.Id}:", string.Empty);

            var sets = allSets.Split(';');

            foreach (var set in sets)
            {
                var gameSet = new Set();
                var setOptions = set.Split(',');

                foreach (var option in setOptions)
                {
                    var count = GetIntFromString(option);

                    var colour = option.Replace(count.ToString(), string.Empty)
                        .Replace(" ", string.Empty)
                        .Trim();

                    gameSet.Add(colour, count);
                }

                game.Sets.Add(gameSet);
            }
        }

        private int GetIntFromString(string input)
        {
            return int.Parse(new string(input.Where(char.IsDigit).ToArray()));
        }
    }
}