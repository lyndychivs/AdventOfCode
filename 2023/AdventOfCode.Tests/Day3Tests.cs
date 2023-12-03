namespace AdventOfCode.Tests
{
    using Day3;

    using NUnit.Framework;

    [TestFixture]
    public class Day3Tests
    {
        [Test]
        public void GetSumOfAllEnginePartNumbers_Input_ReturnsExepectedValue()
        {
            var expectedResult = 557705;
            var day3 = new Day3();

            var result = day3.GetSumOfAllEnginePartNumbers();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetSumOfAllGearRatios_Input_ReturnsExepectedValue()
        {
            var expectedResult = 84266818;
            var day3 = new Day3();

            var result = day3.GetSumOfAllGearRatios();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}