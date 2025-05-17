namespace AdventOfCode.Tests.Year2016.Day07
{
    using AdventOfCode.Year2016.Day07;

    using NUnit.Framework;

    [TestFixture]
    public class Day07Tests
    {
        private const string ExampleFilePath = "Year2016/Day07/example.txt";

        private const string ExampleTwoFilePath = "Year2016/Day07/example2.txt";

        private const string InputFilePath = "Year2016/Day07/input.txt";

        [Test]
        public void Day07_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetCountOfValidIpAddresses(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(2));

                Assert.That(new Part1().GetCountOfValidIpAddresses(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(115));
            }
        }

        [Test]
        public void Day07_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetCountOfValidIpAddresses(FileOperations.GetInputFileLines(ExampleTwoFilePath)), Is.EqualTo(3));

                Assert.That(new Part2().GetCountOfValidIpAddresses(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(231));
            }
        }
    }
}