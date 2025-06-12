namespace AdventOfCode.Tests.Year2020.Day01
{
    using AdventOfCode.Year2020.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2020/Day01/input.txt";

        private const string ExampleFilePath = "Year2020/Day01/example.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().FindProductOfTwoValues(FileOperations.GetInputFileLines(ExampleFilePath), 2020), Is.EqualTo(514579));
                Assert.That(new Part1().FindProductOfTwoValues(FileOperations.GetInputFileLines(InputFilePath), 2020), Is.EqualTo(1015476));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().FindProductOfTwoValues(FileOperations.GetInputFileLines(ExampleFilePath), 2020), Is.EqualTo(241861950));
                Assert.That(new Part2().FindProductOfTwoValues(FileOperations.GetInputFileLines(InputFilePath), 2020), Is.EqualTo(200878544));
            }
        }
    }
}