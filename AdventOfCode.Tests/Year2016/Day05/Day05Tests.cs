namespace AdventOfCode.Tests.Year2016.Day05
{
    using AdventOfCode.Year2016.Day05;

    using NUnit.Framework;

    [TestFixture]
    public class Day05Tests
    {
        private const string Input = "reyedfim";

        [Test]
        public void Day05_Part1()
        {
            Assert.That(new Part1().CalculatePassword(Input), Is.EqualTo("F97C354D"));
        }

        [Test]
        public void Day05_Part2()
        {
            Assert.That(new Part2().CalculatePassword(Input), Is.EqualTo("863DDE27"));
        }
    }
}