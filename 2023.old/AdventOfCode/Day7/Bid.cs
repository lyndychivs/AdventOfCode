namespace AdventOfCode.Day7
{
    internal class Bid(string input)
    {
        public int Value { get; private set; } = int.Parse(input);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}