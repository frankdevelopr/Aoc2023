using Aoc2023Day11;
using FluentAssertions;

namespace Aoc2023Day11Test;

public class UniverseTest
{
    [Theory]
    [InlineData("test.txt", "test-expanded.txt")]
    public void Given_Universe_Then_ExpandedAsExpected(string file, string expandedFile)
    {
        var lines = Read(file);
        var expand = Read(expandedFile);

        var sut = new Universe(lines);

        var result = sut.Expanded;

        result.Should().BeEquivalentTo(expand);
    }

    public static string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }
}