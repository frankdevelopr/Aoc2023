
namespace Aoc2023Day14
{
    public interface IPlatformTilt
    {
        IEnumerable<string> Platform { get; }

        void TiltNorth();
    }
}