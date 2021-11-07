using System.Drawing;
using System.Numerics;

namespace PolyLight.Drawing.Fillers
{
    internal abstract class Filler
    {
        public abstract Vector3 GetNormalVector(int x, int y);
        public abstract Vector3 Position(int x, int y);
        public abstract Color GetColor(int x, int y);
    }
}
