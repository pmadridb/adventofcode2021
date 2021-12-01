using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

class Day01
{
    static void Main()
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        string[] Lines = System.IO.File.ReadAllLines(@"c:\Users\pmadrid\Documents\GitHub\adventofcode2021\input01.txt");
        var PreviousDepth = 0;
        var Increases = 0;
        for (int i = 1; i < Lines.Length; i++)
        {
            int Depth = Int32.Parse(Lines[i]);
            if (Depth > PreviousDepth)
            {
                Increases++;
            }
            PreviousDepth = Depth;
        }
        Console.WriteLine("Part one: " + Increases);
    }

    static void Part2()
    {
        string[] Lines = System.IO.File.ReadAllLines(@"c:\Users\pmadrid\Documents\GitHub\adventofcode2021\input01.txt");
        var PreviousDepth = 0;
        var Increases = 0;
        for (int i = 1; i < Lines.Length - 2; i++)
        {
            int Depth = Int32.Parse(Lines[i]) + Int32.Parse(Lines[i + 1]) + Int32.Parse(Lines[i + 2]);
            if (Depth > PreviousDepth)
            {
                Increases++;
            }
            PreviousDepth = Depth;
        }
        Console.WriteLine("Part two: " + Increases);
    }
}