namespace Aoc2023Day1;

internal class Program
{
    static void Main(string[] args)
    {
        var calibrator = new Calibrator();

        var lines = File.ReadAllLines("input3.txt");

        var total = calibrator.Calibrate(lines);

        Console.WriteLine($"Total is: {total}");
    }
}