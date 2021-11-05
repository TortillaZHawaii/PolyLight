using System;
using System.Drawing;
using PolyLight.Figures;

namespace PolyLight.Animations
{
    internal class PolygonMover
    {
        public Polygon Polygon => _polygon;

        private int _speedX;
        private int _speedY;

        private int _bitmapWidth;
        private int _bitmapHeight;

        private Polygon _polygon;

        public PolygonMover(Polygon polygon, int speedX, int speedY, Bitmap bitmap)
        {
            _polygon = polygon;

            _bitmapHeight = bitmap.Height;
            _bitmapWidth = bitmap.Width;

            _speedX = speedX;
            _speedY = speedY;
        }

        public PolygonMover(Polygon polygon, int speedX, int speedY, int bitmapWidth, int bitmapHeight)
        {
            _polygon = polygon;

            _bitmapHeight = bitmapHeight;
            _bitmapWidth = bitmapWidth;

            _speedX = speedX;
            _speedY = speedY;
        }

        public void Move()
        {
            AdjustDirection();
            _polygon.Move(_speedX, _speedY);
        }

        private void AdjustDirection()
        {
            AdjustHorizontalDirection();
            AdjustVerticalDirection();
        }

        private void AdjustHorizontalDirection()
        {
            if (IsOutsideRight())
            {
                _speedX = -Math.Abs(_speedX);
            }
            else if (IsOutsideLeft())
            {
                _speedX = Math.Abs(_speedX);
            }
        }

        private void AdjustVerticalDirection()
        {
            if (IsOutsideTop())
            {
                _speedY = Math.Abs(_speedY);
            }
            else if (IsOutsideBottom())
            {
                _speedY = -Math.Abs(_speedY);
            }
        }

        private bool IsOutsideRight()
        {
            return _polygon.MaxHorizontal() >= _bitmapWidth;
        }

        private bool IsOutsideLeft()
        {
            return _polygon.MinHorizontal() < 0;
        }

        private bool IsOutsideTop()
        {
            return _polygon.MinVertical() < 0;
        }

        private bool IsOutsideBottom()
        {
            return _polygon.MaxVertical() >= _bitmapHeight;
        }
    }
}
