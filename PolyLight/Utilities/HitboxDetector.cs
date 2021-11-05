using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyLight.Figures;

namespace PolyLight.Utilities
{
    internal static class HitboxDetector
    {
        private static float _radius = 5f;

        public static (Polygon hitPolygon, int vertexIndex)? DetectHitOnVertex(Point point, List<Polygon> polygons)
        {
            foreach(var poly in polygons)
            {
                for(int i = 0; i < poly.VertexCount; ++i)
                {
                    var vertex = poly.ColoredPoints[i].Point;
                    if (PointExtensions.IsInRadius(point, vertex, _radius))
                    {
                        return (poly, i);
                    }
                }
            }

            return null;
        }

        public static Polygon? DetectHitOnMiddleOfPolygon(Point point, List<Polygon> polygons)
        {
            foreach(var poly in polygons)
            {
                var mid = poly.GetMidPoint();

                if(PointExtensions.IsInRadius(point, mid, _radius))
                {
                    return poly;
                }
            }

            return null;
        }
        
    }
}
