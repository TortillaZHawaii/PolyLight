using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class RemoveVerticesMode : EditingMode
    {
        public RemoveVerticesMode(Renderer renderer) : base(renderer)
        {
        }

        public override void Enter()
        {
            DrawCirclesOnVertiecies(Color.Red);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var hit = HitboxDetector.DetectHitOnVertex(e.Location, _renderer.Polygons);

            if(hit != null)
            {
                Polygon poly = hit.Value.hitPolygon;
                int vertexNumber = hit.Value.vertexIndex;

                _renderer.ClearDrawables();
                poly.RemoveVertex(vertexNumber);
                Enter();
            }
        }

    }
}
