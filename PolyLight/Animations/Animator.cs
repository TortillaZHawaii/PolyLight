using PolyLight.Drawing;
using PolyLight.Drawing.Drawers;
using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PolyLight.Animations
{
    internal class Animator
    {
        private List<PolygonMover> _movers;
        private FillDrawer _drawer;
        private Thread? _animation;

        public Animator(IEnumerable<Polygon> polygons, int minSpeed, int maxSpeed, DirectBitmap bitmap, Light light)
        {
            _movers = new List<PolygonMover>();
            _drawer = new FillDrawer(bitmap, light);

            int width = bitmap.Width;
            int height = bitmap.Height;
            var random = new Random();

            foreach(var polygon in polygons)
            {
                int speedX = random.Next(minSpeed, maxSpeed);
                int speedY = random.Next(minSpeed, maxSpeed);

                var mover = new PolygonMover(polygon, speedX, speedY, width, height);
                _movers.Add(mover);
            }
        }

        public void GenerateFrame()
        {
            DrawFilled();
            Move();
        }

        public void DrawFilled()
        {
            _drawer.Clear();

            foreach(var mover in _movers)
            {
                _drawer.Draw(mover.Polygon);
            }
        }

        public void Move()
        {
            foreach(var mover in _movers)
            {
                mover.Move();
            }
        }

        public void Play()
        {
            // start animation thread
            _animation = new Thread(() =>
            {
                while(true)
                {
                    GenerateFrame();
                }
            });
        }

        public void Pause()
        {
            _animation?.Suspend();
        }

    }
}
