using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class AcceptedPartsSumerTest
{
    [Theory]
    [InlineData("data/test.txt", 19114L)]
    [InlineData("data/problem.txt", 319295L)]

    public void Given_PartAndWorkflows_Then_ReturnsExpectedSum(string file, long ratingsSum)
    {
        var data = File.ReadAllLines(file);

        var sut = new AcceptedPartsSumer(data);

        var actual = sut.Sum();

        actual.Should().Be(ratingsSum);
    }

    [Theory]
    [InlineData("data/test.txt", 167_409_079_868_000L)]
    public void Given_Workflows_WhenAllCombinationsTo4000_Then_ReturnsExpectedSum(string file, long accepted)
    {
        var data = File.ReadAllLines(file);

        var sut = new AcceptedPartsSumer(data);

        var actual = sut.AcceptedCombinations();

        actual.Should().Be(accepted);
    }
}
