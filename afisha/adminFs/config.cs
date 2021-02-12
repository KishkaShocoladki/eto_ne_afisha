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
    public partial class config : UserControl
    {
        public static Font font;
        public config()
        {
            Font = font;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
                Properties.Settings.Default.font = font;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserControl f = new UserControl();
            Button lbl = (Button)sender;
            f = new configs(lbl.Text);
            panel1.Controls.Clear();
            panel1.Controls.Add(f);
        }
    }
}
