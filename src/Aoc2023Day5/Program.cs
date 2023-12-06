// See https://aka.ms/new-console-template for more information
using Aoc2023Day5;
using System.Diagnostics;

var lines = File.ReadAllLines("problem5.txt");

var mapReader = new MapReader(lines);

var finder = new LowestLocationFinder(mapReader.Map);

var expected = finder.ExpectedExecutions();
Console.WriteLine($"Expected executions {expected}");

var watcher = new Stopwatch();

watcher.Start();
var lowest = finder.FindLowestLocationRange();
watcher.Stop();

Console.WriteLine($"Lowest is {lowest} (took {watcher.Elapsed})");
