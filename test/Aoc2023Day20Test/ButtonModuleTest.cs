using Aoc2023Day20;
using FluentAssertions;

namespace Aoc2023Day20Test;

public class ButtonModuleTest
{
    [Theory]
    [InlineData("data/test.txt", 1, 32, 8, 4)]
    [InlineData("data/test.txt", 1000, 32000000, 8000, 4000)]
    [InlineData("data/test-2.txt", 1000, 11687500L, 4250, 2750)]
    [InlineData("data/problem.txt", 1000, 886347020L, 18122L, 48910L)]

    public void Given_Button_When_PushedTimes_Then_ReturnsNumberOfPulses(string file, int pushed, long rank, long expectedLowPulses, long expectedHighPulses)
    {
        var lines = File.ReadAllLines(file);

        var sut = new ButtonSystem(lines);

        sut.Push(pushed);

        sut.Rank.Should().Be(rank);
        sut.LowPulses.Should().Be(expectedLowPulses);
        sut.HighPulses.Should().Be(expectedHighPulses);
    }

    //[Fact]
    public void Given_TestScenario_Then_WorksAsExpected()
    {
        var broadCaster = new Broadcaster("broadcaster");
        var a = new FlipFlop("a");
        var b = new FlipFlop("b");
        var c = new FlipFlop("c");
        var inv = new Conjunction("inv");
        broadCaster.Connect(a).Connect(b).Connect(c);
        a.Connect(b);
        b.Connect(c);
        c.Connect(inv);
        inv.Connect(a);


        var sut = new ButtonSystem(broadCaster);

        sut.Push(1);

        //broadCaster.Receive(Pulse.Low, null);
    }

    //[Fact]
    public void Given_Then()
    {
        /* broadcaster -> a
           %a -> inv, con
           &inv -> b
           %b -> con
           &con -> output */

        var br = new Broadcaster("broadcaster");
        var a = new FlipFlop("a");
        var inv = new Conjunction("inv");
        var b = new FlipFlop("b");
        var con = new Conjunction("con");
        var output = new Broadcaster("output");

        br.Connect(a);
        a.Connect(inv).Connect(con);
        inv.Connect(b);
        inv.RegisterInput(a);
        b.Connect(con);
        con.Connect(output);
        con.RegisterInput(b);

        var button = new ButtonSystem(br);
        button.Push(4);

        button.LowPulses.Should().Be(17);
        button.HighPulses.Should().Be(11);
    }
}
