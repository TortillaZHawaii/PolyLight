using PolyLight.Drawing;
using PolyLight.Drawing.Icons;
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

        protected override void DrawCirclesOnPolygons(Color color)
        {
            foreach (var poly in _renderer.Polygons)
            {
                var circle = new Circle()
                {
                    Color = color,
                    Radius = (int)HitboxDetector.HitboxRadius,
                    Filled = poly.Texture != null && poly.HeightMap != null,
                    Point = poly.GetMidPoint()
                };

                _renderer.ModeDrawables.Add(circle);
            }
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

                ReloadIcons();

                return true;
            }

            return false;
        }

        private void ReloadIcons()
        {
            Exit();
            Enter();
        }

        private static void LoadTextures(Polygon poly)
        {
            poly.Texture = GetBitmapFromDialog("Pick texture");
            poly.HeightMap = GetBitmapFromDialog("Pick height map");
        }

        private static DirectBitmap? GetBitmapFromDialog(string title)
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
