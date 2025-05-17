namespace AdventOfCode.Tests.Year2015.Day10
{
    using AdventOfCode.Year2015.Day10;

    using NUnit.Framework;

    [TestFixture]
    public class Day10Tests
    {
        private const string Input = "1321131112";

        [Test]
        public void Day10_Part1()
        {
            Assert.That(new Part1().Solve(Input), Is.EqualTo(492982));
        }

        [Test]
        public void Day10_Part2()
        {
            Assert.That(new Part2().Solve(Input), Is.EqualTo(6989950));
        }
    }
}