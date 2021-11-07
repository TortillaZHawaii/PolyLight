using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Figures;
using PolyLight.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.PolyEditingModes
{
    internal class AddTexturesMode : EditingMode
    {
        public AddTexturesMode(Renderer renderer) : base(renderer)
        {
        }

        public override void Enter()
        {
            DrawCirclesOnPolygons(Color.Yellow);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            IsHitOnPolyMidHandled(e.Location);
        }

        private bool IsHitOnPolyMidHandled(Point point)
        {
            var hitPolygon = HitboxDetector.DetectHitOnMiddleOfPolygon(point, _renderer.Polygons);

            if (hitPolygon != null)
            {
                LoadTextures(hitPolygon);

                return true;
            }

            return false;
        }

        private void LoadTextures(Polygon poly)
        {
            poly.Texture = GetBitmapFromDialog("Pick texture");
            poly.HeightMap = GetBitmapFromDialog("Pick height map");
        }

        private DirectBitmap? GetBitmapFromDialog(string title)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG",
                Title = title,
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var filename = dialog.FileName;
                var bitmap = new Bitmap(filename);
                return new DirectBitmap(bitmap);
            }

            return null;
        }

        public override void Exit()
        {
            _renderer.ModeDrawables.Clear();
        }
    }
}
