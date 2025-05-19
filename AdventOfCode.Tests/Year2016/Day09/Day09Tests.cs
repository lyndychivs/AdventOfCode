namespace AdventOfCode.Tests.Year2016.Day09
{
    using System.Numerics;

    using AdventOfCode.Year2016.Day09;

    using NUnit.Framework;

    [TestFixture]
    public class Day09Tests
    {
        private const string ExampleFilePath = "Year2016/Day09/example.txt";

        private const string InputFilePath = "Year2016/Day09/input.txt";

        [Test]
        public void Day09_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetDecompressedLength(FileOperations.GetInputFileContent(ExampleFilePath)), Is.EqualTo(67));

                Assert.That(new Part1().GetDecompressedLength(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(70186));
            }
        }

        [Test]
        public void Day09_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetDecompressedLength("X(8x2)(3x3)ABCY"), Is.EqualTo((BigInteger)20));

                Assert.That(new Part2().GetDecompressedLength("(27x12)(20x12)(13x14)(7x10)(1x12)A"), Is.EqualTo((BigInteger)241920));

                Assert.That(new Part2().GetDecompressedLength("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN"), Is.EqualTo((BigInteger)445));

                Assert.That(new Part2().GetDecompressedLength(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo((BigInteger)10915059201));
            }
        }
    }
}