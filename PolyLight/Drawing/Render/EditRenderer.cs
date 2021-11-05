using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyLight.Drawing.Render
{
    internal class EditRenderer : IRenderer
    {
        public List<Figures.Polygon> Polygons { get; init; }
        public List<IDrawable> ModeDrawables { get; init; }
        public Light Light { get; init; }

        private readonly BitmapDrawer _drawer;
        private readonly PictureBox _pictureBox;
        private readonly Color _backgroundColor;

        public EditRenderer(BitmapDrawer drawer, PictureBox pictureBox, Color backgroundColor)
        {
            Light = new Light();
            Polygons = new List<Figures.Polygon>();
            ModeDrawables = new List<IDrawable>();
            _drawer = drawer;
            _pictureBox = pictureBox;
            _backgroundColor = backgroundColor;
        }

        public void Redraw()
        {
            ClearBackground();
            RedrawPolygons();
            RedrawDrawables();
            UpdateDisplay();
        }

        public void ClearDrawables()
        {
            ModeDrawables.Clear();
        }

        private void UpdateDisplay()
        {
            _pictureBox.Invalidate();
        }

        private void ClearBackground()
        {
            _drawer.Clear(_backgroundColor);
        }

        private void RedrawDrawables()
        {
            foreach(var drawable in ModeDrawables)
            {
                drawable.Draw(_drawer);
            }
        }

        private void RedrawPolygons()
        {
            foreach(var polygon in Polygons)
            {
                polygon.Draw(_drawer);
            }
        }
    }
}
