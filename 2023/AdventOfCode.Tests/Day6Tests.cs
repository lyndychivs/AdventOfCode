namespace AdventOfCode.Tests
{
    using Day6;

    using NUnit.Framework;

    [TestFixture]
    public class Day6Tests
    {
        [Test]
        public void Part1()
        {
            var day6 = new Day6();
            var result = day6.Part1();

            Assert.That(result, Is.EqualTo(2756160));
        }

        [Test]
        public void Part2()
        {
            var day6 = new Day6();
            var result = day6.Part2();

            Assert.That(result, Is.EqualTo(71503));
        }
    }
}