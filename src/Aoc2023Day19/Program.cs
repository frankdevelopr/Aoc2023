// See https://aka.ms/new-console-template for more information
using Aoc2023Day19;

Console.WriteLine("Hello, World!");

Console.WriteLine($"Start processing {4000L*4000*4000*4000} values");

var data = File.ReadAllLines("test.txt");
var sut = new AcceptedPartsSumer(data);
var actual = sut.AcceptedCombinations();

Console.WriteLine($"End with {actual} accepted combinations");
