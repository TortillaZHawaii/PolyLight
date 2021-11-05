using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PolyLight.Figures;
using PolyLight.Drawing;
using PolyLight.Drawing.Render;

namespace PolyLight.PolyEditingModes
{
    internal sealed class AddPolyMode : EditingMode
    {
        private Polygon _poly;

        public AddPolyMode(EditRenderer renderer, Color polygonEdgesColor)
            : base(renderer)
        {
            _poly = new Polygon(new Point[0], polygonEdgesColor);
            _renderer.Polygons.Add(_poly);
        }

        public override void Exit()
        {
            RemovePolygonIfNotEnoughVertecies();
            _renderer.ClearDrawables();
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            AddVertexToLastEdge(e.Location);
        }

        private void RemovePolygonIfNotEnoughVertecies()
        {
            if (_poly.VertexCount < 3)
            {
                _renderer.Polygons.Remove(_poly);
            }
        }

        private void AddVertexToLastEdge(Point point)
        {
            int lastEdge = _poly.EdgesCount - 1;
            _poly.InsertVertex(lastEdge, point);
        }
    }
}
