using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class RemoveVerticesMode : EditingMode
    {
        public RemoveVerticesMode(EditRenderer renderer) : base(renderer)
        {
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var hit = HitboxDetector.DetectHitOnVertex(e.Location, _renderer.Polygons);

            if(hit != null)
            {
                Polygon poly = hit.Value.hitPolygon;
                int vertexNumber = hit.Value.vertexIndex;

                poly.RemoveVertex(vertexNumber);
            }
        }

    }
}
