using System;
using System.Drawing;

namespace PolyLight.Figures
{
    internal struct ColoredPoint
    {
        public Color Color;
        public Point Point;
        public int X => Point.X;
        public int Y => Point.Y;

        public ColoredPoint(int x, int y, Color color)
        {
            Point = new Point(x, y);
            Color = color;
        }

        public ColoredPoint(Point point, Color color)
        {
            Point = point;
            Color = color;
        }
    }
}
