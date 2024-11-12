using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    internal class TicTacToe
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        const char PLAYER = 'X';
        const char AI = 'O';

        public static void Play()
        {
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
            static void PrintBoard()
            {
                Console.WriteLine("Board");
                for (int i = 0; i < board.Length; i += 3)
                {
                    Console.WriteLine(board[i] + "|" + board[i + 1] + "|" + board[i + 2] + "\n");
                }
            }
            static void PlayerMove()
            {
                Console.WriteLine("enter your move(1~9) :");
                int move = int.Parse(Console.ReadLine()) - 1;
                board[move] = PLAYER;
            }
            static void AIMove()
            {
                int bestScore = int.MinValue;
                int bestMove = -1;

                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == ' ')
                    {
                        board[i] = AI;
                        int score = Minimax(0, false);
                        board[i] = ' ';
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i;
                        }
                    }
                }
                board[bestMove] = AI;
            }
            static int Minimax(int depth, bool isMax)
            {
                if (CheckWin(AI)) return 10 - depth;
                if (CheckWin(PLAYER)) return depth - 10;
                if (IsBoardFull()) return 0;

                int bestScore = (isMax ? int.MinValue : int.MaxValue);
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == ' ')
                    {
                        board[i] = (isMax ? AI : PLAYER);
                        int score = Minimax(depth + 1, !isMax);
                        board[i] = ' ';
                        bestScore = (isMax ? Math.Max(bestScore, score) : Math.Min(bestScore, score));
                    }
                }
                return bestScore;
            }
            static bool CheckWin(char player)
            {
                int[,] winCondition = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 },
                { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
                for (int i = 0; i < winCondition.GetLength(0); i++)
                {
                    if (board[winCondition[i, 0]] == player &&
                        board[winCondition[i, 1]] == player &&
                        board[winCondition[i, 2]] == player)
                    {
                        return true;
                    }
                }
                return false;
            }
            static bool IsBoardFull()
            {
                foreach (char b in board)
                {
                    if (b == ' ') return false;
                }
                return true;
            }
        }
    }
}
