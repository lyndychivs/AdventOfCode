namespace AdventOfCode.Day3
{
    public class Position(int x, int y)
    {
        public int X { get; private set; } = x;
        public int Y { get; private set; } = y;

        public Position[] GetAdjacentPosition()
        {
            return [
                new Position(X - 1, Y - 1),
                new Position(X - 1, Y),
                new Position(X - 1, Y + 1),
                new Position(X, Y - 1),
                new Position(X, Y + 1),
                new Position(X + 1, Y - 1),
                new Position(X + 1, Y),
                new Position(X + 1, Y + 1)];
        }
    }
}