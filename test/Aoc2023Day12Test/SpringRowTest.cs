using Aoc2023Day12;
using FluentAssertions;

namespace Aoc2023Day12Test;

public class SpringRowTest
{
    [Theory]
    [InlineData("#", "1")]
    [InlineData("#.#.###", "1,1,3")]
    [InlineData(".#...#....###.", "1,1,3")]
    [InlineData(".#.###.#.######", "1,3,1,6")]
    [InlineData("####.#...#...", "4,1,1")]
    [InlineData("#....######..#####.", "1,6,5")]
    [InlineData(".###.##....#", "3,2,1")]
    public void Given_ValidSpring_Then_ReturnsIsSolution(string springRow, string groupsTxt)
    {
        var groups = Parse(groupsTxt);

        var result = SpringRow.IsSolution(springRow, groups);

        result.Should().BeTrue();
    }

    private static List<int> Parse(string numbers)
    {
        var parsed = numbers.Trim().Split(",")
            .Where(t => !string.IsNullOrEmpty(t))
            .Select(i => int.Parse(i.Trim()));

        return parsed.ToList();
    }
}