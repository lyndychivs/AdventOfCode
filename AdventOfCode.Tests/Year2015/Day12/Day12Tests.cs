namespace AdventOfCode.Tests.Year2015.Day12
{
    using AdventOfCode.Year2015.Day12;

    using NUnit.Framework;

    [TestFixture]
    public class Day12Tests
    {
        private const string InputFilePath = "Year2015/Day12/input.txt";

        [Test]
        public void Day12_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().CalculateSumOfJson("[1,2,3]"), Is.EqualTo(6));
                Assert.That(new Part1().CalculateSumOfJson("{\"a\":2,\"b\":4}"), Is.EqualTo(6));

                Assert.That(new Part1().CalculateSumOfJson("[[[3]]]"), Is.EqualTo(3));
                Assert.That(new Part1().CalculateSumOfJson("{\"a\":{\"b\":4},\"c\":-1}"), Is.EqualTo(3));

                Assert.That(new Part1().CalculateSumOfJson("{\"a\":[-1,1]}"), Is.EqualTo(0));
                Assert.That(new Part1().CalculateSumOfJson("[-1,{\"a\":1}]"), Is.EqualTo(0));

                Assert.That(new Part1().CalculateSumOfJson("[]"), Is.EqualTo(0));
                Assert.That(new Part1().CalculateSumOfJson("{}"), Is.EqualTo(0));

                Assert.That(new Part1().CalculateSumOfJson(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(119433));
            }
        }

        [Test]
        public void Day12_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().CalculateSumOfJsonExcludingRed("[1,2,3]"), Is.EqualTo(6));
                Assert.That(new Part2().CalculateSumOfJsonExcludingRed("[1,{\"c\":\"red\",\"b\":2},3]"), Is.EqualTo(4));
                Assert.That(new Part2().CalculateSumOfJsonExcludingRed("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}"), Is.EqualTo(0));
                Assert.That(new Part2().CalculateSumOfJsonExcludingRed("[1,\"red\",5]"), Is.EqualTo(6));

                Assert.That(new Part2().CalculateSumOfJsonExcludingRed(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(68466));
            }
        }
    }
}