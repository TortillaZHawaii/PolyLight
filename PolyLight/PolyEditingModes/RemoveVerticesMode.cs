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
            DrawCirclesOnPolygons(Color.Red);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var hitOnVertex = HitboxDetector.DetectHitOnVertex(e.Location, _renderer.Polygons);

            if(hitOnVertex != null)
            {
                Polygon poly = hitOnVertex.Value.hitPolygon;
                int vertexNumber = hitOnVertex.Value.vertexIndex;

                HandleHitOnVertex(poly, vertexNumber);
                return;
            }

            var hitOnCentre = HitboxDetector.DetectHitOnMiddleOfPolygon(e.Location, _renderer.Polygons);

            if(hitOnCentre != null)
            {
                HandleHitOnMid(hitOnCentre);
            }
        }

        private void HandleHitOnVertex(Polygon polygon, int vertexNumber)
        {
            polygon.RemoveVertex(vertexNumber);
            ReloadIcons();
        }

        private void HandleHitOnMid(Polygon polygon)
        {
            _renderer.Polygons.Remove(polygon);
            ReloadIcons();
        }

        private void ReloadIcons()
        {
            Enter();
            Exit();
        }

        public override void Exit()
        {
            _renderer.ClearDrawables();
        }
    }
}
