// See https://aka.ms/new-console-template for more information
using Aoc2023Day20;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("problem.txt");

var sut = new ButtonSystem(lines);

var watch = new Stopwatch();
watch.Start();

var times = sut.PushRx();

Console.WriteLine($"Reaching RX module took {times} presses in {watch.Elapsed}");


