using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Knapsack
    {
        class Item
        {
            public int Weight;
            public int Value;
            public float Ratio;
        }

        public static int Knapsack_Greedy(int[] weights, int[] values, int capacity)
        {
            Item[] items = new Item[weights.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                items[i] = new Item();
                items[i].Weight = weights[i];
                items[i].Value = values[i];
                items[i].Ratio = (float)values[i] / weights[i];
            }

            Array.Sort(items, (i1, i2) => i2.Ratio.CompareTo(i1.Ratio));

            int totalValue = 0;
            int remainCapacity = capacity;

            foreach (Item item in items)
            {
                if (item.Weight <= remainCapacity)
                {
                    totalValue += item.Value;
                    remainCapacity -= item.Weight;
                }
            }

            return totalValue;
        }
        public static int Knapsack_Dynamic(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int w = 1; w <= capacity; w++)
                {
                    if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[n, capacity];
        }
    }
}
