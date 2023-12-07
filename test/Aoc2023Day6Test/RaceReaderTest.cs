using Aoc2023Day6;
using FluentAssertions;

namespace Aoc2023Day6Test;

public class RaceReaderTest
{
    [Theory]
    [InlineData("test6.txt")]
    public void Given_ValidRacesSpecs_Then_ReturnsRacesSpecs(string file)
    {
        var lines = File.ReadAllLines($"data/{file}");

        var sut = new RaceReader(lines);
        var races = sut.Races;

        var expectedRaces = new[] { new RaceSpec(7, 9), new RaceSpec(15, 40), new RaceSpec(30, 200) };

        races.Should().HaveCount(3);
        races.Should().BeEquivalentTo(expectedRaces);
    }
}
