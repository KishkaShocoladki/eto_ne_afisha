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
        public static Color colour;
        public static Font font;
        public static Color foreColor;

        public static void ApplyDesign(Control form)
        {
            form.BackColor = colour;
            form.Font = font;
            form.ForeColor = foreColor;

        }
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
        }

        private void F2_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void F3_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("OCR A Extended", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void F4_CheckedChanged(object sender, EventArgs e)
        {
            font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void FC1_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.White;
        }

        private void FC2_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Black;
        }

        private void FC3_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Yellow;
        }

        private void FC4_CheckedChanged(object sender, EventArgs e)
        {
            foreColor = Color.Crimson;
        }

        private void designTupoy_Load(object sender, EventArgs e)
        {

        }
    }
}
