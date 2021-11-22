using PolyLight.Drawing.Drawers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.Drawing.Render
{
    internal class Renderer : IRenderer
    {
        public List<Figures.Polygon> Polygons { get; init; }
        public List<IDrawable> ModeDrawables { get; init; }
        public Light Light { get; init; }
        public IDrawer Drawer { get; set; }

        private readonly PictureBox _pictureBox;
        private readonly Color _backgroundColor;

        private readonly Timer _timer;
        private bool _dirty = false;

        public Renderer(IDrawer drawer, PictureBox pictureBox, Color backgroundColor, Light light)
        {
            Light = light;
            Polygons = new List<Figures.Polygon>();
            ModeDrawables = new List<IDrawable>();
            Drawer = drawer;
            _pictureBox = pictureBox;
            _backgroundColor = backgroundColor;

            _timer = new Timer()
            {
                Interval = 25,
            };

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }


        public void MarkDirty()
        {
            _dirty = true;
        }
        
        private void Timer_Tick(object? sender, System.EventArgs e)
        {
            if(_dirty)
            {
                Redraw();
            }
        }

        private void Redraw()
        {
            ClearBackground();
            RedrawPolygons();
            RedrawDrawables();
            UpdateDisplay();
            _dirty = false;
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
            Drawer.Clear(_backgroundColor);
        }

        private void RedrawDrawables()
        {
            foreach(var drawable in ModeDrawables)
            {
                drawable.Draw(Drawer);
            }
        }

        private void RedrawPolygons()
        {
            foreach(var polygon in Polygons)
            {
                Drawer.DrawPolygon(polygon);
            }
        }
    }
}
