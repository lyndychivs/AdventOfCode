namespace AdventOfCode.Year2022.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int GetPlayerPoints(IEnumerable<string> inputs)
        {
            var rounds = new Rounds();
            foreach (string input in inputs)
            {
                string[] actions = input.Split(' ');

                rounds.PlayRound(actions[0][0], actions[1][0]);
            }

            return rounds.PlayerPoints;
        }

        private enum Action
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        private enum Outcome
        {
            Lose = 0,
            Draw = 3,
            Win = 6,
        }

        private static int MapAction(char action)
        {
            return action switch
            {
                'A' => (int)Action.Rock,
                'B' => (int)Action.Paper,
                'C' => (int)Action.Scissors,
                'X' => (int)Action.Rock,
                'Y' => (int)Action.Paper,
                'Z' => (int)Action.Scissors,
                _ => throw new Exception($"Failed to map Action: {action}")
            };
        }

        private class Rounds
        {
            public int PlayerPoints { get; set; } = 0;

            public void PlayRound(char opponentAction, char playerAction)
            {
                int opponentMove = MapAction(opponentAction);
                int playerMove = MapAction(playerAction);

                PlayerPoints += playerMove;

                if (playerMove == opponentMove)
                {
                    PlayerPoints += (int)Outcome.Draw;

                    return;
                }

                if ((playerMove == (int)Action.Rock && opponentMove == (int)Action.Scissors)
                    || (playerMove == (int)Action.Paper && opponentMove == (int)Action.Rock)
                    || (playerMove == (int)Action.Scissors && opponentMove == (int)Action.Paper))
                {
                    PlayerPoints += (int)Outcome.Win;
                }
                else
                {
                    PlayerPoints += (int)Outcome.Lose;
                }
            }
        }
    }
}