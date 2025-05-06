namespace AdventOfCode.Tests.Year2015.Day06
{
    using AdventOfCode.Year2015.Day06;

    using NUnit.Framework;

    [TestFixture]
    public class Day6Tests
    {
        private const string InputFile = "Year2015\\Day06\\input.txt";

        [Test]
        public void Day6_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetTotalLightsOnFromInstructions([ "turn on 0,0 through 999,999" ]), Is.EqualTo(1_000_000));
                Assert.That(new Part1().GetTotalLightsOnFromInstructions([ "toggle 0,0 through 999,0" ]), Is.EqualTo(1_000));
                Assert.That(new Part1().GetTotalLightsOnFromInstructions([ "turn on 499,499 through 500,500" ]), Is.EqualTo(4));

                Assert.That(new Part1().GetTotalLightsOnFromInstructions(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(569_999));
            }
        }

        [Test]
        public void Day6_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetTotalLightsBrightnessCountFromInstructions([ "turn on 0,0 through 0,0" ]), Is.EqualTo(1));
                Assert.That(new Part2().GetTotalLightsBrightnessCountFromInstructions([ "toggle 0,0 through 999,999" ]), Is.EqualTo(2_000_000));

                Assert.That(new Part2().GetTotalLightsBrightnessCountFromInstructions(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(17_836_115));
            }
        }
    }
}