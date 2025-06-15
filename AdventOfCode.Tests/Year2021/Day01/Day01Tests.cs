namespace AdventOfCode.Tests.Year2021.Day01
{
    using AdventOfCode.Year2021.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string ExampleFilePath = "Year2021/Day01/example.txt";

        private const string InputFilePath = "Year2021/Day01/input.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().CountMeasurementIncreases(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(7));
                Assert.That(new Part1().CountMeasurementIncreases(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(1139));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().CountMeasurementIncreases(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(5));
                Assert.That(new Part2().CountMeasurementIncreases(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(1103));
            }
        }
    }
}
