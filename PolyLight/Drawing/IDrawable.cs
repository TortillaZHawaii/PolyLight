using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyLight.Drawing
{
    internal interface IDrawable
    {
        public void Draw(BitmapDrawer drawer);
    }
}
