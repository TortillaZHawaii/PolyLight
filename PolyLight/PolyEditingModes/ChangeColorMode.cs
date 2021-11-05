using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class ChangeColorMode : EditingMode
    {
        public ChangeColorMode(EditRenderer renderer) : base(renderer)
        {
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            if(IsHitOnVertexHandled(e.Location))
            { 
                return;
            }
            if(IsHitOnPolyMidHandled(e.Location))
            {
                return;
            }
        }

        private bool IsHitOnVertexHandled(Point point)
        {
            var hit = HitboxDetector.DetectHitOnVertex(point, _renderer.Polygons);

            if (hit != null)
            {
                var poly = hit.Value.hitPolygon;
                int vertex = hit.Value.vertexIndex;

                ColorVertex(poly, vertex);
                return true;
            }

            return false;
        }

        private bool IsHitOnPolyMidHandled(Point point)
        {
            var hit = HitboxDetector.DetectHitOnMiddleOfPolygon(point, _renderer.Polygons);

            if(hit != null)
            {
                ColorPolygon(hit);
                return true;
            }

            return false;
        }

        private void ColorVertex(Polygon polygon, int vertexNumber)
        {
            var oldColor = polygon.ColoredPoints[vertexNumber].Color;
            var newColor = GetColorFromDialog(oldColor);

            if(newColor != null)
            {
                polygon.SetVertexColor(vertexNumber, newColor.Value);
            }
        }

        private void ColorPolygon(Polygon polygon)
        {
            var firstVertexColor = polygon.ColoredPoints[0].Color;
            var newColor = GetColorFromDialog(firstVertexColor);

            if(newColor != null)
            {
                polygon.ChangeColor(newColor.Value);
            }
        }

        private Color? GetColorFromDialog(Color color)
        {
            var dialog = new ColorDialog();
            dialog.Color = color;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.Color;
            }

            return null;
        }
    }
}
