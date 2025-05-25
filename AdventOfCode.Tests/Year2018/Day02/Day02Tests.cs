namespace AdventOfCode.Tests.Year2018.Day02
{
    using AdventOfCode.Year2018.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string InputFilePath = "Year2018/Day02/input.txt";

        private const string ExampleFilePath = "Year2018/Day02/example.txt";

        private const string Example2FilePath = "Year2018/Day02/example2.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetChecksumForListOfBoxIds(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(12));

                Assert.That(new Part1().GetChecksumForListOfBoxIds(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(6474));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetCommonLettersBetweenTwoCorrectBoxIds(FileOperations.GetInputFileLines(Example2FilePath)), Is.EqualTo("fgij"));

                Assert.That(new Part2().GetCommonLettersBetweenTwoCorrectBoxIds(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo("mxhwoglxgeauywfkztndcvjqr"));
            }
        }
    }
}