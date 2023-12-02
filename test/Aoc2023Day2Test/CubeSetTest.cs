using Aoc2023Day2;
using FluentAssertions;

namespace Aoc2023Day2Test;

public class CubeSetTest
{
    private readonly CubeSet _cube567;

    public CubeSetTest()
    {
        _cube567 = new CubeSet(5, 6, 7);
    }

    [Fact]
    public void Given_NewCubeSet_AllColorsZeroed()
    {
        var sut = new CubeSet();

        sut.Red.Should().Be(0);
        sut.Blue.Should().Be(0);
        sut.Green.Should().Be(0);
    }

    [Theory]
    [InlineData(5, 6, 7)]
    [InlineData(1, 16, 97)]
    [InlineData(1, 1, 1)]
    public void Given_NewCubeSet_AllColorsWithTheirValues(int red, int green, int blue)
    {
        var sut = new CubeSet(red, green, blue);

        sut.Red.Should().Be(red);
        sut.Green.Should().Be(green);
        sut.Blue.Should().Be(blue);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 6)]
    [InlineData(4, 5, 6)]
    [InlineData(5, 6, 7)]
    public void Given_IfAllNumbersEqualOrLess_Then_Fits(int red, int green, int blue)
    {
        var otherCubeSet = new CubeSet(red, green, blue);

        var result = otherCubeSet.FitsIn(_cube567);
        
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(8, 8, 8)]
    [InlineData(6, 0, 0)]
    [InlineData(1, 7, 6)]
    [InlineData(4, 5, 8)]
    public void Given_IfAnyNumbersGreater_Then_NoFits(int red, int green, int blue)
    {
        var otherCubeSet = new CubeSet(red, green, blue);

        var result = otherCubeSet.FitsIn(_cube567);
        
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(0, 0, 0, 5, 6, 7)]
    [InlineData(5, 6, 7, 5, 6, 7)]
    [InlineData(9, 0, 0, 9, 6, 7)]
    [InlineData(0, 9, 0, 5, 9, 7)]
    [InlineData(0, 0, 9, 5, 6, 9)]
    [InlineData(11, 10, 9, 11, 10, 9)]
    public void Given_OtherCubeSet_When_Merged_ReturnsNewCubeWithMaxValuesOfEachColor(int red, int green, int blue, int expectedRed, int expectedGreen, int expectedBlue)
    {
        var other = new CubeSet(red, green, blue);

        var max = other.MergeMax(_cube567);

        max.Red.Should().Be(expectedRed);
        max.Green.Should().Be(expectedGreen);
        max.Blue.Should().Be(expectedBlue);

    }
}
