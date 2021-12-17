using System;
using System.Collections.Generic;
using System.Linq;
class Day09
{
    private static List<(int, int)> lowPoints = new();
    static void Main()
    {
        string[] lines = Util.GetLines("input09.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        lowPoints = new List<(int, int)>();
        for (var i = 0; i< lines.Length; i++)
        {
            for (var j = 0; j < lines[0].Length; j++)
            {
                if (IsLowPoint(lines, i,j)) { lowPoints.Add((i, j)); }
            }
        }
        var total = 0;
        lowPoints.ForEach(tuple => total += 1 + int.Parse(lines[tuple.Item1][tuple.Item2].ToString()));
        return total;
    }

    private static bool IsLowPoint(string[] lines, int i, int j)
    {
        var point = int.Parse(lines[i][j].ToString());
        if (i - 1 >= 0 && int.Parse(lines[i-1][j].ToString()) <= point) { return false; }
        if (i + 1 < lines.Length && int.Parse(lines[i+1][j].ToString()) <= point) { return false; }
        if (j - 1 >= 0 && int.Parse(lines[i][j-1].ToString()) <= point) { return false; }
        if (j + 1 < lines[0].Length && int.Parse(lines[i][j+1].ToString()) <= point) { return false; }
        return true;
    }

    static long Part2(string[] lines)
    {
        var basinSizes = new List<int>();
        var basinTuples = new List<(int, int)>();
        foreach (var tuple in lowPoints)
        {
            basinTuples.Add(tuple);
            var basinSize = GetBasinSize(lines, tuple, basinTuples);
            basinSizes.Add(basinSize + 1);
        }
        basinSizes.Sort();
        return basinSizes.TakeLast(3).Aggregate((a, b) => a * b);
    }

    private static int GetBasinSize(string[] lines, (int, int) tuple, List<(int, int)> basinTuples)
    {
        basinTuples.Add((tuple.Item1, tuple.Item2));
        int basinSize = 0;
        var centerNumber = int.Parse(lines[tuple.Item1][tuple.Item2].ToString());
        if (tuple.Item2 - 1 >= 0 && int.Parse(lines[tuple.Item1][tuple.Item2 - 1].ToString()) == centerNumber + 1 &&
            int.Parse(lines[tuple.Item1][tuple.Item2 - 1].ToString()) < 9 && !basinTuples.Contains((tuple.Item1, tuple.Item2 - 1)))
        {
            basinSize++;
            basinSize += GetBasinSize(lines, (tuple.Item1, tuple.Item2 - 1), basinTuples);
        }
        if (tuple.Item2 + 1 < lines[0].Length && int.Parse(lines[tuple.Item1][tuple.Item2 + 1].ToString()) == centerNumber + 1 &&
            int.Parse(lines[tuple.Item1][tuple.Item2 + 1].ToString()) < 9 && !basinTuples.Contains((tuple.Item1, tuple.Item2 + 1)))
        {
            basinSize++;
            basinSize += GetBasinSize(lines, (tuple.Item1, tuple.Item2 + 1), basinTuples);
        }
        if (tuple.Item1 - 1 >= 0 && int.Parse(lines[tuple.Item1 - 1][tuple.Item2].ToString()) == centerNumber + 1 &&
            int.Parse(lines[tuple.Item1 - 1][tuple.Item2].ToString()) < 9 && !basinTuples.Contains((tuple.Item1 - 1, tuple.Item2)))
        {
            basinSize++;
            basinSize += GetBasinSize(lines, (tuple.Item1 - 1, tuple.Item2), basinTuples);
        }
        if (tuple.Item1 + 1 < lines.Length && int.Parse(lines[tuple.Item1 + 1][tuple.Item2].ToString()) == centerNumber + 1 &&
            int.Parse(lines[tuple.Item1 + 1][tuple.Item2].ToString()) < 9 && !basinTuples.Contains((tuple.Item1 + 1, tuple.Item2)))
        {
            basinSize++;
            basinSize += GetBasinSize(lines, (tuple.Item1 + 1, tuple.Item2), basinTuples);
        }
        return basinSize;
    }
}
