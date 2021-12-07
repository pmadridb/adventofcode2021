using System;
using System.Collections.Generic;
using System.Linq;
class Day04
{
    static void Main()
    {
        string[] lines = Util.GetLines("input04.txt");
        Console.WriteLine("Part one: " + Part1(lines));
        Console.WriteLine("Part two: " + Part2(lines));

    }
    static (string[] , List<string[][]>) GetNumbersAndBoards(string[] lines)
    {
        string[] numbers = lines[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
        var boards = new List<string[][]>();
        for (int i = 2; i < lines.Length; i += 6)
        {
            string[][] board = new string[5][];
            board[0] = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            board[1] = lines[i + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            board[2] = lines[i + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            board[3] = lines[i + 3].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            board[4] = lines[i + 4].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            boards.Add(board);
        }
        return (numbers, boards);
    }
    static int Part1(string[] lines)
    {
        (string[] numbers, List<string[][]> boards) = GetNumbersAndBoards(lines);

        foreach (var number in numbers)
        {
            foreach(var board in boards)
            {
                if (FindNumberInBoard(board, number))
                {
                    return CalculateScore(board, number);
                }
            }
        }
        return 0;
    }

    private static int CalculateScore(string[][] board, string number)
    {
        var total = 0;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (int.TryParse(board[i][j], out _))
                {
                    total += Int32.Parse(board[i][j]);
                }
            }
        }
        return total * Int32.Parse(number);
    }

    private static bool FindNumberInBoard(string[][] board, string number)
    {
        var bingo = false;
        for(int i = 0;i<board.Length;i++)
        {
            for(int j=0;j<board[0].Length;j++)
            {
                if (board[i][j].Equals(number))
                {
                    board[i][j] = "X";
                    bingo =  IsBingo(board, i,j);
                }
            }
        }
        return bingo;
    }

    private static bool IsBingo(string[][] board, int row, int column)
    {
        var bingo = true;
        for (int i=0;i<board.Length;i++)
        {
            if (!board[i][column].Equals("X"))
            {
                bingo = false;
                break;
            }
        }
        if (!bingo)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (!board[row][i].Equals("X"))
                {
                    return false;
                }
            }
        }
        return true;
    }
    static int Part2(string[] lines)
    {
        (string[] numbers, List<string[][]> boards) = GetNumbersAndBoards(lines);
        var boardsStatus = new Dictionary<int, bool>();
        var index = 0;
        boards.ForEach((item) =>
        {
            boardsStatus.Add(index, false);
            index++;
        });
        foreach (var number in numbers)
        {
            for (int i = 0; i < boards.Count(); i++)
            {
                var board = boards.ElementAt(i);
                if (boardsStatus[i] == false && FindNumberInBoard(board, number))
                {
                    if (boardsStatus.Values.Where(status => !status).Count() > 1)
                    {
                        boardsStatus[i] = true;
                    }
                    else
                    {
                        return CalculateScore(board, number);
                    }
                }
            }
        }
        return 0;
    }

}
