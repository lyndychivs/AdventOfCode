namespace AdventOfCode.Tests.Year2015.Day01
{
    using AdventOfCode.Year2015.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFile = "Year2015\\Day01\\input.txt";

        [Test]
        public void Day01_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.CalculateFloor("(())"), Is.EqualTo(0));
                Assert.That(part1.CalculateFloor("()()"), Is.EqualTo(0));

                Assert.That(part1.CalculateFloor("((("), Is.EqualTo(3));
                Assert.That(part1.CalculateFloor("(()(()("), Is.EqualTo(3));
                Assert.That(part1.CalculateFloor("))((((("), Is.EqualTo(3));

                Assert.That(part1.CalculateFloor("())"), Is.EqualTo(-1));
                Assert.That(part1.CalculateFloor("))("), Is.EqualTo(-1));

                Assert.That(part1.CalculateFloor(")))"), Is.EqualTo(-3));
                Assert.That(part1.CalculateFloor(")())())"), Is.EqualTo(-3));

                Assert.That(part1.CalculateFloor(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo(232));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            Assert.That(new Part2().CalculateFirstBasementOccurancePosition(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo(1783));
        }
    }
}
