using Aoc2023Day20;
using FluentAssertions;
using Moq;

namespace Aoc2023Day20Test;

public class FlipFlopTest
{
    [Fact]
    public void Given_FlipFlop_When_Created_Then_StatusIsOff()
    {
        var sut = new FlipFlop("sut");

        sut.Status.Should().Be(Status.Off);
    }

    [Fact]
    public void Given_FlipFlop_When_LowPulseAndOff_Then_OnAndSendHighPulse()
    {
        var target = new Mock<IPulseReceiver>();

        var sut = new FlipFlop("sut");
        sut.Connect(target.Object);

        sut.Receive(Pulse.Low, null);
        sut.Process();
        sut.Status.Should().Be(Status.On);

        target.Verify(t => t.Receive(Pulse.High, sut), Times.Once());
    }

    [Fact]
    public void Given_FlipFlop_When_LowPulseAndOn_Then_ffAndSendLowPulse()
    {
        var target = new Mock<IPulseReceiver>();

        var sut = new FlipFlop("sut");
        sut.Receive(Pulse.Low, null);
        sut.Process();
        sut.Status.Should().Be(Status.On);

        sut.Connect(target.Object);
        sut.Receive(Pulse.Low, null);
        sut.Process();
        sut.Status.Should().Be(Status.Off);
        target.Verify(t => t.Receive(Pulse.Low, sut), Times.Once());
    }


    [Fact]
    public void Given_FlipFlop_When_HighPulse_Then_NothingHappens()
    {
        var sut = new FlipFlop("sut");

        sut.Receive(Pulse.High, null);

        sut.Status.Should().Be(Status.Off);
    }
}
