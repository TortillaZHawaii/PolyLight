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
using PolyLight.Animations;
using System.Threading;
using PolyLight.Drawing.Icons;

namespace PolyLight
{
    public partial class MainForm : Form
    {
        private EditingMode? _mode;
        private readonly Renderer _renderer;
        private Animator? _animator;

        private IDrawer _drawer;

        private float _kd => (float)_kdTrackBar.Value / _kdTrackBar.Maximum;
        private float _ks => (float)_ksTrackBar.Value / _ksTrackBar.Maximum;
        private int _m => _mTrackBar.Value;

        public MainForm()
        {
            InitializeComponent();

            // initialize drawing space
            var backgroundColor = Color.Transparent;
            var bitmap = new DirectBitmap(_pictureBox.Width, _pictureBox.Height);
            var light = new Light()
            {
                Color = Color.White,
                Height = 100,
                Point = new(_pictureBox.Width / 2, _pictureBox.Height / 2)
            };
            //_drawer = new BitmapDrawer(bitmap);
            _drawer = new FillDrawer(bitmap, light);

            _pictureBox.Image = bitmap.Bitmap;
            _renderer = new Renderer(_drawer, _pictureBox, backgroundColor, light);
        }

        private void _createPolyButton_Click(object sender, EventArgs e)
        {
            var newMode = new AddPolyMode(_renderer, Color.White);
            SetMode(newMode);
        }

        private void _removeVerticesButton_Click(object sender, EventArgs e)
        {
            var newMode = new RemoveVerticesMode(_renderer);
            SetMode(newMode);
        }

        private void _splitEdgeButton_Click(object sender, EventArgs e)
        {
            var newMode = new SplitEdgeMode(_renderer);
            SetMode(newMode);
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
            _mode?.Enter();
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
            RedrawWhenInMode();
        }

        private void _pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseMove(e);
            RedrawWhenInMode();
        }

        private void _pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseUp(e);
            RedrawWhenInMode();
        }

        private void _pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseDown(e);
            RedrawWhenInMode();
        }

        private void RedrawWhenInMode()
        {
            if(_mode != null)
            {
                _renderer.Redraw();
            }
        }

        private void _playButton_Click(object sender, EventArgs e)
        {
            SetMode(null);
            if(_animator == null)
            {
                CreateAnimator();
            }
            _animator?.Play();
            SetEditingGroupBoxesStatus(false);
            _playButton.Enabled = false;
            _pauseButton.Enabled = true;
        }

        private void CreateAnimator()
        {
            var polies = _renderer.Polygons;
            _animator = new Animator(polies, 2, 10, _drawer, _pictureBox.Width, _pictureBox.Height, _pictureBox);
        }

        private void _pauseButton_Click(object sender, EventArgs e)
        {
            _animator?.Pause();
            _playButton.Enabled = true;
            _pauseButton.Enabled = false;
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            _animator?.Pause();
            _animator = null;
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
            SetMode(null);

            var dialog = new ColorDialog()
            {
                Color = _renderer.Light.Color,
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _renderer.Light.Color = dialog.Color;
            }
            _renderer.Redraw();
        }

        private void _moveLightButton_Click(object sender, EventArgs e)
        {
            var newMode = new LightMoveMode(_renderer);
            SetMode(newMode);
        }

        private void _setLightHeightButton_Click(object sender, EventArgs e)
        {
            SetMode(null);

            var dialog = new PickIntForm("Set height", "Give valid height, larger than 0",
                _renderer.Light.Height);

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _renderer.Light.Height = dialog.Value;
            }

            _renderer.Redraw();
        }

        private void _kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.Kd = _kd;
            _renderer.Redraw();
        }

        private void _ksTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.Ks = _ks;
            _renderer.Redraw();
        }

        private void _mTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.M = _m;
            _renderer.Redraw();
        }

        private void _pickTextureButton_Click(object sender, EventArgs e)
        {
            var newMode = new AddTexturesMode(_renderer);
            SetMode(newMode);
        }
    }
}
