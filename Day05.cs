using System;
using System.Collections.Generic;
using System.Linq;
class Day05
{
    static void Main()
    {
        string[] lines = Util.GetLines("input05.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        int[,] matrix = new int[1000,1000];
        for (int i = 0; i < lines.Length; i++)
        {
            (int startX, int startY, int endX, int endY) = ExtractCoordinates(lines[i]);
            DrawLine(matrix, startX, startY, endX, endY);
        }
        return CountOverlaps(matrix);
    }

    private static int CountOverlaps(int[,] matrix)
    {
        var overlaps = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i,j] > 1) { overlaps++; }
            }
        }
        return overlaps;
    }

    private static void DrawLine(int[,] matrix, int startX, int startY, int endX, int endY)
    {
        if (startX == endX)
        {
            while (startY != endY)
            {
                matrix[startX, startY]++;
                if (startY < endY) { startY++; }
                else { startY--; }
                if (startY == endY) { matrix[startX, startY]++; }
            }
        }
        else if (startY == endY)
        {
            while (startX != endX)
            {
                matrix[startX, startY]++;
                if (startX < endX) { startX++; }
                else { startX--; }
                if (startX == endX) { matrix[startX, startY]++; }
            }
        }
    }

    static int Part2(string[] lines)
    {
        int[,] matrix = new int[1000, 1000];
        for (int i = 0; i < lines.Length; i++)
        {
            (int startX, int startY, int endX, int endY) = ExtractCoordinates(lines[i]);
            DrawLineWithDiagonals(matrix, startX, startY, endX, endY);
        }
        return CountOverlaps(matrix);
    }

    static (int, int, int, int) ExtractCoordinates(string line)
    {
        var coordinates = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
        var point = coordinates[0].Split(',');
        var startX = Int32.Parse(point[0]);
        var startY = Int32.Parse(point[1]);
        point = coordinates[1].Split(',');
        var endX = Int32.Parse(point[0]);
        var endY = Int32.Parse(point[1]);
        return (startX, startY, endX, endY);
    }
    private static void DrawLineWithDiagonals(int[,] matrix, int startX, int startY, int endX, int endY)
    {
        while (startX != endX || startY != endY)
        {
            matrix[startX, startY]++;
            if (startX < endX) { startX++; }
            else if (startX > endX) { startX--; }
            if (startY < endY) { startY++; }
            else if (startY > endY) { startY--; }
            if (startX == endX && startY == endY) { matrix[startX, startY]++; }
        }
    }
}
