
using FluentAssertions;

namespace Aoc2023Day15Test;

public class HashSumerTest
{
    [Theory]
    [InlineData("data/test.txt", 1320)]
    public void Given_Input_Then_ReturnsExpectedHashSum(string file, long expected)
    {
        var line = File.ReadAllText(file);

        var sut = new HashSumer();

        sut.Sum(line).Should().Be(expected);
    }
}

public class HashSumer
{
    public long Sum(string line)
    {
        throw new NotImplementedException();
    }
}
