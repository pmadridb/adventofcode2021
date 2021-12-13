using System;
using System.Collections.Generic;
using System.Linq;
class Day08
{
    static void Main()
    {
        string[] lines = Util.GetLines("input08.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));
    }
    static int Part1(string[] lines)
    {
        int total = 0;
        foreach (var line in lines)
        {
            var numbers = new Dictionary<int, string>();
            string[] list = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            string[] patterns = list[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] digits = list[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var pattern in patterns)
            {
                switch (pattern.Length)
                {
                    case 2:
                        numbers[1] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 4:
                        numbers[4] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 3:
                        numbers[7] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 7:
                        numbers[8] = String.Concat(pattern.OrderBy(c => c));
                        break;
                }
            }
            foreach (var digit in digits)
            {
                if (String.Concat(digit.OrderBy(c => c)).Equals(numbers[1])
                    || String.Concat(digit.OrderBy(c => c)).Equals(numbers[4])
                    || String.Concat(digit.OrderBy(c => c)).Equals(numbers[7])
                    || String.Concat(digit.OrderBy(c => c)).Equals(numbers[8]))
                {
                    total += 1;
                }
            }
        }
        return total;
    }

    private static bool ContainsAllChars(string source, string chars)
    {
        foreach (var c1 in chars)
        {
            var containsChar = false;
            foreach(var c2 in source)
            {
                if (c1.Equals(c2))
                {
                    containsChar = true;
                    break;
                }
            }
            if (!containsChar) { return false; }
        }
        return true;
    }

    private static void GetRemainingDigits(Dictionary<int, string> numbers, string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 6)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (!ContainsAllChars(sortedPattern, numbers[1]))
                {
                    numbers[6] = sortedPattern;
                    break;
                }
            }
        }
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 6)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (!ContainsAllChars(sortedPattern, numbers[4]) && !sortedPattern.Equals(numbers[6]))
                {
                    numbers[0] = sortedPattern;
                    break;
                }
            }
        }
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 6)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (!sortedPattern.Equals(numbers[0]) && !sortedPattern.Equals(numbers[6]))
                {
                    numbers[9] = sortedPattern;
                    break;
                }
            }
        }
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 5)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (ContainsAllChars(numbers[6], sortedPattern))
                {
                    numbers[5] = sortedPattern;
                    break;
                }
            }
        }
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 5)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (ContainsAllChars(numbers[9], sortedPattern) && !sortedPattern.Equals(numbers[5]))
                {
                    numbers[3] = sortedPattern;
                    break;
                }
            }
        }
        foreach (var pattern in patterns)
        {
            if (pattern.Length == 5)
            {
                var sortedPattern = String.Concat(pattern.OrderBy(c => c));
                if (!sortedPattern.Equals(numbers[3]) && !sortedPattern.Equals(numbers[5]))
                {
                    numbers[2] = sortedPattern;
                    break;
                }
            }
        }
    }

    static long Part2(string[] lines)
    {
        int total = 0;
        foreach (var line in lines)
        {
            var numbers = new Dictionary<int, string>();
            string[] list = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            string[] patterns = list[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] digits = list[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var pattern in patterns)
            {
                switch (pattern.Length)
                {
                    case 2:
                        numbers[1] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 4:
                        numbers[4] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 3:
                        numbers[7] = String.Concat(pattern.OrderBy(c => c));
                        break;
                    case 7:
                        numbers[8] = String.Concat(pattern.OrderBy(c => c));
                        break;
                }
            }
            GetRemainingDigits(numbers, patterns);
            var number = "";
            foreach (var digit in digits)
            {
                number += FindFirstKeyByValue(numbers, String.Concat(digit.OrderBy(c => c)));
            }
            total += int.Parse(number);
        }
        return total;
    }
    private static int FindFirstKeyByValue(Dictionary<int, string> dict, string val)
    {
        return dict.FirstOrDefault(entry =>
            EqualityComparer<string>.Default.Equals(entry.Value, val)).Key;
    }
}
