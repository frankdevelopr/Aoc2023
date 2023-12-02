namespace Aoc2023Day2;

public class Game
{
    public int Id { get; set; }
    public CubeSet AcceptedCubeSet { get; set; } = new CubeSet();

    public Game()
    {
    }

    public Game(int id, CubeSet acceptedCubeSet)
    {
        Id = id;
        AcceptedCubeSet = acceptedCubeSet;
    }

    public Game Add(CubeSet cube)
    {
        AcceptedCubeSet = cube.MergeMax(AcceptedCubeSet);

        return this;
    }
}
