using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyLight.Figures
{
    public partial class PickIntForm : Form
    {
        public int Value { get; set; }

        public PickIntForm(string title, string hint, int value)
        {
            Text = title;
            Value = value;
            InitializeComponent();
            _hintLabel.Text = hint;
            _textBox.Text = $"{value}";
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Value = int.Parse(_textBox.Text);
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
