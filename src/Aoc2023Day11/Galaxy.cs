namespace Aoc2023Day11;

public class Galaxy
{
    public int Number { get; set; }
    public Coordinates Coordinates { get; set;}

    public Galaxy(int number, Coordinates coordinates)
    {
        Number = number;
        Coordinates = coordinates;
    }
}
