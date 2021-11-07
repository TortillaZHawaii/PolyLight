using PolyLight.Drawing.Drawers;
using System.Drawing;

namespace PolyLight.Drawing.Icons
{
    internal class Circle : IDrawable
    {
        private int _radius;

        public Point Point { get; set; }
        public int Radius 
        { 
            get => _radius; 
            set { _radius = value; } 
        }
        public int Diameter 
        {
            get => _radius * 2;
            set {  _radius = value / 2; }
        }

        public Color Color { get; set; } = Color.Black;

        public Point TopLeft => new(Point.X - Radius, Point.Y - Radius);

        public Point BottomRight => new(Point.X + Radius, Point.Y + Radius);

        public bool Filled { get; set; } = false;

        public void Draw(IDrawer drawer)
        {
            drawer.DrawCircle(this);
        }
    }
}
