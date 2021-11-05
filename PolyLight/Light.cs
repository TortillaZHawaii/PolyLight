using System;
using System.Drawing;
using System.Numerics;

namespace PolyLight
{
    internal class Light
    {
        public Point Point { get; set; }
        public int X => Point.X;
        public int Y => Point.Y;
        public int Height { get; set; }

        public int M { get; set; }
        public float Ks { get; set; }
        public float Kd { get; set; }

        public Vector3 Position => new Vector3(X, Y, Height);

        public Color Color { get; set; }

        public Vector3 GetVersorToLight(Vector3 objectPosition)
        {
            var difference = Position - objectPosition;
            return Vector3.Normalize(difference);
        }
    }
}
