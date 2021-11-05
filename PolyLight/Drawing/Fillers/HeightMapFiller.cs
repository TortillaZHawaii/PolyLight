using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyLight.Drawing.Fillers
{
    internal class HeightMapFiller : Filler
    {
        private Polygon _polygon;
        private Bitmap _texture;
        private Bitmap _heightMap;
        private Point _topLeft;

        public HeightMapFiller(Polygon polygon)
        {
            _polygon = polygon;
            if (_polygon.Texture == null || _polygon.HeightMap == null)
                throw new ArgumentException("Textures are null");

            _texture = _polygon.Texture;
            _heightMap = _polygon.HeightMap;
            _topLeft = _polygon.GetTopLeft();
        }


        public override Color GetColor(int x, int y)
        {
            int width = _texture.Width;
            int height = _texture.Height;

            var relative = GetRelativePositionToPolygon(x, y);

            return _texture.GetPixel(relative.X % width, relative.Y % height);
        }

        public override Vector3 GetNormalVector(int x, int y)
        {
            int width = _heightMap.Width;
            var height = _heightMap.Height;

            var relative = GetRelativePositionToPolygon(x, y);

            var left = _heightMap.GetPixel((relative.X - 1 + width) % width, relative.Y);
            var top = _heightMap.GetPixel(relative.X, (relative.Y - 1 + height) % height);
            var right = _heightMap.GetPixel((relative.X + 1) % width, relative.Y);
            var bottom = _heightMap.GetPixel(relative.X, (relative.Y + 1) % width);

            // we can assume that since the colors are on the gray scale 0 <= r = g = b <= 255
            var vector = new Vector3()
            {
                X = GetFloatFromColor(right) - GetFloatFromColor(left),
                Y = GetFloatFromColor(bottom) - GetFloatFromColor(top),
                Z = 1f,
            };

            return Vector3.Normalize(vector);
        }

        public override Vector3 Position(int x, int y)
        {
            int width = _heightMap.Width;
            var height = _heightMap.Height;

            var relative = GetRelativePositionToPolygon(x, y);

            var color = _heightMap.GetPixel(relative.X % width, relative.Y % height);

            return new Vector3()
            {
                X = x,
                Y = y,
                Z = GetFloatFromColor(color)
            };
        }

        private Point GetRelativePositionToPolygon(int x, int y)
        {
            return new Point(x - _topLeft.X, y - _topLeft.Y);
        }

        private float GetFloatFromColor(Color color)
        {
            return Get01FloatFromByte(color.R);
        }

        private float Get01FloatFromByte(byte a)
        {
            return a / 255f;
        }
    }
}
