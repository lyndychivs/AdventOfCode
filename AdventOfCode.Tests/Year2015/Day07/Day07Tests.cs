namespace AdventOfCode.Tests.Year2015.Day07
{
    using AdventOfCode.Year2015.Day07;

    using NUnit.Framework;

    [TestFixture]
    public class Day07Tests
    {
        private const string ExampleFile = "Year2015\\Day07\\example.txt";

        private const string InputFile = "Year2015\\Day07\\input.txt";

        [Test]
        public void Day07_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "d"), Is.EqualTo(72));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "e"), Is.EqualTo(507));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "f"), Is.EqualTo(492));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "g"), Is.EqualTo(114));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "h"), Is.EqualTo(65_412));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "i"), Is.EqualTo(65_079));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "x"), Is.EqualTo(123));
                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(ExampleFile), "y"), Is.EqualTo(456));

                Assert.That(part1.GetWireValue(FileOperations.GetInputFileLines(InputFile), "a"), Is.EqualTo(16_076));
            }
        }

        [Test]
        public void Day07_Part2()
        {
            Assert.That(new Part2().GetWireValue(FileOperations.GetInputFileLines(InputFile), "a", 16_076), Is.EqualTo(2_797));
        }
    }
}