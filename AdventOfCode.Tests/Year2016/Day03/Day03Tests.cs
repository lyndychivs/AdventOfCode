namespace AdventOfCode.Tests.Year2016.Day03
{
    using AdventOfCode.Year2016.Day03;

    using NUnit.Framework;

    [TestFixture]
    public class Day03Tests
    {
        private const string InputFilePath = "Year2016/Day03/input.txt";

        [Test]
        public void Day03_Part1()
        {
            Assert.That(new Part1().GetValidTriangleCount(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(983));
        }

        [Test]
        public void Day03_Part2()
        {
            Assert.That(new Part2().GetValidTriangleCount([.. FileOperations.GetInputFileLines(InputFilePath)]), Is.EqualTo(1836));
        }
    }
}