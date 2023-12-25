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
        sut.Result.Should().Be(expectedLowPulses*expectedHighPulses);
    }

    [Fact]
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

    [Fact]
    public void Given_Then()
    {
        /*
         * broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output
         */

        var br = new Broadcaster("broadcaster");
        var a = new FlipFlop("a");
        var inv = new Conjunction("inv");
        var b = new FlipFlop("b");
        var con = new Conjunction("con");
        var output = new Broadcaster("output");

        br.Connect(a);
        a.Connect(inv).Connect(con);
        // TODO: Connect inv with its inputs
        inv.Connect(b);
        inv.RegisterInput(a);
        b.Connect(con);
        con.Connect(output);
        con.RegisterInput(b);

        var button = new ButtonSystem(br);
        button.Push(4);

        Assert.Fail("Trace is different, fix scenario");
    }
}
