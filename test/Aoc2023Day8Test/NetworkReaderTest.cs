using Aoc2023Day8;
using FluentAssertions;

namespace Aoc2023Day8Test;

public class NetworkReaderTest
{
    [Fact]
    //[InlineData("test-llr.txt")]
    public void Given_ValidNetworkAndInstructions_Then_ReturnsExpectedResult()
    {
        var lines = Read("test.txt");

        var reader = new NetworkReader(lines);

        var expectedNetwork = new Network();
        expectedNetwork
          .Add(new Node("AAA", "BBB", "CCC"))
          .Add(new Node("BBB", "DDD", "EEE"))
          .Add(new Node("CCC", "ZZZ", "GGG"))
          .Add(new Node("DDD", "DDD", "DDD"))
          .Add(new Node("EEE", "EEE", "EEE"))
          .Add(new Node("GGG", "GGG", "GGG"))
          .Add(new Node("ZZZ", "ZZZ", "ZZZ"));

        reader.Navigator.Should().BeEquivalentTo(new Navigator("RL"));
        reader.Network.Should().BeEquivalentTo(expectedNetwork);
    }

    [Fact]
    public void Given_ValidNetworkAndInstructions2_Then_ReturnsExpectedResult()
    {
        var lines = Read("test-llr.txt");

        var reader = new NetworkReader(lines);

        var expectedNetwork = new Network();
        expectedNetwork
          .Add(new Node("AAA", "BBB", "BBB"))
          .Add(new Node("BBB", "AAA", "ZZZ"))
          .Add(new Node("ZZZ", "ZZZ", "ZZZ"));

        reader.Navigator.Should().BeEquivalentTo(new Navigator("LLR"));
        reader.Network.Should().BeEquivalentTo(expectedNetwork);
    }

    
    public string[] Read(string file)
    {
        return File.ReadAllLines($"data/{file}");
    }

}
