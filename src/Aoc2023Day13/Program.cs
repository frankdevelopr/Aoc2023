// See https://aka.ms/new-console-template for more information
using Aoc2023Day13;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllText("problem.txt");

var finder = new MultipleMirrorFinder(lines);

Console.WriteLine("Final result "+finder.CalculateSmudge());
