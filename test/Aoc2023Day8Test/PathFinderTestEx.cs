using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class PathFinderTestEx
{
    [Theory]
    [InlineData("test-multiple.txt", 6)]
    //[InlineData("problem.txt", 15517)]
    public void Given_NetworkWithMultipleStarts_Then_ReturnsStepsNeed(string file, int expectedSteps)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var networkReader = new NetworkReaderEx(lines);

        var sut = new PathFinderEx(networkReader.Navigator, networkReader.Network);

        sut.FindMultiple().Should().Be(expectedSteps);
    }
}
