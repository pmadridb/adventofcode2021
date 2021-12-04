using System;
using System.Linq;
class Day03
{
    static void Main()
    {
        string[] lines = Util.GetLines("input03.txt");
        Part1(lines);
        Part2(lines);
    }

    static void Part1(string[] lines)
    {
        int[] numberOfOnes = new int[lines[0].Length];
        int[] numberOfZeros = new int[lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string Line = lines[i];
            for (int j = 0; j < Line.Length; j++)
            {
                if (Line[j].Equals('0'))
                {
                    numberOfZeros[j]++;
                } else
                {
                    numberOfOnes[j]++;
                }
            }
        }
        string epsilonRate = "";
        string gammaRate = "";
        for (int i = 0; i < numberOfZeros.Length; i++)
        {
            epsilonRate = epsilonRate + (numberOfOnes[i] > numberOfZeros[i] ? "1" : "0");
            gammaRate = gammaRate + (numberOfOnes[i] > numberOfZeros[i] ? "0" : "1");
        }

        Console.WriteLine("Part one: " + Convert.ToInt32(epsilonRate, 2) * Convert.ToInt32(gammaRate, 2));
    }

    static void Part2(string[] lines)
    {
        string oxygenGeneratorRating = CalculateRating(lines, '1', (x, y) => x > y);
        string co2ScrubberRating = CalculateRating(lines, '0', (x, y) => x < y);

        Console.WriteLine("Part two: " + Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2));

    }

    static string CalculateRating(string[] lines, char defaultValue, Func<int, int, bool> comparator)
    {
        for (int j = 0; j < lines[0].Length; j++)
        {
            int numberOfOnes = 0;
            int numberOfZeros = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines.Length == 1)
                {
                    return lines[0];
                }
                string Line = lines[i];
                if (Line[j].Equals('0'))
                {
                    numberOfZeros++;
                }
                else
                {
                    numberOfOnes++;
                }
            }
            if (comparator(numberOfOnes, numberOfZeros))
            {
                lines = lines.Where(line => line[j].Equals('1')).ToArray();
            } else if (comparator(numberOfZeros, numberOfOnes))
            {
                lines = lines.Where(line => line[j].Equals('0')).ToArray();
            } else
            {
                lines = lines.Where(line => line[j].Equals(defaultValue)).ToArray();
            }
            
        }
        return lines[0];
    }
}
