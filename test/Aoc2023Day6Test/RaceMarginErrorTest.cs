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

    [Theory]
    [InlineData("test6.txt", 288)]
    [InlineData("problem6.txt", 303600)]
    public void Given_RacesInFile_Then_ReturnsMarginOfError(string file, int expectedMargin)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var raceReader = new RaceReader(lines);
        var races = raceReader.Races;

        var sut = new RaceMarginError(races);

        var result = sut.ErrorMargin;

        result.Should().Be(expectedMargin);
    }

    [Theory]
    [InlineData("test6.txt", 71503)]
    [InlineData("problem6.txt", 23654842)]
    public void Given_SingleRaceInFile_Then_ReturnsMarginOfError(string file, int expectedMargin)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var raceReader = new SingleRaceReader(lines);
        var races = raceReader.Races;

        var sut = new RaceMarginError(races);

        var result = sut.ErrorMargin;

        result.Should().Be(expectedMargin);
    }
}
