namespace Aoc2023Day14;

public interface IPlatformSystem
{
    long Calculate();
    long CalculateInternal();
    long Cycle(long cycles);
}