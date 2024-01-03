using Aoc2023Day23;
using FluentAssertions;

namespace Aoc2023Day23Test;

public class LongestHikeTest
{
    [Theory]
    [InlineData("data/test.txt", 94)]
    public void Given_KnowMap_When_Traversed_Then_ReturnsStepsForLongestPath(string file, long steps)
    {
        var lines = File.ReadAllLines(file);

        var sut = new LongestHike(lines);

        sut.Traverse();

        sut.Steps.Should().Be(steps);
    }
}