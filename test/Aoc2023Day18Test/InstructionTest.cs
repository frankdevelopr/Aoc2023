using Aoc2023Day18;
using FluentAssertions;

namespace Aoc2023Day18Test;

public class InstructionTest
{
    /*
    
    #0dc571 = D 56407
    #5713f0 = R 356671
    #d2c081 = D 863240
    #59c680 = R 367720
    #411b91 = D 266681
    #8ceee2 = L 577262
    #caa173 = U 829975
    #1b58a2 = L 112010
    #caa171 = D 829975
    #7807d2 = L 491645
    #a77fa3 = U 686074
    #015232 = L 5411
    #7a21e3 = U 500254
    */


    [Theory]
    [InlineData("R 6 (#70c710)", 'R', 461937L)]
    [InlineData("D 5 (#0dc571)", 'D', 56407)]
    [InlineData("L 2 (#5713f0)", 'R', 356671)]
    [InlineData("D 2 (#d2c081)", 'D', 863240)]
    [InlineData("R 2 (#59c680)", 'R', 367720)]
    [InlineData("D 2 (#411b91)", 'D', 266681)]
    [InlineData("L 5 (#8ceee2)", 'L', 577262)]
    [InlineData("U 2 (#caa173)", 'U', 829975)]
    [InlineData("L 1 (#1b58a2)", 'L', 112010)]
    [InlineData("U 2 (#caa171)", 'D', 829975)]
    [InlineData("R 2 (#7807d2)", 'L', 491645)]
    [InlineData("U 3 (#a77fa3)", 'U', 686074)]
    [InlineData("L 2 (#015232)", 'L', 5411)]
    [InlineData("U 2 (#7a21e3)", 'U', 500254)]
    public void Given_Instruction_Then_ParseExpectedData(string line, char direction, long positions)
    {
        var sut = new Instruction(line);

        sut.Direction.Should().Be(direction);
        sut.Positions.Should().Be(positions);
    }
}
