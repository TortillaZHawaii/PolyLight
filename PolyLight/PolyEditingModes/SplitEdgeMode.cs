using PolyLight.Drawing.Icons;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class SplitEdgeMode : EditingMode
    {
        public SplitEdgeMode(Renderer renderer) : base(renderer)
        {
        }

        public override void Enter()
        {
            DrawCirclesOnEdgesMiddle();    
        }

        private void DrawCirclesOnEdgesMiddle()
        {
            foreach(var poly in _renderer.Polygons)
            {
                for(int i = 0; i < poly.EdgesCount; ++i)
                {
                    var (before, after) = poly.GetNeighborVertices(i);
                    var midEdgePoint = PointExtensions.GetMidPoint(before, after);

                    var circle = new Circle()
                    {
                        Color = Color.YellowGreen,
                        Radius = (int)HitboxDetector.HitboxRadius,
                        Filled = false,
                        Point = midEdgePoint,
                    };

                    _renderer.ModeDrawables.Add(circle);
                }
            }
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var hit = HitboxDetector.DetectHitOnEdgeMiddle(e.Location, _renderer.Polygons);

            if (hit != null)
            {
                Polygon poly = hit.Value.hitPolygon;
                int edgeIndex = hit.Value.edgeIndex;

                _renderer.ClearDrawables();
                poly.SplitEdge(edgeIndex);
                Enter();
            }
        }

    }
}
