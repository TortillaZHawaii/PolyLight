using PolyLight.Figures;
using System.Drawing;

namespace PolyLight.Drawing.Fillers
{
    internal class SolidColorFiller : InterpolatedColorsFiller
    {
        public SolidColorFiller(Polygon polygon) : base(polygon)
        {
        }

        public override Color GetColor(int x, int y)
        {
            return _polygon.Color!.Value;
        }
    }
}
