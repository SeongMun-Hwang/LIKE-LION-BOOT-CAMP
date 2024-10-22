using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class MazeSolve
    {
        static bool[,] visited = new bool[100, 100];
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };
        public static bool SolveMaze(int[,] maze, int x, int y)
        {
            // 정지조건 정의
            int n = maze.GetLength(0);
            if (x < 0 || x >= n || y < 0 || y >= n || maze[x, y] == 1 || visited[x, y])
            {
                return false;
            }

            if (x == n - 1 && y == n - 1)
            {
                Console.WriteLine(x + " " + y + " 도착");
                return true;
            }

            // 방문 좌표 표시
            visited[x, y] = true;

            // 해당 방문 좌표로부터 상, 하, 좌, 우로 경로 확인
            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (SolveMaze(maze, nextX, nextY))
                {
                    Console.WriteLine("경로 " + x + " " + y);
                    return true;
                }
            }

            // 돌아 나올 때 방문기록 삭제
            visited[x, y] = false;
            return false;
        }
    }
}
