using PolyLight.Drawing.Drawers;
using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolyLight.Animations
{
    internal class Animator
    {
        private List<PolygonMover> _movers;
        private IDrawer _drawer;
        private PictureBox _pictureBox;

        private Timer _timer;
        private int lastTick;
        private int frameRate;

        public Animator(IEnumerable<Polygon> polygons, int minSpeed, int maxSpeed, IDrawer drawer, int width, int height, PictureBox pictureBox)
        {
            _movers = new List<PolygonMover>();
            _drawer = drawer;

            var random = new Random();

            foreach(var polygon in polygons)
            {
                int speedX = random.Next(minSpeed, maxSpeed);
                int speedY = random.Next(minSpeed, maxSpeed);

                var mover = new PolygonMover(polygon, speedX, speedY, width, height);
                _movers.Add(mover);
            }
            _pictureBox = pictureBox;

            _timer = new System.Windows.Forms.Timer()
            {
                Interval = 30,
            };

            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            GenerateFrame();
            Console.WriteLine($"FPS: {CalculateFrameRate()}");
        }

        public int CalculateFrameRate()
        {
            int secondInMiliseconds = 1000;
            bool hasSecondPassed = Environment.TickCount - lastTick >= secondInMiliseconds;
            ++frameRate;

            if(hasSecondPassed)
            {
                lastTick = Environment.TickCount;
                int lastFramerate = frameRate;
                frameRate = 0;

                return lastFramerate;
            }

            return frameRate;
        }

        public void GenerateFrame()
        {
            DrawFilled();
            Move();
        }

        public void DrawFilled()
        {
            _drawer.Clear(Color.Transparent);

            foreach(var mover in _movers)
            {
                _drawer.DrawPolygon(mover.Polygon);
            }

            _pictureBox.Invalidate();
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
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
            _pictureBox.Invalidate();
        }

    }
}
