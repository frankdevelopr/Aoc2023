// See https://aka.ms/new-console-template for more information
using Aoc2023Day14;
using System.Diagnostics;

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
