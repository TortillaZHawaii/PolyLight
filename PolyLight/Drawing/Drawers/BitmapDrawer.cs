using PolyLight.Drawing.Icons;
using PolyLight.Figures;
using System.Collections.Generic;
using System.Drawing;

namespace PolyLight.Drawing.Drawers
{
    internal class BitmapDrawer : IDrawer
    {
        protected DirectBitmap _directBitmap;
        Pen _pen;
        protected readonly float _defaultThickness = 2f;

        public BitmapDrawer(DirectBitmap directBitmap)
        {
            _directBitmap = directBitmap;
            _pen = new Pen(Color.Black);
        }

        public BitmapDrawer(DirectBitmap directBitmap, Pen pen)
        {
            _directBitmap = directBitmap;
            _pen = pen;
        }

        public virtual void Clear(Color color)
        {
            using var graphics = GetGraphics();
            graphics.Clear(color);
        }

        public virtual void DrawCircle(Circle circle)
        {
            using var graphics = GetGraphics();
            var topLeft = circle.TopLeft;
            
            if(circle.Filled)
            {
                var brush = new SolidBrush(circle.Color);
                graphics.FillEllipse(brush, topLeft.X, topLeft.Y, circle.Diameter, circle.Diameter);
            }
            else
            {
                var pen = new Pen(circle.Color, _defaultThickness);
                graphics.DrawEllipse(pen, topLeft.X, topLeft.Y, circle.Diameter, circle.Diameter);
            }
        }

        public virtual void DrawLine(Point a, Point b)
        {
            using var graphics = GetGraphics();
            DrawLine(a, b, graphics);
        }

        public virtual void DrawPolygon(Polygon polygon)
        {
            using var graphics = GetGraphics();
            DrawPolygon(polygon, graphics);
        }

        public virtual void DrawPolygons(IEnumerable<Polygon> polygons)
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
