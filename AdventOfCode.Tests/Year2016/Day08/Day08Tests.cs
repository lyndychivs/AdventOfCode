namespace AdventOfCode.Tests.Year2016.Day08
{
    using AdventOfCode.Year2016.Day08;

    using NUnit.Framework;

    [TestFixture]
    public class Day08Tests
    {
        private const string InputFilePath = "Year2016/Day08/input.txt";

        private const string ExampeFilePath = "Year2016/Day08/example.txt";

        [Test]
        public void Day08_Part1_And_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1(7, 3).GetCountOfLitPixelsPerInputs(FileOperations.GetInputFileLines(ExampeFilePath)), Is.EqualTo(6));

                Assert.That(new Part1(50, 6).GetCountOfLitPixelsPerInputs(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(110));
            }
        }
    }
}