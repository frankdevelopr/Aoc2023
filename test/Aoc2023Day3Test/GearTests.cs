using Aoc2023Day3;
using FluentAssertions;

namespace Aoc2023Day3Test;

public class GearTests
{
    private static readonly IEnumerable<NumberFound> NoNumbers = Enumerable.Empty<NumberFound>();

    [Theory]
    [InlineData("2*3", 1, 6)]
    [InlineData("..10*41..12", 4, 410)]
    [InlineData("3*4*5", 1, 12)]
    [InlineData("3*4*5", 3, 20)]
    public void Given_InlineNumbers_When_ItsGear_ReturnItsValue(string line, int gearPosition, long expectedValue)
    {
        var numFinder = new NumberFinder();
        var numbers = numFinder.Find(line);

        var sut = new Gear(gearPosition);

        sut.LookForAdjacents(numbers, NoNumbers, NoNumbers);

        sut.Result().Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("3**4*.5", 1)]
    [InlineData("3**4*.5", 3)]
    [InlineData("**1**2", 1)]
    public void Given_NoRealGear_ReturnZero(string line, int gearPosition)
    {
        var numFinder = new NumberFinder();
        var numbers = numFinder.Find(line);

        var sut = new Gear(gearPosition);

        sut.LookForAdjacents(numbers, NoNumbers, NoNumbers);

        sut.Result().Should().Be(0);
    }
}
