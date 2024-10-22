using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class NQueens
    {
        static int[] board;
        static List<int[]> solutions;
        static int size;

        public static void SolveNQueens(int n)
        {
            size = n;
            board = new int[n];
            solutions = new List<int[]>();

            PlaceQueen(0);

            foreach (var solution in solutions)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (solution[i] == j)
                        {
                            Console.Write("Q ");
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void PlaceQueen(int row)
        {
            if (row == size)
            {
                solutions.Add((int[])board.Clone());
                return;
            }

            for (int i = 0; i < size; i++)
            {
                if (IsSafe(board, row, i))
                {
                    board[row] = i;
                    PlaceQueen(row + 1);
                    board[row] = -1;
                }
            }
        }

        static bool IsSafe(int[] board, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i] == col)
                {
                    return false;
                }
                if (Math.Abs(board[i] - col) == Math.Abs(i - row))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
