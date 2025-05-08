namespace AdventOfCode.Tests.Year2016.Day02
{
    using AdventOfCode.Year2016.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string InputFilePath = "Year2016/Day02/input.txt";

        private const string ExampleFilePath = "Year2016/Day02/example.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetCodes(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo("1985"));

                Assert.That(new Part1().GetCodes(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo("14894"));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetCodes(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo("5DB3"));

                Assert.That(new Part2().GetCodes(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo("26B96"));
            }
        }
    }
}