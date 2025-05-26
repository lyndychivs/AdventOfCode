namespace AdventOfCode.Tests.Year2019.Day02
{
    using AdventOfCode.Year2019.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string InputFilePath = "Year2019/Day02/input.txt";

        [Test]
        public void Day02_Part1()
        {
            Assert.That(new Part1().Solve(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo("2782414"));
        }

        [Test]
        public void Day02_Part2()
        {
            Assert.That(new Part2().Solve(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo("9820"));
        }
    }
}