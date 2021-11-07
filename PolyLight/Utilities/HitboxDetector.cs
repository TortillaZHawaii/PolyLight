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
        public static float HitboxRadius = 5f;

        public static (Polygon hitPolygon, int vertexIndex)? DetectHitOnVertex(Point point, List<Polygon> polygons)
        {
            foreach(var poly in polygons)
            {
                for(int i = 0; i < poly.VertexCount; ++i)
                {
                    var vertex = poly.ColoredPoints[i].Point;
                    if (PointExtensions.IsInRadius(point, vertex, HitboxRadius))
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

                if(PointExtensions.IsInRadius(point, mid, HitboxRadius))
                {
                    return poly;
                }
            }

            return null;
        }

        public static (Polygon hitPolygon, int edgeIndex)? DetectHitOnEdgeMiddle(Point point, List<Polygon> polygons)
        {
            foreach (var poly in polygons)
            {
                for (int i = 0; i < poly.EdgesCount; ++i)
                {
                    var (before, after) = poly.GetNeighborVertices(i);
                    var vertex = PointExtensions.GetMidPoint(before, after);

                    if (PointExtensions.IsInRadius(point, vertex, HitboxRadius))
                    {
                        return (poly, i);
                    }
                }
            }

            return null;
        }
    }
}
