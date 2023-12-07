namespace AdventOfCode.Day7
{
    internal class StandardCard (char value) : ICard
    {
        public char Value { get; private set; } = value;

        public int Points
        {
            get
            {
                return Value switch
                {
                    'A' => 14,
                    'K' => 13,
                    'Q' => 12,
                    'J' => 11,
                    'T' => 10,
                    _ => int.Parse(Value.ToString()),
                };
            }
        }
    }
}