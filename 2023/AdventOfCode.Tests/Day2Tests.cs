namespace AdventOfCode.Tests
{
    using System.Collections.Generic;

    using Day2;
    using NUnit.Framework;

    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void DetermineSumOfPossibleGameIds_Input_ReturnsExepectedValue()
        {
            var input = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };
            var expectedResult = 2512;
            var day2 = new Day2();

            var result = day2.DetermineSumOfPossibleGameIds(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalcuateEachGamesPowerAndGetSum_Input_ReturnsExepectedValue()
        {
            var input = new List<string>
            {
                "red", "green", "blue"
            };
            var expectedResult = 67335;
            var day2 = new Day2();

            var result = day2.CalcuateEachGamesPowerAndGetSum(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}