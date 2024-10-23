using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Sdoku
    {
        public static bool SolveSudoku(int[,] board)
        {
            int row, col;
            if (FindEmpty(board, out row, out col))
            {
                return true;
            }
            for(int i = 1; i < 9; i++)
            {
                if (IsValid(board, row, col, i))
                {
                    board[row, col] = i;
                    if (SolveSudoku(board))
                    {
                        return true;
                    }
                    board[row, col] = 0;
                }
            }
			return false;
        }
        static bool IsValid(int[,] board, int row, int col, int n)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == n)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == n)
                {
                    return false;
                }
            }

            int rowStart = row / 3 * 3;
            int colStart = col / 3 * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[rowStart + i, colStart + j] == n)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
        static bool FindEmpty(int[,] board, out int row, out int col)
        {
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            row = -1;
            col = -1;
            return false;
        }
        static void PrintSudoku(int[,] board)
        {
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    Console.Write(board[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
