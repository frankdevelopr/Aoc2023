using Aoc2023Day8;

namespace Aoc2023Day8Test;

public class PathFinderTest
{
    [Theory]
    [InlineData("test.txt", 2)]
    [InlineData("test-llr.txt", 6)]
    public void Given_Network_Then_ReturnsStepsNeed(string file, int expectedSteps)
    {
        var lines = File.ReadAllLines($"data/{file}");

        /*var networkReader = new NetworkReader(lines);

        var sut = new PathFinder(networkReader);

        sut.Steps.Should().Be(expectedSteps);*/
    }
}