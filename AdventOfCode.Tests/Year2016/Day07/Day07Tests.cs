namespace AdventOfCode.Tests.Year2016.Day07
{
    using AdventOfCode.Year2016.Day07;

    using NUnit.Framework;

    [TestFixture]
    public class Day07Tests
    {
        private const string ExampleFilePath = "Year2016/Day07/example.txt";

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
    }
}