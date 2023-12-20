// See https://aka.ms/new-console-template for more information
using Aoc2023Day18;
using System.Drawing;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("problem.txt");

var sut = new Trench(new TrenchSize(lines));

Console.WriteLine($"Size is {sut.Size}");