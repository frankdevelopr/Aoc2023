using Aoc2023Day20;
using Moq;

namespace Aoc2023Day20Test;

public class ConjunctionTest
{
    private readonly FlipFlop _input;
    private readonly FlipFlop _input2;
    private readonly Mock<IPulseReceiver> _output;
    private readonly Conjunction _sut;

    /* Conjunction modules (prefix &) remember the type of the most recent pulse received from each of their connected input modules; they initially default to remembering a low pulse for each input. When a pulse is received, the conjunction module first updates its memory for that input. Then, if it remembers high pulses for all inputs, it sends a low pulse; otherwise, it sends a high pulse. */

    public ConjunctionTest()
    {
        _input = new FlipFlop();
        _input2 = new FlipFlop();
        _output = new Mock<IPulseReceiver>();

        _sut = new Conjunction();
        _sut.RegisterInput(_input);
        _sut.RegisterInput(_input2);
        _sut.Connect(_output.Object);
    }

    [Fact]
    public void Given_Conjunction_When_AnyModulesLow_Then_SendHigh()
    {
        _sut.Receive(Pulse.High, _input);

        _output.Verify(t => t.Receive(Pulse.High, _sut), Times.Once());
    }

    [Fact]
    public void Given_Conjunction_When_AllModulesHigh_Then_SendLow()
    {
        _sut.Receive(Pulse.High, _input);
        _output.Invocations.Clear();
        _sut.Receive(Pulse.High, _input2);

        _output.Verify(t => t.Receive(Pulse.Low, _sut), Times.Once());
    }

    [Fact]
    public void Given_Conjunction_When_AllModulesHighAndBackOneLow_Then_SendHigh()
    {
        _sut.Receive(Pulse.High, _input);
        _sut.Receive(Pulse.High, _input2);
        _output.Invocations.Clear();
        _sut.Receive(Pulse.Low, _input);

        _output.Verify(t => t.Receive(Pulse.High, _sut), Times.Once());
    }
}
