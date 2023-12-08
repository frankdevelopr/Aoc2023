using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class PathFinderTest
{
    [Theory]
    [InlineData("test.txt", 2)]
    [InlineData("test-llr.txt", 6)]
    [InlineData("problem.txt", 15517)]
    public void Given_Network_Then_ReturnsStepsNeed(string file, int expectedSteps)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var networkReader = new NetworkReader(lines);

        var sut = new PathFinder(networkReader.Navigator, networkReader.Network);

        sut.Steps.Should().Be(expectedSteps);
    }
}