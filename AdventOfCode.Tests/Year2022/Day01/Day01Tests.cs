namespace AdventOfCode.Tests.Year2022.Day01
{
    using AdventOfCode.Year2022.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2022/Day01/input.txt";

        private const string ExampleFilePath = "Year2022/Day01/example.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().FindElfWithMostCalories(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(24000));
                Assert.That(new Part1().FindElfWithMostCalories(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(71471));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetTopThreeElfCalories(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(45000));
                Assert.That(new Part2().GetTopThreeElfCalories(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(211189));
            }
        }
    }
}