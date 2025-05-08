namespace AdventOfCode.Year2016.Day01
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        public int GetDistanceFromFirstPositionVisitedTwice(string inputs)
        {
            var position = new Position();

            List<Action> actions = GetActions(inputs);

            foreach (Action action in actions)
            {
                bool isPositionKnown = position.ActOn(action);

                if (isPositionKnown)
                {
                    return GetDistanceFrom(position);
                }
            }

            return GetDistanceFrom(position);
        }

        private int GetDistanceFrom(Position position)
        {
            return Math.Abs(position.X) + Math.Abs(position.Y);
        }

        private List<Action> GetActions(string inputs)
        {
            var actions = new List<Action>();

            foreach (string input in inputs.Split(", "))
            {
                Direction direction = input[0] switch
                {
                    'L' => Direction.Left,
                    'R' => Direction.Right,
                    _ => throw new ArgumentException($"Invalid {nameof(input)}: {input}")
                };

                if (!int.TryParse(input[1..], out int distance))
                {
                    throw new ArgumentException($"Invalid {nameof(input)}: {input}");
                }

                actions.Add(new Action(direction, distance));
            }

            return actions;
        }

        private class Action(Direction direction, int distance)
        {
            public Direction Direction { get; } = direction;

            public int Distance { get; } = distance;
        }

        private enum Direction
        {
            Left,
            Right,
        }

        private class Position
        {
            private readonly HashSet<(int, int)> _visitedPositions = [];

            private Facing _facing = Facing.North;

            public int X { get; private set; } = 0;

            public int Y { get; private set; } = 0;

            public Position()
            {
                _ = _visitedPositions.Add((X, Y));
            }

            public bool ActOn(Action action)
            {
                Turn(action.Direction);

                for (int i = 1; i <= action.Distance; i++)
                {
                    Move(1);

                    if (!_visitedPositions.Add((X, Y)))
                    {
                        return true;
                    }
                }

                return false;
            }

            private void Move(int distance)
            {
                switch (_facing)
                {
                    case Facing.North:
                        Y += distance;
                        break;

                    case Facing.East:
                        X += distance;
                        break;

                    case Facing.South:
                        Y -= distance;
                        break;

                    case Facing.West:
                        X -= distance;
                        break;
                }
            }

            private void Turn(Direction direction)
            {
                if (direction == Direction.Right)
                {
                    if ((int)_facing == 3)
                    {
                        _facing = (Facing)0;
                    }
                    else
                    {
                        _facing++;
                    }
                }
                else
                {
                    if ((int)_facing == 0)
                    {
                        _facing = (Facing)3;
                    }
                    else
                    {
                        _facing--;
                    }
                }
            }

            private enum Facing
            {
                North,
                East,
                South,
                West,
            }
        }
    }
}