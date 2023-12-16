// See https://aka.ms/new-console-template for more information
using Aoc2023Day14;
using System.Diagnostics;

var lines = File.ReadAllLines("problem.txt");
var it = 10_000_000L;
var platform = lines.Select(p => p.ToArray());
//DoSomething("PlatformSystem", it, () => new PlatformTilt(platform));
DoSomething("Ex version", it, () => new PlatformTiltEx(platform));

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
/*
//var lines = File.ReadAllLines("test.txt");
var lines = File.ReadAllLines("problem.txt");

Console.WriteLine("Read platform");
Console.WriteLine(lines);

var sut = new PlatformSystem(lines);

var watcher = new Stopwatch();

watcher.Start();
var it = 1000000000L;
var result = sut.Cycle(it);
watcher.Stop();

Console.WriteLine($"Cycles result is {result} after {it} iterations (took {watcher.Elapsed})");
*/