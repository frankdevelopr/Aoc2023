// See https://aka.ms/new-console-template for more information
using Aoc2023Day16;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var lines = File.ReadAllLines("problem.txt");
var layout = lines.Select(t => t.ToArray()).ToArray();

var sut = new MultiTraversor(layout);

sut.Traverse();

var result = sut.Energy();

Console.WriteLine($"Traversor took {watch.Elapsed} for result {result}");
