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

        private bool _isOutsideX = false;
        private bool _isOutsideY = false;

        private readonly int _minSpeed;
        private readonly int _maxSpeed;

        private readonly int _bitmapWidth;
        private readonly int _bitmapHeight;

        private readonly Polygon _polygon;
        private readonly Random _rng;

        public PolygonMover(Polygon polygon, int minSpeed, int maxSpeed, Random rng, Bitmap bitmap) : 
            this(polygon, minSpeed, maxSpeed, rng, bitmap.Width, bitmap.Height)
        {

        }

        public PolygonMover(Polygon polygon, int minSpeed, int maxSpeed, Random rng, int bitmapWidth, int bitmapHeight)
        {
            _polygon = polygon;

            _bitmapHeight = bitmapHeight;
            _bitmapWidth = bitmapWidth;

            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;

            _rng = rng;

            _speedX = GetRandomSpeed();
            _speedY = GetRandomSpeed();
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
                _isOutsideX = true;
                _speedX = -Math.Abs(_speedX);
                return;
            }
            
            if (IsOutsideLeft())
            {
                _isOutsideX = true;
                _speedX = Math.Abs(_speedX);
                return;
            }

            // to prevent jittering when part of the polygon is outside
            ChangeSpeedIfCameBackToViewableArea(ref _isOutsideX, ref _speedY);
        }

        private void AdjustVerticalDirection()
        {
            if (IsOutsideTop())
            {
                _isOutsideY = true;
                _speedY = Math.Abs(_speedY);
                return;
            }
            if (IsOutsideBottom())
            {
                _isOutsideY = true;
                _speedY = -Math.Abs(_speedY);
                return;
            }

            ChangeSpeedIfCameBackToViewableArea(ref _isOutsideY, ref _speedX);
        }

        private void ChangeSpeedIfCameBackToViewableArea(ref bool isOutside, ref int speed)
        {
            if(isOutside)
            {
                isOutside = false;
                speed = GetRandomSpeed();
            }
        }

        private int GetRandomSpeed()
        {
            return _rng.Next(_minSpeed, _maxSpeed) * GetRandomSign();
        }

        private int GetRandomSign()
        {
            int sign = _rng.Next(0, 2) * 2 - 1;
            return sign;
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
