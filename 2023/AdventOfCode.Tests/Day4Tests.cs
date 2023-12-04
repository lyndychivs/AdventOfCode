namespace AdventOfCode.Tests
{
    using Day4;

    using NUnit.Framework;

    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void GetScratchCardsTotalPoints_Input_ReturnsExepectedValue()
        {
            var expectedResult = 21088;
            var day4 = new Day4();

            var result = day4.GetScratchCardsTotalPoints();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetTotalCardsLeftAfterWinning_Input_ReturnsExepectedValue()
        {
            var expectedResult = 6874754;
            var day4 = new Day4();

            var result = day4.GetTotalCardsLeftAfterWinning();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}