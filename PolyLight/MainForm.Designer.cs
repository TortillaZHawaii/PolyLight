namespace PolyLight
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._menuGroupBox = new System.Windows.Forms.GroupBox();
            this._animationGroupBox = new System.Windows.Forms.GroupBox();
            this._speedRangeGroupBox = new System.Windows.Forms.GroupBox();
            this._maxSpeedRangeLabel = new System.Windows.Forms.Label();
            this._minSpeedRangeLabel = new System.Windows.Forms.Label();
            this._stopButton = new System.Windows.Forms.Button();
            this._pauseButton = new System.Windows.Forms.Button();
            this._playButton = new System.Windows.Forms.Button();
            this._lightGroupBox = new System.Windows.Forms.GroupBox();
            this._mLabel = new System.Windows.Forms.Label();
            this._mTrackBar = new System.Windows.Forms.TrackBar();
            this._ksLabel = new System.Windows.Forms.Label();
            this._ksTrackBar = new System.Windows.Forms.TrackBar();
            this._kdLabel = new System.Windows.Forms.Label();
            this._kdTrackBar = new System.Windows.Forms.TrackBar();
            this._pickLightColorButton = new System.Windows.Forms.Button();
            this._setLightHeightButton = new System.Windows.Forms.Button();
            this._moveLightButton = new System.Windows.Forms.Button();
            this._polygonGroupBox = new System.Windows.Forms.GroupBox();
            this._pickTextureButton = new System.Windows.Forms.Button();
            this._splitEdgeButton = new System.Windows.Forms.Button();
            this._movePolygonButton = new System.Windows.Forms.Button();
            this._pickColorButton = new System.Windows.Forms.Button();
            this._removeVerticesButton = new System.Windows.Forms.Button();
            this._createPolyButton = new System.Windows.Forms.Button();
            this._minSpeedNumeric = new System.Windows.Forms.NumericUpDown();
            this._maxSpeedNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._menuGroupBox.SuspendLayout();
            this._animationGroupBox.SuspendLayout();
            this._speedRangeGroupBox.SuspendLayout();
            this._lightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._kdTrackBar)).BeginInit();
            this._polygonGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._minSpeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxSpeedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(256, 12);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(841, 707);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            this._pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseClick);
            this._pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseDown);
            this._pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseMove);
            this._pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseUp);
            // 
            // _menuGroupBox
            // 
            this._menuGroupBox.Controls.Add(this._animationGroupBox);
            this._menuGroupBox.Controls.Add(this._lightGroupBox);
            this._menuGroupBox.Controls.Add(this._polygonGroupBox);
            this._menuGroupBox.Location = new System.Drawing.Point(12, 12);
            this._menuGroupBox.Name = "_menuGroupBox";
            this._menuGroupBox.Size = new System.Drawing.Size(238, 707);
            this._menuGroupBox.TabIndex = 1;
            this._menuGroupBox.TabStop = false;
            this._menuGroupBox.Text = "Menu";
            // 
            // _animationGroupBox
            // 
            this._animationGroupBox.Controls.Add(this._speedRangeGroupBox);
            this._animationGroupBox.Controls.Add(this._stopButton);
            this._animationGroupBox.Controls.Add(this._pauseButton);
            this._animationGroupBox.Controls.Add(this._playButton);
            this._animationGroupBox.Location = new System.Drawing.Point(6, 494);
            this._animationGroupBox.Name = "_animationGroupBox";
            this._animationGroupBox.Size = new System.Drawing.Size(226, 207);
            this._animationGroupBox.TabIndex = 2;
            this._animationGroupBox.TabStop = false;
            this._animationGroupBox.Text = "Animation";
            // 
            // _speedRangeGroupBox
            // 
            this._speedRangeGroupBox.Controls.Add(this._maxSpeedNumeric);
            this._speedRangeGroupBox.Controls.Add(this._minSpeedNumeric);
            this._speedRangeGroupBox.Controls.Add(this._maxSpeedRangeLabel);
            this._speedRangeGroupBox.Controls.Add(this._minSpeedRangeLabel);
            this._speedRangeGroupBox.Location = new System.Drawing.Point(6, 51);
            this._speedRangeGroupBox.Name = "_speedRangeGroupBox";
            this._speedRangeGroupBox.Size = new System.Drawing.Size(214, 83);
            this._speedRangeGroupBox.TabIndex = 3;
            this._speedRangeGroupBox.TabStop = false;
            this._speedRangeGroupBox.Text = "Speed range";
            // 
            // _maxSpeedRangeLabel
            // 
            this._maxSpeedRangeLabel.AutoSize = true;
            this._maxSpeedRangeLabel.Location = new System.Drawing.Point(9, 54);
            this._maxSpeedRangeLabel.Name = "_maxSpeedRangeLabel";
            this._maxSpeedRangeLabel.Size = new System.Drawing.Size(62, 15);
            this._maxSpeedRangeLabel.TabIndex = 1;
            this._maxSpeedRangeLabel.Text = "Maximum";
            // 
            // _minSpeedRangeLabel
            // 
            this._minSpeedRangeLabel.AutoSize = true;
            this._minSpeedRangeLabel.Location = new System.Drawing.Point(9, 25);
            this._minSpeedRangeLabel.Name = "_minSpeedRangeLabel";
            this._minSpeedRangeLabel.Size = new System.Drawing.Size(60, 15);
            this._minSpeedRangeLabel.TabIndex = 0;
            this._minSpeedRangeLabel.Text = "Minimum";
            // 
            // _stopButton
            // 
            this._stopButton.Location = new System.Drawing.Point(157, 22);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(63, 23);
            this._stopButton.TabIndex = 2;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
            // 
            // _pauseButton
            // 
            this._pauseButton.Enabled = false;
            this._pauseButton.Location = new System.Drawing.Point(81, 22);
            this._pauseButton.Name = "_pauseButton";
            this._pauseButton.Size = new System.Drawing.Size(70, 23);
            this._pauseButton.TabIndex = 1;
            this._pauseButton.Text = "Pause";
            this._pauseButton.UseVisualStyleBackColor = true;
            this._pauseButton.Click += new System.EventHandler(this._pauseButton_Click);
            // 
            // _playButton
            // 
            this._playButton.Location = new System.Drawing.Point(6, 22);
            this._playButton.Name = "_playButton";
            this._playButton.Size = new System.Drawing.Size(69, 23);
            this._playButton.TabIndex = 0;
            this._playButton.Text = "Play";
            this._playButton.UseVisualStyleBackColor = true;
            this._playButton.Click += new System.EventHandler(this._playButton_Click);
            // 
            // _lightGroupBox
            // 
            this._lightGroupBox.Controls.Add(this._mLabel);
            this._lightGroupBox.Controls.Add(this._mTrackBar);
            this._lightGroupBox.Controls.Add(this._ksLabel);
            this._lightGroupBox.Controls.Add(this._ksTrackBar);
            this._lightGroupBox.Controls.Add(this._kdLabel);
            this._lightGroupBox.Controls.Add(this._kdTrackBar);
            this._lightGroupBox.Controls.Add(this._pickLightColorButton);
            this._lightGroupBox.Controls.Add(this._setLightHeightButton);
            this._lightGroupBox.Controls.Add(this._moveLightButton);
            this._lightGroupBox.Location = new System.Drawing.Point(6, 227);
            this._lightGroupBox.Name = "_lightGroupBox";
            this._lightGroupBox.Size = new System.Drawing.Size(226, 261);
            this._lightGroupBox.TabIndex = 1;
            this._lightGroupBox.TabStop = false;
            this._lightGroupBox.Text = "Light";
            // 
            // _mLabel
            // 
            this._mLabel.AutoSize = true;
            this._mLabel.Location = new System.Drawing.Point(11, 207);
            this._mLabel.Name = "_mLabel";
            this._mLabel.Size = new System.Drawing.Size(18, 15);
            this._mLabel.TabIndex = 10;
            this._mLabel.Text = "m";
            // 
            // _mTrackBar
            // 
            this._mTrackBar.Location = new System.Drawing.Point(42, 207);
            this._mTrackBar.Maximum = 100;
            this._mTrackBar.Name = "_mTrackBar";
            this._mTrackBar.Size = new System.Drawing.Size(178, 45);
            this._mTrackBar.TabIndex = 9;
            this._mTrackBar.TickFrequency = 10;
            this._mTrackBar.ValueChanged += new System.EventHandler(this._mTrackBar_ValueChanged);
            // 
            // _ksLabel
            // 
            this._ksLabel.AutoSize = true;
            this._ksLabel.Location = new System.Drawing.Point(11, 160);
            this._ksLabel.Name = "_ksLabel";
            this._ksLabel.Size = new System.Drawing.Size(23, 15);
            this._ksLabel.TabIndex = 8;
            this._ksLabel.Text = "k_s";
            // 
            // _ksTrackBar
            // 
            this._ksTrackBar.Location = new System.Drawing.Point(42, 160);
            this._ksTrackBar.Maximum = 100;
            this._ksTrackBar.Name = "_ksTrackBar";
            this._ksTrackBar.Size = new System.Drawing.Size(178, 45);
            this._ksTrackBar.TabIndex = 7;
            this._ksTrackBar.TickFrequency = 10;
            this._ksTrackBar.ValueChanged += new System.EventHandler(this._ksTrackBar_ValueChanged);
            // 
            // _kdLabel
            // 
            this._kdLabel.AutoSize = true;
            this._kdLabel.Location = new System.Drawing.Point(11, 109);
            this._kdLabel.Name = "_kdLabel";
            this._kdLabel.Size = new System.Drawing.Size(25, 15);
            this._kdLabel.TabIndex = 6;
            this._kdLabel.Text = "k_d";
            // 
            // _kdTrackBar
            // 
            this._kdTrackBar.Location = new System.Drawing.Point(42, 109);
            this._kdTrackBar.Maximum = 100;
            this._kdTrackBar.Name = "_kdTrackBar";
            this._kdTrackBar.Size = new System.Drawing.Size(178, 45);
            this._kdTrackBar.TabIndex = 5;
            this._kdTrackBar.TickFrequency = 10;
            this._kdTrackBar.ValueChanged += new System.EventHandler(this._kdTrackBar_ValueChanged);
            // 
            // _pickLightColorButton
            // 
            this._pickLightColorButton.Location = new System.Drawing.Point(6, 80);
            this._pickLightColorButton.Name = "_pickLightColorButton";
            this._pickLightColorButton.Size = new System.Drawing.Size(214, 23);
            this._pickLightColorButton.TabIndex = 4;
            this._pickLightColorButton.Text = "Pick Color";
            this._pickLightColorButton.UseVisualStyleBackColor = true;
            this._pickLightColorButton.Click += new System.EventHandler(this._pickLightColorButton_Click);
            // 
            // _setLightHeightButton
            // 
            this._setLightHeightButton.Location = new System.Drawing.Point(6, 51);
            this._setLightHeightButton.Name = "_setLightHeightButton";
            this._setLightHeightButton.Size = new System.Drawing.Size(214, 23);
            this._setLightHeightButton.TabIndex = 1;
            this._setLightHeightButton.Text = "Set Height";
            this._setLightHeightButton.UseVisualStyleBackColor = true;
            this._setLightHeightButton.Click += new System.EventHandler(this._setLightHeightButton_Click);
            // 
            // _moveLightButton
            // 
            this._moveLightButton.Location = new System.Drawing.Point(6, 22);
            this._moveLightButton.Name = "_moveLightButton";
            this._moveLightButton.Size = new System.Drawing.Size(214, 23);
            this._moveLightButton.TabIndex = 0;
            this._moveLightButton.Text = "Move";
            this._moveLightButton.UseVisualStyleBackColor = true;
            this._moveLightButton.Click += new System.EventHandler(this._moveLightButton_Click);
            // 
            // _polygonGroupBox
            // 
            this._polygonGroupBox.Controls.Add(this._pickTextureButton);
            this._polygonGroupBox.Controls.Add(this._splitEdgeButton);
            this._polygonGroupBox.Controls.Add(this._movePolygonButton);
            this._polygonGroupBox.Controls.Add(this._pickColorButton);
            this._polygonGroupBox.Controls.Add(this._removeVerticesButton);
            this._polygonGroupBox.Controls.Add(this._createPolyButton);
            this._polygonGroupBox.Location = new System.Drawing.Point(6, 22);
            this._polygonGroupBox.Name = "_polygonGroupBox";
            this._polygonGroupBox.Size = new System.Drawing.Size(226, 199);
            this._polygonGroupBox.TabIndex = 0;
            this._polygonGroupBox.TabStop = false;
            this._polygonGroupBox.Text = "Polygon";
            // 
            // _pickTextureButton
            // 
            this._pickTextureButton.Location = new System.Drawing.Point(6, 167);
            this._pickTextureButton.Name = "_pickTextureButton";
            this._pickTextureButton.Size = new System.Drawing.Size(214, 23);
            this._pickTextureButton.TabIndex = 5;
            this._pickTextureButton.Text = "Pick Texture";
            this._pickTextureButton.UseVisualStyleBackColor = true;
            this._pickTextureButton.Click += new System.EventHandler(this._pickTextureButton_Click);
            // 
            // _splitEdgeButton
            // 
            this._splitEdgeButton.Location = new System.Drawing.Point(6, 80);
            this._splitEdgeButton.Name = "_splitEdgeButton";
            this._splitEdgeButton.Size = new System.Drawing.Size(214, 23);
            this._splitEdgeButton.TabIndex = 4;
            this._splitEdgeButton.Text = "Split Edge";
            this._splitEdgeButton.UseVisualStyleBackColor = true;
            this._splitEdgeButton.Click += new System.EventHandler(this._splitEdgeButton_Click);
            // 
            // _movePolygonButton
            // 
            this._movePolygonButton.Location = new System.Drawing.Point(6, 109);
            this._movePolygonButton.Name = "_movePolygonButton";
            this._movePolygonButton.Size = new System.Drawing.Size(214, 23);
            this._movePolygonButton.TabIndex = 2;
            this._movePolygonButton.Text = "Move";
            this._movePolygonButton.UseVisualStyleBackColor = true;
            this._movePolygonButton.Click += new System.EventHandler(this._movePolygonButton_Click);
            // 
            // _pickColorButton
            // 
            this._pickColorButton.Location = new System.Drawing.Point(6, 138);
            this._pickColorButton.Name = "_pickColorButton";
            this._pickColorButton.Size = new System.Drawing.Size(214, 23);
            this._pickColorButton.TabIndex = 3;
            this._pickColorButton.Text = "Pick Color";
            this._pickColorButton.UseVisualStyleBackColor = true;
            this._pickColorButton.Click += new System.EventHandler(this._pickColorButton_Click);
            // 
            // _removeVerticesButton
            // 
            this._removeVerticesButton.Location = new System.Drawing.Point(6, 51);
            this._removeVerticesButton.Name = "_removeVerticesButton";
            this._removeVerticesButton.Size = new System.Drawing.Size(214, 23);
            this._removeVerticesButton.TabIndex = 1;
            this._removeVerticesButton.Text = "Remove Vertices";
            this._removeVerticesButton.UseVisualStyleBackColor = true;
            this._removeVerticesButton.Click += new System.EventHandler(this._removeVerticesButton_Click);
            // 
            // _createPolyButton
            // 
            this._createPolyButton.Location = new System.Drawing.Point(6, 22);
            this._createPolyButton.Name = "_createPolyButton";
            this._createPolyButton.Size = new System.Drawing.Size(214, 23);
            this._createPolyButton.TabIndex = 0;
            this._createPolyButton.Text = "Create Polygon";
            this._createPolyButton.UseVisualStyleBackColor = true;
            this._createPolyButton.Click += new System.EventHandler(this._createPolyButton_Click);
            // 
            // _minSpeedNumeric
            // 
            this._minSpeedNumeric.Location = new System.Drawing.Point(88, 22);
            this._minSpeedNumeric.Name = "_minSpeedNumeric";
            this._minSpeedNumeric.Size = new System.Drawing.Size(120, 23);
            this._minSpeedNumeric.TabIndex = 2;
            this._minSpeedNumeric.ValueChanged += new System.EventHandler(this._minSpeedNumeric_ValueChanged);
            // 
            // _maxSpeedNumeric
            // 
            this._maxSpeedNumeric.Location = new System.Drawing.Point(88, 52);
            this._maxSpeedNumeric.Name = "_maxSpeedNumeric";
            this._maxSpeedNumeric.Size = new System.Drawing.Size(120, 23);
            this._maxSpeedNumeric.TabIndex = 3;
            this._maxSpeedNumeric.ValueChanged += new System.EventHandler(this._maxSpeedNumeric_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 731);
            this.Controls.Add(this._menuGroupBox);
            this.Controls.Add(this._pictureBox);
            this.Name = "MainForm";
            this.Text = "wysockid";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._menuGroupBox.ResumeLayout(false);
            this._animationGroupBox.ResumeLayout(false);
            this._speedRangeGroupBox.ResumeLayout(false);
            this._speedRangeGroupBox.PerformLayout();
            this._lightGroupBox.ResumeLayout(false);
            this._lightGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._kdTrackBar)).EndInit();
            this._polygonGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._minSpeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._maxSpeedNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.GroupBox _menuGroupBox;
        private System.Windows.Forms.GroupBox _polygonGroupBox;
        private System.Windows.Forms.Button _splitEdgeButton;
        private System.Windows.Forms.Button _movePolygonButton;
        private System.Windows.Forms.Button _pickColorButton;
        private System.Windows.Forms.Button _removeVerticesButton;
        private System.Windows.Forms.Button _createPolyButton;
        private System.Windows.Forms.GroupBox _lightGroupBox;
        private System.Windows.Forms.Button _pickLightColorButton;
        private System.Windows.Forms.Button _setLightHeightButton;
        private System.Windows.Forms.Button _moveLightButton;
        private System.Windows.Forms.Button _pickTextureButton;
        private System.Windows.Forms.GroupBox _animationGroupBox;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.Button _pauseButton;
        private System.Windows.Forms.Button _playButton;
        private System.Windows.Forms.Label _ksLabel;
        private System.Windows.Forms.TrackBar _ksTrackBar;
        private System.Windows.Forms.Label _kdLabel;
        private System.Windows.Forms.TrackBar _kdTrackBar;
        private System.Windows.Forms.Label _mLabel;
        private System.Windows.Forms.TrackBar _mTrackBar;
        private System.Windows.Forms.GroupBox _speedRangeGroupBox;
        private System.Windows.Forms.Label _maxSpeedRangeLabel;
        private System.Windows.Forms.Label _minSpeedRangeLabel;
        private System.Windows.Forms.NumericUpDown _maxSpeedNumeric;
        private System.Windows.Forms.NumericUpDown _minSpeedNumeric;
    }
}
