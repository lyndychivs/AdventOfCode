namespace AdventOfCode.Tests.Year2017.Day02
{
    using AdventOfCode.Year2017.Day02;

    using NUnit.Framework;

    [TestFixture]
    public  class Day02Tests
    {
        private const string ExampleFilePath = "Year2017/Day02/example.txt";

        private const string Example2FilePath = "Year2017/Day02/example2.txt";

        private const string InputFilePath = "Year2017/Day02/input.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetCheckSum(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(18));

                Assert.That(new Part1().GetCheckSum(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(30994));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetCheckSum(FileOperations.GetInputFileLines(Example2FilePath)), Is.EqualTo(9));

                Assert.That(new Part2().GetCheckSum(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(233));
            }
        }
    }
}