namespace AdventOfCode.Year2022.Day02
{
    using System;
    using System.Collections.Generic;

    public class Part2
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
                _ => throw new Exception($"Failed to map Action: {action}")
            };
        }

        private static Outcome MapExpectedOutcome(char outcome)
        {
            return outcome switch
            {
                'X' => Outcome.Lose,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win,
                _ => throw new Exception($"Failed to map Expected Outcome: {outcome}")
            };
        }

        private class Rounds
        {
            public int PlayerPoints { get; set; } = 0;

            public void PlayRound(char opponentAction, char expectedOutcome)
            {
                int opponentMove = MapAction(opponentAction);
                Outcome outcome = MapExpectedOutcome(expectedOutcome);

                PlayerPoints += (int)outcome;

                if (outcome == Outcome.Draw)
                {
                    PlayerPoints += opponentMove;
                    return;
                }

                if (outcome == Outcome.Lose)
                {
                    if (opponentMove == (int)Action.Rock)
                    {
                        PlayerPoints += (int)Action.Scissors;
                    }
                    else if (opponentMove == (int)Action.Paper)
                    {
                        PlayerPoints += (int)Action.Rock;
                    }
                    else
                    {
                        PlayerPoints += (int)Action.Paper;
                    }

                    return;
                }

                if (opponentMove == (int)Action.Rock)
                {
                    PlayerPoints += (int)Action.Paper;
                }
                else if (opponentMove == (int)Action.Paper)
                {
                    PlayerPoints += (int)Action.Scissors;
                }
                else
                {
                    PlayerPoints += (int)Action.Rock;
                }
            }
        }
    }
}