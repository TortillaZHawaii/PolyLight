using System.Linq;
using System.Drawing;

namespace PolyLight.Figures
{
    internal static class PolygonExtensions
    {
        public static int MinHorizontal(this Polygon polygon)
        {
            return polygon.ColoredPoints.Min(k => k.X);
        }

        public static int MaxHorizontal(this Polygon polygon)
        {
            return polygon.ColoredPoints.Max(k => k.X);
        }

        public static int MinVertical(this Polygon polygon)
        {
            return polygon.ColoredPoints.Min(k => k.Y);
        }

        public static int MaxVertical(this Polygon polygon)
        {
            return polygon.ColoredPoints.Max(k => k.Y);
        }

        public static Point GetTopLeft(this Polygon polygon)
        {
            return new Point(MinHorizontal(polygon), MinVertical(polygon));
        }
    }
}
