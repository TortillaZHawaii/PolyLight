namespace PolyLight.Figures
{
    partial class PickIntForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._hintLabel = new System.Windows.Forms.Label();
            this._textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(204, 101);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(123, 101);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _hintLabel
            // 
            this._hintLabel.AutoSize = true;
            this._hintLabel.Location = new System.Drawing.Point(12, 9);
            this._hintLabel.Name = "_hintLabel";
            this._hintLabel.Size = new System.Drawing.Size(38, 15);
            this._hintLabel.TabIndex = 2;
            this._hintLabel.Text = "label1";
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(12, 49);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(267, 23);
            this._textBox.TabIndex = 3;
            // 
            // PickIntForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(291, 136);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._hintLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickIntForm";
            this.Text = "PickIntForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _hintLabel;
        private System.Windows.Forms.TextBox _textBox;
    }
}