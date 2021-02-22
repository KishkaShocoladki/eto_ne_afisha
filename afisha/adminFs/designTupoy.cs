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
        public static Color forecolor;

        public static void ApplyDesign(Control form)
        {
            form.BackColor = colour;
            form.ForeColor = forecolor;
        }
        public designTupoy()
        {
            InitializeComponent();
            colour = Properties.Settings.Default.color;
        }
        //BACKГРАУНДЫ
        #region
        private void backG1_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(19, 19, 21);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }      
        private void backG2_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(170, 240, 209);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }

        private void backG3_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(255, 140, 105);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }

        private void backG4_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(94, 33, 41);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }

        private void backG5_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(106, 90, 205);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }

        private void backG6_CheckedChanged(object sender, EventArgs e)
        {
            colour = Color.FromArgb(120, 219, 226);
            Properties.Settings.Default.color = colour;
            preButt.BackColor = colour;
        }
        #endregion
        //ТНЕМЕС
        private void theme1_CheckedChanged(object sender, EventArgs e)
        {
            forecolor = Color.FromArgb(208, 208, 208);
            colour = Color.FromArgb(30, 30, 30);
            Properties.Settings.Default.color = colour;
            Properties.Settings.Default.forecolor = forecolor;
        }

        private void theme3_CheckedChanged(object sender, EventArgs e)
        {
            forecolor = Color.FromArgb(30, 30, 30);
            colour = Color.FromArgb(119, 208, 204);
            Properties.Settings.Default.color = colour;
            Properties.Settings.Default.forecolor = forecolor;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            forecolor = Color.FromArgb(30, 30, 30);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            forecolor = Color.FromArgb(208, 208, 208);
        }

        private void designTupoy_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
