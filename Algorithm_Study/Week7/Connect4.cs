using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    internal class Connect4
    {
        static char[,] board = new char[6, 7];
        const char PLAYER = 'X';
        const char AI = 'O';
        const int WINNING_SCORE = 10000;
        const int MAX_DEPTH = 7;
        public static void Play()
        {
            InitBoard();
            while (true)
            {
                PrintBoard();
                PlayerMove();
                if (CheckWin(PLAYER))
                {
                    PrintBoard();
                    Console.WriteLine("Player Win!");
                    break;
                }
                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Draw!");
                    break;
                }

                AIMove();
                if (CheckWin(AI))
                {
                    PrintBoard();
                    Console.WriteLine("AI Win!");
                    break;
                }
                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Draw!");
                    break;
                }
                PrintBoard();
            }
        }
        static void InitBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        static void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("| " + board[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  0   1   2   3   4   5   6");
        }

        static void PlayerMove()
        {
            Console.Write("Your Move (0~6) : ");
            int col = int.Parse(Console.ReadLine());

            DropDisc(col, PLAYER);

        }

        static void DropDisc(int column, char player)
        {
            int row = GetAvailableRow(column);
            if (row != -1)
            {
                board[row, column] = player;
            }
        }

        static int GetAvailableRow(int column)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == ' ')
                    return row;
            }
            return -1;
        }
        static bool CheckWin(char player)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (CheckDirection(i, j, 0, 1, player) ||
                        CheckDirection(i, j, 1, 0, player) ||
                        CheckDirection(i, j, 1, 1, player) ||
                        CheckDirection(i, j, 1, -1, player))
                        return true;
                }
            }
            return false;
        }
        static bool CheckDirection(int row, int col, int dRow, int dCol, char player)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int r = row + dRow * i;
                int c = col + dCol * i;
                if (r >= 0 && r < 6 && c >= 0 && c < 7 && board[r, c] == player)
                    count++;
                else
                    break;
            }
            return count == 4;
        }
        static bool IsBoardFull()
        {
            for (int c = 0; c < 7; c++)
            {
                if (board[0, c] == ' ') return false;
            }
            return true;
        }
        static void AIMove()
        {
            int bestScore = int.MinValue;
            int bestMove = -1;

            for (int col = 0; col < 7; col++)
            {
                int row = GetAvailableRow(col);
                if (row != -1)
                {
                    board[row, col] = AI;
                    int score = AlphaBeta(0, false, int.MinValue, int.MaxValue);
                    board[row, col] = ' ';
                    Random rand= new Random();
                    if (score == bestScore && rand.Next(5) < 1)
                    {
                        bestScore = score;
                        bestMove = col;
                    }
                    else if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = col;
                    }
                }
            }

            DropDisc(bestMove, AI);
        }

        static int AlphaBeta(int depth, bool isMax, int alpha, int beta)
        {
            if (CheckWin(AI)) return WINNING_SCORE - depth;
            if (CheckWin(PLAYER)) return depth - WINNING_SCORE;
            if (depth >= MAX_DEPTH) return 0;
            if (IsBoardFull()) return 0;

            int best = (isMax ? int.MinValue : int.MaxValue);
            for (int col = 0; col < 7; col++)
            {
                int row = GetAvailableRow(col);
                if (row != -1)
                {
                    board[row, col] = (isMax ? AI : PLAYER);
                    int score = AlphaBeta(depth + 1, !isMax, alpha, beta);
                    board[row, col] = ' ';
                    best = (isMax ? Math.Max(best, score) : Math.Min(best, score));

                    if (isMax)
                    {
                        alpha=Math.Max(alpha, score);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                    else
                    {
                        beta = Math.Min(beta, score);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
            }

            return best;
        }
    }
}
