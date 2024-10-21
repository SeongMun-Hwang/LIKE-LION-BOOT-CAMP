using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class LevnshteinDistance
    {
        public static int Distance(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;
            int[,] dp = new int[len1 + 1, len2 + 1];

            for (int i = 0; i <= len1; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 0; i <= len2; i++)
            {
                dp[0, i] = i;
            }
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }
            }

            return dp[len1, len2];
        }
    }
}
