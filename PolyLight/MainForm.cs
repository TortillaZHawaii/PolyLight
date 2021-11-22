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

        private readonly IDrawer _drawer;

        private float _kd => (float)_kdTrackBar.Value / _kdTrackBar.Maximum;
        private float _ks => (float)_ksTrackBar.Value / _ksTrackBar.Maximum;
        private int _m => _mTrackBar.Value;
        private int _minSpeed = 2;
        private int _maxSpeed = 10;

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
                Point = new(_pictureBox.Width / 2, _pictureBox.Height / 2),
                Kd = 0.15f,
                Ks = 0.2f,
                M = 1,
            };

            _drawer = new FillDrawer(bitmap, light);

            _pictureBox.Image = bitmap.Bitmap;
            _renderer = new Renderer(_drawer, _pictureBox, backgroundColor, light);
            
            _minSpeedNumeric.Value = _minSpeed;
            _maxSpeedNumeric.Value = _maxSpeed;
            
            _ksTrackBar.Value = (int)(light.Ks * _ksTrackBar.Maximum);
            _kdTrackBar.Value = (int)(light.Kd * _kdTrackBar.Maximum);
            _mTrackBar.Value = light.M;
            _lightHeightNumericUpDown.Value = light.Height;
        }

        private void CreatePolyButton_Click(object sender, EventArgs e)
        {
            var newMode = new AddPolyMode(_renderer, Color.White);
            SetMode(newMode);
        }

        private void RemoveVerticesButton_Click(object sender, EventArgs e)
        {
            var newMode = new RemoveVerticesMode(_renderer);
            SetMode(newMode);
        }

        private void SplitEdgeButton_Click(object sender, EventArgs e)
        {
            var newMode = new SplitEdgeMode(_renderer);
            SetMode(newMode);
        }

        private void MovePolygonButton_Click(object sender, EventArgs e)
        {
            var newMode = new MovePolyMode(_renderer);
            SetMode(newMode);
        }

        private void PickColorButton_Click(object sender, EventArgs e)
        {
            var newMode = new ChangeColorMode(_renderer);
            SetMode(newMode);
        }

        private void SetMode(EditingMode? mode)
        {
            _mode?.Exit();
            _mode = mode;
            _mode?.Enter();
            _renderer.MarkDirty();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
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

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseMove(e);
            RedrawWhenInMode();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseUp(e);
            RedrawWhenInMode();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mode?.HandleMouseDown(e);
            RedrawWhenInMode();
        }

        private void RedrawWhenInMode()
        {
            if(_mode != null)
            {
                _renderer.MarkDirty();
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
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
            _animator = new Animator(polies,
                _minSpeed, _maxSpeed, _drawer, _pictureBox.Width, _pictureBox.Height, _pictureBox);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _animator?.Pause();
            _playButton.Enabled = true;
            _pauseButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
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
            _speedRangeGroupBox.Enabled = status;
        }

        private void PickLightColorButton_Click(object sender, EventArgs e)
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
            _renderer.MarkDirty();
        }

        private void MoveLightButton_Click(object sender, EventArgs e)
        {
            var newMode = new LightMoveMode(_renderer);
            SetMode(newMode);
        }

        private void SetLightHeightButton_Click(object sender, EventArgs e)
        {
            SetMode(null);

            var dialog = new PickIntForm("Set height", "Give valid height, larger than 0",
                _renderer.Light.Height);

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _renderer.Light.Height = dialog.Value;
            }

            _renderer.MarkDirty();
        }

        private void KdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.Kd = _kd;
            _renderer.MarkDirty();
        }

        private void KsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.Ks = _ks;
            _renderer.MarkDirty();
        }

        private void MTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _renderer.Light.M = _m;
            _renderer.MarkDirty();
        }

        private void PickTextureButton_Click(object sender, EventArgs e)
        {
            var newMode = new AddTexturesMode(_renderer);
            SetMode(newMode);
        }

        private void MinSpeedNumeric_ValueChanged(object sender, EventArgs e)
        {
            _minSpeed = (int)_minSpeedNumeric.Value;
            if(_maxSpeed < _minSpeed)
            {
                // should be in setter
                _maxSpeed = _minSpeed;
                _maxSpeedNumeric.Value = _maxSpeed;
            }
        }

        private void MaxSpeedNumeric_ValueChanged(object sender, EventArgs e)
        {
            _maxSpeed = (int)_maxSpeedNumeric.Value;
            if(_maxSpeed < _minSpeed)
            {
                _minSpeed = _maxSpeed;
                _minSpeedNumeric.Value = _minSpeed;
            }
        }

        private void LightHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int newLightHeight = (int)_lightHeightNumericUpDown.Value;
            _renderer.Light.Height = newLightHeight;

            _renderer.MarkDirty();
        }
    }
}
