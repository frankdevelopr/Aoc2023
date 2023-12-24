using Aoc2023Day20;
using Moq;

namespace Aoc2023Day20Test;

public class BroadcasterTest
{
    [Theory]
    [InlineData(Pulse.Low)]
    [InlineData(Pulse.High)]
    public void Given_Pulse_Then_ItIsBroadcastedToAll(Pulse pulse)
    {
        var receiver1 = new Mock<IPulseReceiver>();
        var receiver2 = new Mock<IPulseReceiver>();

        var sut = new Broadcaster();
        sut.Connect(receiver1.Object);
        sut.Connect(receiver2.Object);

        sut.Receive(pulse, null);

        receiver1.Verify(t => t.Receive(pulse, sut), Times.Once());
        receiver2.Verify(t => t.Receive(pulse, sut), Times.Once());
    }
}