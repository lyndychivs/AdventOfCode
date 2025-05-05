namespace AdventOfCode.Tests.Year2015.Day07
{
    using AdventOfCode.Year2015.Day07;

    using NUnit.Framework;

    [TestFixture]
    public class Day7Tests
    {
        private const string ExampleInput = "123 -> x\r\n456 -> y\r\nx AND y -> d\r\nx OR y -> e\r\nx LSHIFT 2 -> f\r\ny RSHIFT 2 -> g\r\nNOT x -> h\r\nNOT y -> i";

        [Test]
        public void Day7_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetWireValue(ExampleInput, "d"), Is.EqualTo(72));
                Assert.That(new Part1().GetWireValue(ExampleInput, "e"), Is.EqualTo(507));
                Assert.That(new Part1().GetWireValue(ExampleInput, "f"), Is.EqualTo(492));
                Assert.That(new Part1().GetWireValue(ExampleInput, "g"), Is.EqualTo(114));
                Assert.That(new Part1().GetWireValue(ExampleInput, "h"), Is.EqualTo(65_412));
                Assert.That(new Part1().GetWireValue(ExampleInput, "i"), Is.EqualTo(65_079));
                Assert.That(new Part1().GetWireValue(ExampleInput, "x"), Is.EqualTo(123));
                Assert.That(new Part1().GetWireValue(ExampleInput, "y"), Is.EqualTo(456));

                Assert.That(new Part1().GetWireValue(FileOperations.GetInputFileContent("Year2015\\Day07\\input.txt"), "a"), Is.EqualTo(16_076));
            }
        }

        [Test]
        public void Day7_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetWireValue(FileOperations.GetInputFileContent("Year2015\\Day07\\input.txt"), "a", 16_076), Is.EqualTo(2_797));
            }
        }
    }
}