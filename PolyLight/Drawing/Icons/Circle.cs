using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Draw(BitmapDrawer drawer)
        {
            drawer.DrawCircle(this);
        }
    }
}
