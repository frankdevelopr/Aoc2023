using Aoc2023Day6;
using FluentAssertions;

namespace Aoc2023Day6Test;

public class RaceMarginErrorTest
{
    [Fact]
    public void Given_Races_Then_ReturnsMarginOfError()
    {
        var sut = new RaceMarginError([new RaceSpec(7, 9), new RaceSpec(15, 40), new RaceSpec(30, 200)]);

        sut.ErrorMargin.Should().Be(288);
    }
}
