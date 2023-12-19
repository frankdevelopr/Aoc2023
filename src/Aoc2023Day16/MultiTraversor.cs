using System.Collections.Concurrent;

namespace Aoc2023Day16;

public class MultiTraversor
{
    private readonly int _height;
    private readonly int _width;
    private readonly char[][] _layout;
    private readonly ConcurrentBag<long> _result;

    public MultiTraversor(char[][] layout)
    {
        _height = layout.Length;
        _width = layout[0].Length;

        _layout = layout;
        _result = [];
    }

    public void Traverse()
    {
        Parallel.For(0, _width, index =>
        {
            var traversor = new Traversor(_layout);

            traversor.TraverseFrom(0, index, Direction.South);

            _result.Add(traversor.Energy());
        });

        Parallel.For(0, _width, index =>
        {
            var traversor = new Traversor(_layout);

            traversor.TraverseFrom(_height-1, index, Direction.North);

            _result.Add(traversor.Energy());
        });

        Parallel.For(0, _height, index =>
        {
            var traversor = new Traversor(_layout);

            traversor.TraverseFrom(index, 0, Direction.East);

            _result.Add(traversor.Energy());
        });

        Parallel.For(0, _height, index =>
        {
            var traversor = new Traversor(_layout);

            traversor.TraverseFrom(index, _width-1, Direction.West);

            _result.Add(traversor.Energy());
        });
    }

    public long Energy()
    {
        return _result.Max();
    }
}