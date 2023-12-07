
namespace Aoc2023Day6
{
    public interface IRaceReader
    {
        IEnumerable<RaceSpec> Races { get; }
    }
}