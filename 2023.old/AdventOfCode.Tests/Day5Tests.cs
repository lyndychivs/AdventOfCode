namespace AdventOfCode.Tests
{
    using Day5;

    using NUnit.Framework;

    [TestFixture]
    public class Day5Tests
    {
        [Test]
        public void GetLowestLocationNumberForSeeds_Input_ReturnsExepectedValue()
        {
            var expectedResult = 403695602;
            var day5 = new Day5();

            var result = day5.GetLowestLocationNumberForSeeds();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetSeedNumberWithLowestLocationNumber_Input_ReturnsExepectedValue()
        {
            var expectedResult = 219529182;
            var day5 = new Day5();

            var result = day5.GetSeedNumberWithLowestLocationNumber();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}