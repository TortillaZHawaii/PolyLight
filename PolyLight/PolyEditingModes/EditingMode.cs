using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal abstract class EditingMode
    {
        protected EditRenderer _renderer;

        protected EditingMode(EditRenderer renderer)
        {
            _renderer = renderer;
        }

        public virtual void HandleMouseClick(MouseEventArgs e) { }
        public virtual void HandleMouseUp(MouseEventArgs e) { }
        public virtual void HandleMouseDown(MouseEventArgs e) { }
        public virtual void HandleMouseMove(MouseEventArgs e) { }
        public virtual void Exit() { }
    }
}
