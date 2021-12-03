using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Day02
{
    static void Main()
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        string[] Lines = Util.GetLines("input02.txt");
        int HorizontalPosition = 0, Depth = 0;
        for (int i = 0; i < Lines.Length; i++)
        {
            var Instruction = Lines[i].Split(' ');
            var Units = Int32.Parse(Instruction[1]);
            switch (Instruction[0])
            {
                case "up":
                    Depth -= Units;
                    break;
                case "down":
                    Depth += Units;
                    break;
                case "forward":
                    HorizontalPosition += Units;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("Part one: " + Depth * HorizontalPosition);
    }
    static void Part2()
    {
        string[] Lines = Util.GetLines("input02.txt");
        int HorizontalPosition = 0, Depth = 0, Aim = 0;
        for (int i = 0; i < Lines.Length; i++)
        {
            var Instruction = Lines[i].Split(' ');
            var Units = Int32.Parse(Instruction[1]);
            switch (Instruction[0])
            {
                case "up":
                    Aim -= Units;
                    break;
                case "down":
                    Aim += Units;
                    break;
                case "forward":
                    HorizontalPosition += Units;
                    Depth += Aim * Units;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("Part two: " + Depth * HorizontalPosition);

    }
}
