namespace Aoc2023Day12;

public class Combinator<T>
{
    public int GroupSize { get; }

    private readonly IEnumerable<T> _elements;
    private readonly long _numElements;

    public Combinator(IEnumerable<T> elements, int groupSize)
    {
        _elements = elements;
        _numElements = _elements.Count();
        GroupSize = groupSize;
    }

    public long Combinations()
    {
        // n! / r! (n-r)!
        return Factorial(_numElements) / (Factorial(GroupSize) * Factorial(_numElements - GroupSize));
    }

    public IEnumerable<IEnumerable<T>> Combine()
    {
        return CombineInternal(_elements, GroupSize);
    }

    private IEnumerable<IEnumerable<T>> CombineInternal(IEnumerable<T> elements, int count)
    {
        var i = 0;

        foreach (var element in elements)
        {
            if (count == 1)
                yield return new T[] { element };

            foreach (var result in CombineInternal(elements.Skip(i+1), count-1))
            {
                yield return new T[] { element }.Concat(result);
            }

            i++;
        }
    }

    private long Factorial(long value)
    {
        var result = 1L;

        for (var i = 2; i <= value; ++i)
        {
            result *= i;
        }

        return result;
    }
}

