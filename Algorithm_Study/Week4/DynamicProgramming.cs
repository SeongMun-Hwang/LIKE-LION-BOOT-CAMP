using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class DynamicProgramming
    {
        public static int GenerateString(int n, string str = "")
        {
            char[] chars = new char[] { 'a', 'b', 'c' };

            if (n == str.Length)
            {
                Console.WriteLine(str);
                return 1;
            }

            int count = 0;
            foreach (char c in chars)
            {
                count += GenerateString(n, str + c);
            }

            return count;
        }
        public static void MinimumCost1(int number)
        {
            int[] dp = new int[number + 1];

            dp[1] = 0;

            for (int i = 2; i <= number; i++)
            {
                dp[i] = dp[i - 1] + 1;

                if (i % 2 == 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i / 2] + 1);
                }
                if (i % 3 == 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i / 3] + 1);
                }
            }

            Console.WriteLine("최소 연산 : " + dp[number]);
        }
        public static int NumberOfPathWithObstacles(int[,] map)
        {
            int m = map.GetLength(1);
            int n = map.GetLength(0);

            int[,] dp = new int[n, m];

            dp[0, 0] = 1;

            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = (map[i, 0] == 0 && dp[i - 1, 0] == 1) ? 1 : 0;
            }
            for (int i = 1; i < m; i++)
            {
                dp[0, i] = (map[0, i] == 0 && dp[0, i - 1] == 1) ? 1 : 0;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (map[i, j] == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return dp[n - 1, m - 1];
        }

        public static int FindSimillarSum(int[] array)
        {
            int totalSum = array.Sum();
            int n = array.Length;

            bool[,] dp = new bool[n + 1, totalSum / 2 + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = true;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= totalSum / 2; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (array[i - 1] <= j)
                    {
                        dp[i, j] = dp[i, j] || dp[i - 1, j - array[i - 1]];
                    }
                }
            }
            int group1 = 0;
            for (int j = totalSum / 2; j >= 0; j--)
            {
                if (dp[n, j])
                {
                    group1 = j;
                    break;
                }
            }
            return group1;
        }

        public static int CombinationStatic(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }
            return CombinationStatic(n - 1, k) + CombinationStatic(n - 1, k - 1);
        }
        public static int CombinationDynamic(int n,int k)
        {
            int[,] dp = new int[n + 1, k + 1];
            for(int i = 0; i <= n; i++)
            {
                for(int j=0; j <= Math.Min(i,k); j++)
                {
                    if (j == 0 || j == i)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                    }
                }
            }
            return dp[n, k];
        }
    }
}
