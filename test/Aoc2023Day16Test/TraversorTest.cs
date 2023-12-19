using Aoc2023Day16;
using FluentAssertions;

namespace Aoc2023Day16Test;

public class TraversorTest
{
    [Theory]
    [InlineData("data/test.txt", 46)]
    [InlineData("data/problem.txt", 6855L)]
    public void Given_Layout_Then_EnergyWellCalculated(string file, long energized)
    {
        var lines = File.ReadAllLines(file);
        var layout = lines.Select(t => t.ToArray()).ToArray();

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.Energy().Should().Be(energized);
    }

    [Theory]
    [InlineData("data/test.txt", "data/test-energy.txt")]
    public void Given_Layour_Then_EnergyWellPainted(string file, string expected)
    {
        var lines = File.ReadAllLines(file);
        var layout = lines.Select(t => t.ToArray()).ToArray();

        var sut = new Traversor(layout);

        var energy = File.ReadAllText(expected);
        energy = energy.Trim('\r');

        sut.Traverse();

        sut.PaintVisited().Should().Be(energy);
    }

    [Fact]
    public void Given_Layout_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. ".."]
        };

        var sut = new Traversor(layout);

        sut.Traverse();
        sut.PaintVisited().Should().Be("##");
    }

    [Fact]
    public void Given_Layout2_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. "..\\"]
        };

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.PaintVisited().Should().Be("###");
    }

    [Fact]
    public void Given_Layout3_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. "..\\"],
            [.. ".//"],
            [.. "..."]
        };

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.PaintVisited().Should().Be("###\r\n.##\r\n.#.");
    }

    [Fact]
    public void Given_Layout4_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. ".|.."],
            [.. "...."],
            [.. "...."]
        };

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.PaintVisited().Should().Be("##..\r\n.#..\r\n.#..");
    }

    [Fact]
    public void Given_Layout5_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. ".|.."],
            [.. "...."],
            [.. ".-.."]
        };

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.PaintVisited().Should().Be("##..\r\n.#..\r\n####");
    }

    [Fact]
    public void Given_LayoutCycle_Then_Traversed()
    {
        var layout = new char[][]
        {
            [.. ".|-."],
            [.. ".-|."],
            [.. ".-.."]
        };

        var sut = new Traversor(layout);

        sut.Traverse();

        sut.PaintVisited().Should().Be("####\r\n###.\r\n..#.");
    }
}
