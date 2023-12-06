using Aoc2023Day5;
using FluentAssertions;

namespace Aoc2023Day5Test;

public class MapReaderTest
{
    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_SeedsParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedSeeds = new long[] { 79, 14, 55, 13 };
        sut.Seeds.Should().HaveCount(4);
        sut.Seeds.Should().BeEquivalentTo(expectedSeeds);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_SoilRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet([new Rule(50, 98, 2), new Rule(52, 50, 48)], "seed-to-soil");

        sut.ToSoil.Should().BeEquivalentTo(expectedRuleset);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_FertilizerRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet([new Rule(0, 15, 37), new Rule(37, 52, 2), new Rule(39, 0, 15)], "soil-to-fertilizer");

        sut.ToFertilizer.Should().BeEquivalentTo(expectedRuleset);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_WaterRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet(
            [new Rule(49, 53, 8),
             new Rule( 0, 11, 42),
             new Rule(42, 0 ,  7),
             new Rule(57, 7 ,  4),], "fertilizer-to-water");

        sut.ToWater.Should().BeEquivalentTo(expectedRuleset);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_LightRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet(
            [new Rule(88, 18, 7),
             new Rule(18, 25, 70)], "water-to-light");

        sut.ToLight.Should().BeEquivalentTo(expectedRuleset);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_TemperatureRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet(
            [new Rule(45, 77, 23),
             new Rule(81, 45, 19),
             new Rule(68, 64, 13)], "light-to-temperature");

        sut.ToTemp.Should().BeEquivalentTo(expectedRuleset);
    }

    
    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_HumidityRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet(
            [new Rule(0, 69,  1),
             new Rule(1,  0, 69)], "temperature-to-humidity");

        sut.ToHumidity.Should().BeEquivalentTo(expectedRuleset);
    }

    [Theory]
    [InlineData("test5.txt")]
    public void Given_ValidMap_Then_LocationRuleSetParsedCorrectly(string file)
    {
        var lines = ReadFile(file);

        var sut = new MapReader(lines);

        var expectedRuleset = new RuleSet(
            [new Rule(60, 56, 37),
             new Rule(56, 93, 4)], "humidity-to-location");

        sut.ToLocation.Should().BeEquivalentTo(expectedRuleset);
    }

    private string[] ReadFile(string fileName)
    {
        var lines = File.ReadAllLines($"data/{fileName}");

        return lines;
    }

}
