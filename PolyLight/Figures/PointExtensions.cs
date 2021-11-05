using System;
using System.Linq;
using System.Drawing;

namespace PolyLight.Figures
{
    internal static class PointExtensions
    {
        // code duplication due to lack of polymorphysm on structs
        public static Point GetMidPoint(params Point[] points)
        {
            int count = points.Length;
            int x = points.Sum(p => p.X) / count;
            int y = points.Sum(p => p.Y) / count;

            return new Point(x, y);
        }

        public static Point GetMidPoint(params ColoredPoint[] points)
        {
            int count = points.Length;
            int x = points.Sum(p => p.X) / count;
            int y = points.Sum(p => p.Y) / count;

            return new Point(x, y);
        }

        public static ColoredPoint GetMidColoredPoint(params ColoredPoint[] points)
        {
            int count = points.Length;
            int x = points.Sum(p => p.X) / count;
            int y = points.Sum(p => p.Y) / count;
            int r = points.Sum(p => p.Color.R) / count;
            int g = points.Sum(p => p.Color.G) / count;
            int b = points.Sum(p => p.Color.B) / count;
            int a = points.Sum(p => p.Color.A) / count;

            var color = Color.FromArgb(a, r, g, b);
            return new ColoredPoint(x, y, color);
        }

        public static bool IsInRadius(this Point a, Point circleCenter, float radius)
        {
            return DistanceSquared(a, circleCenter) <= radius * radius;
        }

        public static float Distance(Point a, Point b)
        {
            float distanceSquared = DistanceSquared(a, b);

            return MathF.Sqrt(distanceSquared);
        }

        public static float DistanceSquared(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;

            return dx * dx + dy * dy;
        }

    }
}
