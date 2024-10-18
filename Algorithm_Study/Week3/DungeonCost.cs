using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class MinCostDungeon
    {
        int m;
        int n;
        int[,] cost;
        public int minCost = 999999;
        public MinCostDungeon(int m, int n)
        {
            this.m = m;
            this.n = n;

            Random rand = new Random();

            cost = new int[n, m];

            for(int i = 0; i < m; i++)
            {
                for(int j=0; j < n; j++)
                {
                    cost[i, j] = rand.Next(1, 10);
                    Console.Write(cost[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        public void DFS(int i,int j,int currentCost)
        {
            currentCost += cost[i, j];
            if(i==m-1 && j == n - 1)
            {
                minCost = Math.Min(minCost, currentCost);
                return;
            }
            if (i + 1 < m)
            {
                DFS(i + 1, j, currentCost);
            }
            if (j + 1 < n)
            {
                DFS(i,j+1, currentCost);
            }
        }
        public void Dynamic()
        {
            int[,] dp = new int[m, n];
            dp[0, 0] = cost[0, 0];

            for(int i=1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + cost[i, 0];
            }
            for(int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + cost[0, i];
            }

            for(int i = 1; i < m; i ++)
            {
                for(int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i-1, j], dp[i, j - 1]) + cost[i,j];
                }
            }
            minCost = dp[m - 1, n - 1];
        }
    }
}