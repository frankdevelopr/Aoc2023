using Aoc2023Day20;
using FluentAssertions;

namespace Aoc2023Day20Test;

public class ButtonModuleTest
{
    [Theory]
    [InlineData("data/test.txt", 1000, 8000, 4000)]
    [InlineData("data/test-2.txt", 1000, 4250, 2750)]
    public void Given_Button_When_PushedTimes_Then_ReturnsNumberOfPulses(string file, int pushed, long expectedLowPulses, long expectedHighPulses)
    {
        var lines = File.ReadAllLines(file);

        var sut = new ButtonSystem(lines);

        sut.Push(pushed);

        sut.LowPulses.Should().Be(expectedLowPulses);
        sut.HighPulses.Should().Be(expectedHighPulses);
        sut.Result.Should().Be(expectedLowPulses*expectedHighPulses)
    }
}