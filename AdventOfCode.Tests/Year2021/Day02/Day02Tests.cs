namespace AdventOfCode.Tests.Year2021.Day02
{
    using AdventOfCode.Year2021.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string ExampleFilePath = "Year2021/Day02/example.txt";

        private const string InputFilePath = "Year2021/Day02/input.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetCordsResult(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(150));
                Assert.That(new Part1().GetCordsResult(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(1714950));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetCordsResult(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(900));
                Assert.That(new Part2().GetCordsResult(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(1281977850));
            }
        }
    }
}