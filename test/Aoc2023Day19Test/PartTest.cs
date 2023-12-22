using Aoc2023Day19;
using FluentAssertions;

namespace Aoc2023Day19Test;

public class PartTest
{
    [Fact]
    public void Given_Part_When_Rated_Then_ReturnsSumOfXmas()
    {
        var x = 1;
        var m = 20;
        var a = 300;
        var s = 4000;

        var sut = new Part(1, 20, 300, 4000);

        sut.Rating.Should().Be(4321);
    }

    [Fact]
    public void Given_Part_Then_ValuesAsExpected()
    {
        var x = 1;
        var m = 20;
        var a = 300;
        var s = 4000;

        var sut = new Part(x, m, a, s);

        sut.X.Should().Be(x);
        sut.M.Should().Be(m);
        sut.A.Should().Be(a);
        sut.S.Should().Be(s);
    }
}