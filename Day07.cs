using System;
using System.Collections.Generic;
using System.Linq;
class Day07
{
    static void Main()
    {
        string[] lines = Util.GetLines("input07.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        int[] list = lines[0].Split(',').Select(int.Parse).ToArray();
        int leastFuel = int.MaxValue;
        for (int i = 0; i < list.Length; i++)
        {
            int fuel = 0;
            for (int j = 0; j < list.Length; j++)
            {
                fuel += Math.Abs(list[i] - list[j]);
            }
            if (fuel < leastFuel) { leastFuel = fuel; }
        }
        return leastFuel;
    }

    static long Part2(string[] lines)
    {
        int[] list = lines[0].Split(',').Select(int.Parse).ToArray();
        int leastFuel = int.MaxValue;
        for (int i = list.Min(); i < list.Max(); i++)
        {
            int fuel = 0;
            for (int j = 0; j < list.Length; j++)
            {
                fuel += GetFuel(Math.Abs(i - list[j]));
            }
            if (fuel < leastFuel) { leastFuel = fuel; }
        }
        return leastFuel;
    }

    private static int GetFuel(int value)
    {
        int fuel = 0;
        for (int i = 1; i <= value; i++)
        {
            fuel += i;
        }
        return fuel;
    }
}
