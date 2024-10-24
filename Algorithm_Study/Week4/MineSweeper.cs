using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class MineSweeper
{
    static int[,] minefield;
    static bool[,] revealed;

    static int rows = 10;
    static int cols = 10;

    public static void Start()
    {
        InitializeField();

        int startRow;
        int startCol;

        Random rand = new Random();

        do
        {
            startRow = rand.Next(rows);
            startCol = rand.Next(cols);
        } while (minefield[startRow, startCol] != 0);

        //        DFS(startRow, startCol);
        BFS(startRow, startCol);

    }

    static void InitializeField()
    {
        minefield = new int[rows, cols];
        revealed = new bool[rows, cols];

        Random rand = new Random();

        for (int i = 0; i < 5; i++)
        {
            int x = rand.Next(rows);
            int y = rand.Next(cols);

            if (minefield[x, y] == 0)
            {
                minefield[x, y] = -1;
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (minefield[r, c] != -1)
                {
                    minefield[r, c] = CountMine(r, c);
                }
            }
        }
    }

    static int CountMine(int r, int c)
    {
        int count = 0;
        for (int i = r - 1; i <= r + 1; i++)
        {
            for (int j = c - 1; j <= c + 1; j++)
            {
                if (i >= 0 && i < rows && j >= 0 && j < cols && minefield[i, j] == -1)
                {
                    count++;
                }
            }
        }
        return count;
    }

    static void DFS(int row, int col)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols || revealed[row, col])
        {
            return;
        }

        revealed[row, col] = true;
        PrintField();
        Console.ReadKey();

        if (minefield[row, col] == 0)
        {
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    DFS(r, c);
                }
            }
        }
    }
    static void BFS(int row, int col)
    {
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { row, col });

        while (queue.Count > 0)
        {
            int[] currentPos = queue.Dequeue();
            int r = currentPos[0];
            int c = currentPos[1];

            if (r < 0 || r >= rows || c < 0 || c >= cols || revealed[r, c])
            {
                continue;
            }

            revealed[r, c] = true;
            PrintField();
            Console.ReadKey();

            if (minefield[r, c] == 0)
            {
                for (int i = r - 1; i <= r + 1; i++)
                {
                    for (int j = c - 1; j <= c + 1; j++)
                    {
                        queue.Enqueue(new int[] { i, j });
                    }
                }
            }
        }
    }
    static void PrintField()
    {
        Console.Clear();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (revealed[r, c])
                {
                    if (minefield[r, c] == -1)
                    {
                        Console.Write("* ");
                    }
                    else if (minefield[r, c] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(minefield[r, c] + " ");
                    }
                }
                else
                {
                    Console.Write("# ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}