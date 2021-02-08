using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfishA
{
    public partial class designTupoy : Form
    {
        public Color colour;
        public Font font;
        public Color foreColor;
        public designTupoy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colour = colorDialog1.Color;
        }

        private void F1_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font = font;
        }

        private void F2_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font = font;
        }

        private void F3_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("OCR A Extended", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font = font;
        }

        private void F4_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font = font;
        }

        private void FC1_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.White;
            ForeColor = foreColor;
        }

        private void FC2_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Black;
            ForeColor = foreColor;
        }

        private void FC3_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Yellow;
            ForeColor = foreColor;
        }

        private void FC4_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Crimson;
            ForeColor = foreColor;
        }
    }
}
