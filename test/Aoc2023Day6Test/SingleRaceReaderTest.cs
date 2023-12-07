using Aoc2023Day6;
using FluentAssertions;

namespace Aoc2023Day6Test;

public class SingleRaceReaderTest
{
    [Theory]
    [InlineData("test6.txt")]
    public void Given_ValidRacesSpecs_Then_ReturnsRaceSpecs(string file)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var sut = new SingleRaceReader(lines);

        sut.Races.Should().ContainSingle();
        var race = sut.Races.Single();

        race.Should().BeEquivalentTo(new RaceSpec(71530, 940200));
    }
}
