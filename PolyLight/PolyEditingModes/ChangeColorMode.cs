using PolyLight.Drawing;
using PolyLight.Drawing.Icons;
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
        public ChangeColorMode(Renderer renderer) : base(renderer)
        {
        }

        public override void Enter()
        {
            DrawColoredCirclesOnPolygons();
            DrawColoredCirclesOnVertieces();
        }

        protected void DrawColoredCirclesOnVertieces()
        {
            foreach (var poly in _renderer.Polygons)
            {
                foreach (var point in poly.ColoredPoints)
                {
                    var circle = new Circle()
                    {
                        Color = point.Color,
                        Radius = (int)HitboxDetector.HitboxRadius,
                        Filled = true,
                        Point = point.Point
                    };

                    _renderer.ModeDrawables.Add(circle);
                }
            }
        }

        protected void DrawColoredCirclesOnPolygons()
        {
            foreach (var poly in _renderer.Polygons)
            {
                var circle = new Circle()
                {
                    Color = poly.Color ?? Color.White,
                    Radius = (int)HitboxDetector.HitboxRadius,
                    Filled = poly.Color != null,
                    Point = poly.GetMidPoint()
                };

                _renderer.ModeDrawables.Add(circle);
            }
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

                _renderer.ClearDrawables();
                ColorVertex(poly, vertex);
                Enter();
                return true;
            }

            return false;
        }

        private bool IsHitOnPolyMidHandled(Point point)
        {
            var hit = HitboxDetector.DetectHitOnMiddleOfPolygon(point, _renderer.Polygons);

            if(hit != null)
            {
                _renderer.ClearDrawables();
                ColorPolygon(hit);
                Enter();
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
