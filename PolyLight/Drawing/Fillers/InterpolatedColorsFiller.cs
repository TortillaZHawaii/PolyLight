using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyLight.Drawing.Fillers
{
    internal class InterpolatedColorsFiller : Filler
    {
        protected Polygon _polygon;
        private const float height = 0f;

        public InterpolatedColorsFiller(Polygon polygon)
        {
            _polygon = polygon;
        }

        public override Color GetColor(int x, int y)
        {
            var point = new Point(x, y);
            return InterpolatedColor(point);
        }

        public override Vector3 GetNormalVector(int x, int y)
        {
            return Vector3.UnitZ;
        }

        public override Vector3 Position(int x, int y)
        {
            return new Vector3(x, y, height);
        }

        private Color InterpolatedColor(Point point)
        {
            float red, green, blue, alpha;
            red = green = blue = alpha = 0f;

            float weightSum = 0f;

            // weighted sum
            foreach (var polyPoint in _polygon.ColoredPoints)
            {
                float distanceSquared = PointExtensions.DistanceSquared(polyPoint.Point, point);
                var color = polyPoint.Color;

                alpha += color.A * 1/distanceSquared;
                red += color.R * 1/distanceSquared;
                green += color.G * 1/distanceSquared;
                blue += color.B * 1/distanceSquared;

                weightSum += 1/distanceSquared;
            }

            // weighted average
            alpha /= weightSum;
            red /= weightSum;
            green /= weightSum;
            blue /= weightSum;

            return Color.FromArgb(ClampFloat(alpha), ClampFloat(red), ClampFloat(green), ClampFloat(blue));
        }

        private byte ClampFloat(float a)
        {
            if (a < 0f)
                return 0;
            if (a > 255f)
                return 255;
            return (byte)a;
        }
    }
}
