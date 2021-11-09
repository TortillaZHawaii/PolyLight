using PolyLight.Drawing;
using PolyLight.Drawing.Icons;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal abstract class EditingMode
    {
        protected Renderer _renderer;

        protected EditingMode(Renderer renderer)
        {
            _renderer = renderer;
        }


        public virtual void HandleMouseClick(MouseEventArgs e) { }
        public virtual void HandleMouseUp(MouseEventArgs e) { }
        public virtual void HandleMouseDown(MouseEventArgs e) { }
        public virtual void HandleMouseMove(MouseEventArgs e) { }
        public virtual void Enter() { _renderer.MarkDirty(); }
        public virtual void Exit() { _renderer.ModeDrawables.Clear(); }

        protected virtual void DrawCirclesOnVertiecies(Color color)
        {
            foreach(var poly in _renderer.Polygons)
            {
                foreach(var point in poly.ColoredPoints)
                {
                    var circle = new Circle()
                    {
                        Color = color,
                        Radius = (int)HitboxDetector.HitboxRadius,
                        Filled = true,
                        Point = point.Point
                    };

                    _renderer.ModeDrawables.Add(circle);
                }
            }
        }

        protected virtual void DrawCirclesOnPolygons(Color color)
        {
            foreach(var poly in _renderer.Polygons)
            {
                var circle = new Circle()
                {
                    Color = color,
                    Radius = (int)HitboxDetector.HitboxRadius,
                    Filled = false,
                    Point = poly.GetMidPoint()
                };

                _renderer.ModeDrawables.Add(circle);
            }
        }
    }
}
