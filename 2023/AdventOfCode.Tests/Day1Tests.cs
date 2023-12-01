namespace AdventOfCode.Tests
{
    using Day1;
    using NUnit.Framework;

    [TestFixture]
    public class Day1Tests
    {
        [Test]
        public void Day1_Input_ReturnsExepectedValue()
        {
            var expectedResult = 55343;
            var day1 = new Day1();

            var result = day1.GetSumOfCalibrationValues();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}