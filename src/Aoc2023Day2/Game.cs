namespace Aoc2023Day2;

public class Game
{
    public int Id { get; set; }
    public CubeSet AcceptedCubeSet { get; set; } = new CubeSet();
    
    public void Add(CubeSet cube)
    {
        AcceptedCubeSet = cube.MergeMax(AcceptedCubeSet);
    }
}
