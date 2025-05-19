namespace AdventOfCode.Tests.Year2016.Day10
{
    using AdventOfCode.Year2016.Day10;

    using NUnit.Framework;

    [TestFixture]
    public class Day10Tests
    {
        private const string InputFilePath = "Year2016/Day10/input.txt";

        [Test]
        public void Day10_Part1()
        {
            Assert.That(new Part1().GetIdOfBotWithLowValueAndHighValue(FileOperations.GetInputFileLines(InputFilePath), 17, 61), Is.EqualTo(118));
        }

        [Test]
        public void Day10_Part2()
        {
            Assert.That(new Part2().GetValuesOfFirstThreeOutputsMultipled(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(143153));
        }
    }
}