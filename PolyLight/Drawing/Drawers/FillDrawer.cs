using PolyLight.Drawing.Fillers;
using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyLight.Drawing.Drawers
{
    internal class FillDrawer
    {
        private DirectBitmap _directBitmap;
        private Light _light;

        public FillDrawer(DirectBitmap bitmap, Light light)
        {
            _directBitmap = bitmap;
            _light = light;
        }

        public void Clear()
        {
        }

        public void Draw(Polygon polygon)
        {
            if(polygon.Texture != null && polygon.HeightMap != null)
            {
                DrawWithHeightMap(polygon);
            }
            else
            {
                DrawColored(polygon);
            }
        }

        private void DrawWithHeightMap(Polygon polygon)
        {
            var filler = new HeightMapFiller(polygon);
            ScanLine(polygon, filler);
        }

        private void DrawColored(Polygon polygon)
        {
            var filler = new InterpolatedColorsFiller(polygon);
            ScanLine(polygon, filler);
        }

        private void ScanLine(Polygon polygon, Filler filler)
        {
            var aetTable = PrepareAET(polygon);
            DrawAetTable(aetTable, polygon.MinHorizontal(), filler);
        }

        private List<int>[] PrepareAET(Polygon polygon)
        {
            var points = polygon.Points.AsParallel().OrderBy(p => p.Y).ToArray();
            var pointsList = new LinkedList<Point>(points);

            // polygon has more than 3 vertices so it will be fine
            int minY = pointsList.First!.Value.Y;
            int maxY = pointsList.Last!.Value.Y;
            int height = maxY - minY + 1;

            var limits = new List<int>[height];
            var aet = new List<(int lowerY, float currentX, float m)>();

            for(int y = minY; y <= maxY; ++y)
            {
                var firstPoint = pointsList.First!.Value;
                if(firstPoint.Y == y)
                {
                    // delete ending here
                    aet.RemoveAll(k => k.lowerY == y);
                }

                while(firstPoint.Y == y && y != maxY)
                {
                    // add new edges
                    var (before, after) = polygon.GetNeighborPoints(firstPoint);

                    // beforeEdge
                    if(before.Y > firstPoint.Y)
                    {
                        AddEdgeToAet(firstPoint, before, aet);
                    }

                    // afterEdge
                    if(after.Y > firstPoint.Y)
                    {
                        AddEdgeToAet(firstPoint, after, aet);
                    }

                    pointsList.RemoveFirst();
                    firstPoint = pointsList.First!.Value;
                }

                // add to limits
                limits[y - minY] = aet.AsParallel().OrderBy(k => k.currentX).Select(k => (int)k.currentX).ToList();

                // update x
                for(int i = 0; i < aet.Count; ++i)
                {
                    aet[i] = (aet[i].lowerY, aet[i].currentX + aet[i].m, aet[i].m);
                }
            }

            return limits;
        }

        private void AddEdgeToAet(Point upper, Point lower, List<(int lowerY, float currentX, float m)> aet)
        {
            float m = (float)(upper.X - lower.X) / (upper.Y - lower.Y);
            aet.Add((lower.Y, upper.X, m));
        }

        private void DrawAetTable(List<int>[] limitsTab, int minY, Filler filler)
        {
            Parallel.For(0, limitsTab.Length, index =>
            {
                int y = index + minY;
                var limits = limitsTab[index];

                for (int i = 0; i < limits.Count - 1; i += 2)
                {
                    int startX = limits[i];
                    int endX = limits[i + 1];

                    for (int x = startX; x <= endX; ++x)
                    {
                        var position = filler.Position(x, y);
                        var normal = filler.GetNormalVector(x, y);
                        var pixelColor = filler.GetColor(x, y);

                        var afterLambertColor = Lambert(_light.Kd, _light.Ks, _light.M, pixelColor, normal, position);
                        _directBitmap.SetPixel(x, y, afterLambertColor);
                    }
                }
            });
        }

        private Color Lambert(float kd, float ks, int m, Color color, Vector3 normal, Vector3 position)
        {
            var lightColor = GetVectorFromColor(_light.Color); // l_l
            var objectColor = GetVectorFromColor(color); // l_o

            var mixedColors = lightColor * objectColor;

            var toEye = Vector3.UnitZ; // straight up // V
            var toLight = _light.GetVersorToLight(position); // L

            float cosNL = Vector3.Dot(normal, toLight);

            var r = 2 * cosNL * normal - toLight;

            float cosVR = Vector3.Dot(toEye, r);

            var lambertColor = (kd * mixedColors * cosNL) + (ks * mixedColors * MathF.Pow(cosVR, m));
            return GetColorFromVector(lambertColor);
        }

        private static Vector3 GetVectorFromColor(Color color)
        {
            float red = color.R / 255f;
            float green = color.G / 255f;
            var blue = color.B / 255f;

            return new Vector3(red, green, blue);
        }

        private static Color GetColorFromVector(Vector3 vector)
        {
            byte red = ClampToByte(vector.X * 255);
            byte green = ClampToByte(vector.Y * 255);
            byte blue = ClampToByte(vector.Z * 255);

            return Color.FromArgb(red, green, blue);
        }

        private static byte ClampToByte(float x)
        {
            if(x < 0)
            {
                return 0;
            }

            return (byte)MathF.Min(x, 255);
        }
    }

    public class ScanLine
    {
        public int Y { get; }
        public List<Point> Points { get; }

        public ScanLine(int y, List<Point> points)
        {
            Y = y;
            Points = points;
        }
    }
}
