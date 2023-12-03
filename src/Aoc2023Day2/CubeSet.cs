namespace Aoc2023Day2;

public class CubeSet
{
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;
    public int Blue { get; set; } = 0;

    public CubeSet(int red = 0, int green = 0, int blue = 0)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public bool FitsIn(CubeSet other)
    {
        return Red <= other.Red &&
            Green <= other.Green &&
            Blue <= other.Blue;
    }

    public CubeSet MergeMax(CubeSet other)
    {
        return new CubeSet(int.Max(Red, other.Red), int.Max(Green, other.Green), int.Max(Blue, other.Blue));
    }
}
