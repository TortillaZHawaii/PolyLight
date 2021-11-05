using PolyLight.Drawing.Icons;
using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyLight.Drawing
{
    internal class BitmapDrawer
    {
        DirectBitmap _directBitmap;
        Pen _pen;

        public BitmapDrawer(DirectBitmap directBitmap)
        {
            _directBitmap = directBitmap;
            _pen = Pens.Black;
        }

        public BitmapDrawer(DirectBitmap directBitmap, Pen pen)
        {
            _directBitmap = directBitmap;
            _pen = pen;
        }

        public void Clear(Color color)
        {
            using var graphics = GetGraphics();
            graphics.Clear(color);
        }

        public void DrawCircle(Circle circle)
        {
            using var graphics = GetGraphics();
            var left = circle.Point.X - circle.Radius;
            var top = circle.Point.Y - circle.Radius;

            graphics.DrawEllipse(_pen, left, top, circle.Diameter, circle.Diameter);
        }

        public void DrawLine(Point a, Point b)
        {
            using var graphics = GetGraphics();
            DrawLine(a, b, graphics);
        }

        public void DrawPolygon(Polygon polygon)
        {
            using var graphics = GetGraphics();
            DrawPolygon(polygon, graphics);
        }

        public void DrawPolygons(IEnumerable<Polygon> polygons)
        {
            using var graphics = GetGraphics();
            foreach (var polygon in polygons)
            {
                DrawPolygon(polygon, graphics);
            }
        }

        private void DrawPolygon(Polygon polygon, Graphics graphics)
        {
            for(int i = 0; i < polygon.ColoredPoints.Count; ++i)
            {
                var (p1, p2) = polygon.GetNeighborVertices(i);

                DrawLine(p1.Point, p2.Point, graphics);
            }
        }

        private void DrawLine(Point a, Point b, Graphics graphics)
        {
            graphics.DrawLine(_pen, a, b);
        }

        private Graphics GetGraphics()
        {
            return Graphics.FromImage(_directBitmap.Bitmap);
        }
    }
}
