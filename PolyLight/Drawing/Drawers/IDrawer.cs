using PolyLight.Drawing.Icons;
using PolyLight.Figures;
using System.Collections.Generic;
using System.Drawing;

namespace PolyLight.Drawing.Drawers
{
    internal interface IDrawer
    {
        public void Clear(Color color);
        public void DrawCircle(Circle circle);
        public void DrawLine(Point a, Point b);
        public void DrawPolygon(Polygon polygon);
        public void DrawPolygons(IEnumerable<Polygon> polygons);
    }
}
