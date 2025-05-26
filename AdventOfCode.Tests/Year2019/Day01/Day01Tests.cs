namespace AdventOfCode.Tests.Year2019.Day01
{
    using AdventOfCode.Year2019.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2019/Day01/input.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetSumOfFuelRequirements(["12"]), Is.EqualTo(2));
                Assert.That(new Part1().GetSumOfFuelRequirements(["14"]), Is.EqualTo(2));
                Assert.That(new Part1().GetSumOfFuelRequirements(["1969"]), Is.EqualTo(654));
                Assert.That(new Part1().GetSumOfFuelRequirements(["100756"]), Is.EqualTo(33583));

                Assert.That(new Part1().GetSumOfFuelRequirements(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(3317100));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetSumOfFuelRequirements(["14"]), Is.EqualTo(2));
                Assert.That(new Part2().GetSumOfFuelRequirements(["1969"]), Is.EqualTo(966));
                Assert.That(new Part2().GetSumOfFuelRequirements(["100756"]), Is.EqualTo(50346));

                Assert.That(new Part2().GetSumOfFuelRequirements(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(4972784));
            }
        }
    }
}