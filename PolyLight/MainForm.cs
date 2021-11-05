using PolyLight.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyLight.PolyEditingModes;
using PolyLight.Drawing;
using PolyLight.Drawing.Render;
using PolyLight.Drawing.Drawers;

namespace PolyLight
{
    public partial class MainForm : Form
    {
        private EditingMode? _mode;
        private readonly EditRenderer _renderer;

        private float _kd => (float)_kdTrackBar.Value / _kdTrackBar.Maximum;
        private float _ks => (float)_ksTrackBar.Value / _ksTrackBar.Maximum;
        private int _m => _mTrackBar.Value;

        public MainForm()
        {
            InitializeComponent();

            // initialize drawing space
            var backgroundColor = Color.Transparent;
            var bitmap = new DirectBitmap(_pictureBox.Width, _pictureBox.Height);
            var drawer = new BitmapDrawer(bitmap);
            
            _pictureBox.Image = bitmap.Bitmap;
            _renderer = new EditRenderer(drawer, _pictureBox, backgroundColor);

            FillTest(bitmap);
        }

        private void FillTest(DirectBitmap bitmap)
        {
            var points = new List<Point>();
            points.Add(new(0,0));
            points.Add(new(200, 200));
            points.Add(new(400, 0));
            points.Add(new(200, 400));

            var poly = new Polygon(
                points,
                Color.White
            );

            //poly.SetVertexColor(0, Color.Red);
            poly.SetVertexColor(2, Color.Blue);
            poly.SetVertexColor(0, Color.Red);


            var fill = new FillDrawer(bitmap, new Light()
            {
                Color = Color.White,
                Height = 15,
                Kd = 0.5f,
                Ks = 0.5f,
                M = 100,
            });

            fill.Draw(poly);
            _pictureBox.Invalidate();
        }


        private void _createPolyButton_Click(object sender, EventArgs e)
        {
            var newMode = new AddPolyMode(_renderer, Color.Black);
            SetMode(newMode);
        }

        private void _removeVerticesButton_Click(object sender, EventArgs e)
        {
            var newMode = new RemoveVerticesMode(_renderer);
            SetMode(newMode);
        }

        private void _splitEdgeButton_Click(object sender, EventArgs e)
        {
        }

        private void _movePolygonButton_Click(object sender, EventArgs e)
        {
            var newMode = new MovePolyMode(_renderer);
            SetMode(newMode);
        }

        private void _pickColorButton_Click(object sender, EventArgs e)
        {
            var newMode = new ChangeColorMode(_renderer);
            SetMode(newMode);
        }

        private void SetMode(EditingMode? mode)
        {
            _mode?.Exit();
            _mode = mode;
            _renderer.Redraw();
        }

        private void _pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                _mode?.HandleMouseClick(e);
            }
            else if(e.Button == MouseButtons.Right)
            {
                SetMode(null);
            }
            _renderer.Redraw();
        }

        private void _pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseMove(e);
            _renderer.Redraw();
        }

        private void _pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseUp(e);
            _renderer.Redraw();
        }

        private void _pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseDown(e);
            _renderer.Redraw();
        }

        private void _playButton_Click(object sender, EventArgs e)
        {
            SetEditingGroupBoxesStatus(false);
            _playButton.Enabled = false;
            _pauseButton.Enabled = true;
        }

        private void _pauseButton_Click(object sender, EventArgs e)
        {
            _playButton.Enabled = true;
            _pauseButton.Enabled = false;
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            SetEditingGroupBoxesStatus(true);
            _playButton.Enabled = true;
            _pauseButton.Enabled = false;
        }

        private void SetEditingGroupBoxesStatus(bool status)
        {
            _polygonGroupBox.Enabled = status;
            _lightGroupBox.Enabled = status;
        }

        private void _pickLightColorButton_Click(object sender, EventArgs e)
        {

        }

        private void _moveLightButton_Click(object sender, EventArgs e)
        {

        }

        private void _setLightHeightButton_Click(object sender, EventArgs e)
        {

        }
    }
}
