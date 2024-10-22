using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class ClosetTwoPoint
    {
        public class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static float Distance(Point p1, Point p2)
            {
                return MathF.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            }

            public override string ToString()
            {
                return "(" + X + "," + Y + ")";
            }
        }
        internal class ClosestTwoPoint
        {
            public static Point P1;
            public static Point P2;
            public static float MinDist = 999999;

            public static float FindClosestPair(Point[] points)
            {
                Array.Sort(points, (p1, p2) =>
                {
                    return p1.X - p2.X;
                });

                return FindClosest(points, 0, points.Length - 1);
            }

            static float FindClosest(Point[] points, int left, int right)
            {
                if (right - left == 1)
                {
                    float dist = Point.Distance(points[left], points[right]);
                    if (MinDist > dist)
                    {
                        P1 = points[left];
                        P2 = points[right];
                    }
                    return dist;
                }
                else if (right - left == 2)
                {
                    float d1 = Point.Distance(points[left], points[left + 1]);
                    if (MinDist > d1)
                    {
                        P1 = points[left];
                        P2 = points[left + 1];
                    }
                    float d2 = Point.Distance(points[left + 1], points[right]);
                    if (MinDist > d2)
                    {
                        P1 = points[left + 1];
                        P2 = points[right];
                    }
                    float d3 = Point.Distance(points[left], points[right]);
                    if (MinDist > d3)
                    {
                        P1 = points[left];
                        P2 = points[right];
                    }
                    return Math.Min(Math.Min(d1, d2), d3);
                }

                int mid = (left + right) / 2;
                float leftMin = FindClosest(points, left, mid);
                float rightMin = FindClosest(points, mid + 1, right);
                float d = Math.Min(leftMin, rightMin);
                float closestInStrip = ClosestInStrip(points, left, right, mid, d);

                return Math.Min(d, closestInStrip);
            }
            static float ClosestInStrip(Point[] points, int left, int right, int mid, float d)
            {
                List<Point> strip = new List<Point>();

                for (int i = left; i <= right; i++)
                {
                    if (MathF.Abs(points[i].X - points[mid].X) < d)
                    {
                        strip.Add(points[i]);
                    }
                }
                strip.Sort((p1, p2) => p1.Y - p2.Y);
                float minDist = d;

                for (int i = 0; i < strip.Count; i++)
                {
                    for (int j = i + 1; j < strip.Count && strip[j].Y - strip[i].Y < minDist; j++)
                    {
                        if (minDist > Point.Distance(strip[i], strip[j]))
                        {
                            P1 = strip[i];
                            P2 = strip[j];
                        }
                        minDist = Math.Min(minDist, Point.Distance(strip[i], strip[j]));
                    }
                }
                return minDist;
            }
        }
    }
}