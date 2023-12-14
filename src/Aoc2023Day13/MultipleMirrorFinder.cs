using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2023Day13;

public class MultipleMirrorFinder
{
    public IEnumerable<string> Patterns { get; }

    public MultipleMirrorFinder(string lines)
    {
        var patterns = lines.Split(Environment.NewLine+Environment.NewLine);
        Patterns = patterns.Select(t => t.Trim());
    }

    public long Calculate()
    {
        var results = new ConcurrentBag<long>();

        Parallel.ForEach(Patterns, pattern =>
        {
            var inlines = pattern.Split(Environment.NewLine);

            var finder = new MirrorFinder(inlines);

            results.Add(finder.Find());
        });

        return results.Sum();
    }
}
