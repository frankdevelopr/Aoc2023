using Aoc2023Day19;

namespace Aoc2023Day19Test;

public class AcceptedPartsSumerTest
{
    [Theory]
    [InlineData("data/test.txt", 19114L)]
    public void Given_PartAndWorkflows_Then_ReturnsExpectedSum(string file, long ratingsSum)
    {
        var data = File.ReadAllLines(file);

        var sut = new AcceptedPartsSumer(data);

        long a = sut.Sum();

        //sut.Sum().Should().Be(ratingsSum);
    }
}
