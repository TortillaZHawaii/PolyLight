using PolyLight.Drawing.Icons;
using PolyLight.Drawing.Render;
using PolyLight.Utilities;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class LightMoveMode : EditingMode
    {
        private Light _light;

        public LightMoveMode(Renderer renderer) : base(renderer)
        {
            _light = renderer.Light;
        }

        public override void Enter()
        {
            var circle = new Circle()
            {
                Radius = 20,
                Color = _light.Color,
                Point = _light.Point,
                Filled = true,
            };

            _renderer.ModeDrawables.Add(circle);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            _renderer.ClearDrawables();
            _light.Point = e.Location;
            Enter();
        }
    }
}
