using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfishA
{
    public partial class configs : UserControl
    {
        public static Color colour;
        public static Font font;
        public static Color foreColor;
        string text;
        public static void ApplyDesign(Control form)
        {
            form.BackColor = colour;
            form.Font = font;
            form.ForeColor = foreColor;
        }

        public configs(string text1)
        {
            text = text1;
            InitializeComponent();
            if (text == "BACKGROUNDS")
            {
                label1.Text = "BACKGROUND COLORS";
                r1.Text = "бледно-каштановый";
                r1.ForeColor = Color.FromArgb(192, 105, 109);
                r1.BackColor = Color.FromArgb(221, 173, 175);
                r2.Text = "";
                r3.Text = "";
                r4.Text = "";
                r5.Text = "";
                r6.Text = "";
            }
            else if (text == "THEMES")
            {
                label1.Text = "THEMES";
                r1.Text = "";
                r2.Text = "";
                r3.Text = "";
                r4.Text = "";
                r5.Text = "";
                r6.Text = "";

            }
        }

        private void r1_CheckedChanged(object sender, EventArgs e)
        {
            if (text == "BACKGROUNDS")
            {
                colour = Color.FromArgb(221, 173, 175);
                Properties.Settings.Default.color = colour;
            }
            if (text == "THEMES")
            {
                colour = Color.FromArgb(221, 173, 175);
                Properties.Settings.Default.color = colour;
            }
        }
    }
}
