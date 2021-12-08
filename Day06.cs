using System;
using System.Collections.Generic;
using System.Linq;
class Day06
{
    static void Main()
    {
        string[] lines = Util.GetLines("input06.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        int[] list = lines[0].Split(',').Select(int.Parse).ToArray();
        for(int counter = 0;counter<80;counter++)
        {
            List<int> newMembers = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > 0) { list[i] = list[i] - 1; }
                else if (list[i] == 0)
                {
                    list[i] = 6;
                    newMembers.Add(8);
                }
            }
            list = list.Concat(newMembers.ToArray()).ToArray();
        }
        return list.Length;
    }

    static long Part2(string[] lines)
    {
        int[] list = lines[0].Split(',').Select(int.Parse).ToArray();
        var fish = new Dictionary<long, long>()
        {
            { 0,0 },
            { 1,0 },
            { 2,0 },
            { 3,0 },
            { 4,0 },
            { 5,0 },
            { 6,0 },
            { 7,0 },
            { 8,0 },
        };
        UpdateFishStatus(fish, list);
        for (int i = 0; i < 256; i++)
        {
            long buffer = fish[0];
            fish[0] = fish[1];
            fish[1] = fish[2];
            fish[2] = fish[3];
            fish[3] = fish[4];
            fish[4] = fish[5];
            fish[5] = fish[6];
            fish[6] = fish[7];
            fish[7] = fish[8];
            fish[6] = fish[6] + buffer;
            fish[8] = buffer;
        }
        return fish.Values.Sum();
    }

    private static void UpdateFishStatus(Dictionary<long, long> fish, int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            fish[list[i]] += 1;
        }
    }
}
