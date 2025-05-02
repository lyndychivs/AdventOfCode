namespace AdventOfCode.Tests
{
    using Day7;

    using NUnit.Framework;

    [TestFixture]
    public class Day7Tests
    {
        [Test]
        public void Part1()
        {
            var day7 = new Day7();

            var result = day7.Part1();

            Assert.That(result, Is.EqualTo(250602641));
        }

        [Test]
        public void Part2()
        {
            var day7 = new Day7();

            var result = day7.Part2();

            Assert.That(result, Is.EqualTo(251037509));
        }
    }
}