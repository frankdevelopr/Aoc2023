// See https://aka.ms/new-console-template for more information
using Aoc2023Day8;
using System.Diagnostics;

var lines = File.ReadAllLines("problem.txt");

var networkReader = new NetworkReaderEx(lines);

var finder = new PathFinderEx(networkReader.Navigator, networkReader.Network);

var watcher = new Stopwatch();

watcher.Start();
var steps = finder.FindMultiple();
watcher.Stop();

Console.WriteLine($"Steps taken: {steps} (took {watcher.Elapsed})");
