using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class GearFinderTests
{
    private readonly NumberFinder _numFinder;
    private readonly GearFinder _sut;

    public GearFinderTests()
    {
        _numFinder = new NumberFinder();
        _sut = new GearFinder();
    }

    [Theory]
    [InlineData("...*...*", 2)]
    [InlineData("2*3*4", 2)]
    [InlineData("...", 0)]
    public void Given_TextWithGears_Then_FindsThemAll(string line, int expectedGears)
    {
        var result = _sut.Find(line, string.Empty, string.Empty);

        result.Should().HaveCount(expectedGears);
    }
}
