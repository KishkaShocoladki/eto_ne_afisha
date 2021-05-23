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
    public partial class adding : UserControl
    {
        public adding()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addPart f = new addPart();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addPlosh f = new addPlosh();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addSob f = new addSob();
            f.Show();
        }
    }
}
