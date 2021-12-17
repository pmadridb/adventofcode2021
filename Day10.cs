using System;
using System.Collections.Generic;
using System.Linq;
class Day10
{
    private static Dictionary<string, string> eq = new Dictionary<string, string>
    {
        { "(", ")" },
        { "[", "]" },
        { "{", "}" },
        { "<", ">" }
    };
    private static Dictionary<string, int> corruptedPoints = new Dictionary<string, int>
    {
        { ")", 3 },
        { "]", 57 },
        { "}", 1197 },
        { ">", 25137 }
    };
    private static Dictionary<string, int> autocompletePoints = new Dictionary<string, int>
    {
        { ")", 1 },
        { "]", 2 },
        { "}", 3 },
        { ">", 4 }
    };
    static void Main()
    {
        string[] lines = Util.GetLines("input10.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        int total = 0;
        foreach(var line in lines)
        {
            var control = new List<string>();
            foreach(var character in line)
            {
                var strng = character.ToString();
                if (eq.ContainsKey(strng))
                {
                    control.Add(strng);
                }
                else
                {
                    var closing = eq[control.Last()];
                    if (closing.Equals(strng))
                    {
                        control.RemoveAt(control.Count - 1);
                    }
                    else
                    {
                        total += corruptedPoints[strng];
                        break;
                    }
                }
            }
        }
        return total;
    }

    static long Part2(string[] lines)
    {
        var scores = new List<long>();
        
        foreach (var line in lines)
        {
            var control = new List<string>();
            var corrupt = false;
            foreach (var character in line)
            {
                var strng = character.ToString();
                if (eq.ContainsKey(strng))
                {
                    control.Add(strng);
                }
                else
                {
                    var closing = eq[control.Last()];
                    if (closing.Equals(strng))
                    {
                        control.RemoveAt(control.Count - 1);
                    }
                    else
                    {
                        corrupt = true;
                        break;
                    }
                }
            }
            if (!corrupt)
            {
                control.Reverse();
                long total = 0;
                foreach (var ch in control)
                {
                    total = (total * 5) + autocompletePoints[eq[ch.ToString()]];
                }
                scores.Add(total);
            }
        }
        scores.Sort();
        return scores.ElementAt(scores.Count/2);
    }
}
