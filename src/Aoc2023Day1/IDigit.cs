namespace Aoc2023Day1
{
    public interface IDigit
    {
        bool IsDigit(string text, out int value);
        bool ContainsDigit(string textWithNumber, out int value);
    }
}