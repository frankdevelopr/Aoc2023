// See https://aka.ms/new-console-template for more information
using Aoc2023Day14;
using System.Diagnostics;


CycleThemAll();

//DoSomething("PlatformSystem", it, () => new PlatformTilt(platform));
//DoSomething("Ex version", it, () => new PlatformTiltEx(platform));

void DoSomething(string name, long it, Func<IPlatformTilt> value)
{
    var watcher = new Stopwatch();
    watcher.Start();

    var sut = value();
    for (var i = 0; i < it; ++i)
    {
        sut.TiltNorth();
        if (i % 1_000_000 == 0)
        {
            Console.WriteLine($"iterations done {i} for {name}");
        }
    }
    watcher.Stop();
    Console.WriteLine($"Calculate for {name} after {it} iterations (took {watcher.Elapsed})");
}

void CycleThemAll()
{
    var lines = File.ReadAllLines("problem.txt");
    //var lines = File.ReadAllLines("test.txt");

    //Console.WriteLine("Read platform");
    //Console.WriteLine(lines);

    var sut = new PlatformSystem(lines);

    var watcher = new Stopwatch();

    watcher.Start();
    var it = 1000_000_000L;

    var top = 10_000_000L;
    for (var i = 0; i < top; ++i)
    {
        var result = sut.Cycle(1_000_000);
        Console.WriteLine($"{result} after {(i+1)*1_000_000} iterations (took {watcher.Elapsed})");
        //Console.WriteLine($"{result} after {i} iterations (took {watcher.Elapsed})");
        //Console.WriteLine(result);

        //if (i > 200 && it % i == 0)
        if (i % 1_000_000L == 0)
        {
            Console.WriteLine($"{result} after {i} iterations (took {watcher.Elapsed})");
            //Console.WriteLine(result);
        }
    }

    watcher.Stop();

    //Console.WriteLine($"Cycles result is {result} after {it} iterations (took {watcher.Elapsed})");
}
