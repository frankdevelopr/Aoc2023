using Aoc2023Day15;
using FluentAssertions;

namespace Aoc2023Day15Test;

public class HashTest
{
    [Theory]
    [InlineData("HASH", 52)]
    public void Given_String_Then_ReturnsExpectedHash(string hash, long expected)
    {
        var sut = new Hash();

        sut.Calculate(hash).Should().Be(expected);
    }
}
