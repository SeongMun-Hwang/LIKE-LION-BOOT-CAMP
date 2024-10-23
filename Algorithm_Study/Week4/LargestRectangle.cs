using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class LargestRectangle
    {
        public static int Solve(int[] heights, int start,int end)
        {
            if (start > end)
            {
                return 0;
            }
            if (start == end)
            {
                return heights[start];
            }

            int mid = (start + end) / 2;
            int leftMax=Solve(heights, start, mid);
            int rightMax = Solve(heights, mid + 1, end);

            int crossMax = MaxCrossRectangle(heights, start, end, mid);

            return Math.Max(leftMax, Math.Max(rightMax,crossMax));
        }

        static int MaxCrossRectangle(int[] heights, int start, int end, int mid)
        {
            int left = mid;
            int right = mid + 1;
            int minHeight = Math.Min(heights[left], heights[right]);
            int maxArea = minHeight * 2;

            while(left>start || right < end){
                if (right < end && (left <= start || heights[right + 1] > heights[left - 1]))
                {
                    right++;
                    minHeight=Math.Min(minHeight,heights[right]);
                }
                else
                {
                    left--;
                    minHeight = Math.Min(minHeight, heights[left]);
                }
                maxArea = Math.Max(maxArea, minHeight * (right - left + 1));
            }
            return maxArea;
        }
    }
}
