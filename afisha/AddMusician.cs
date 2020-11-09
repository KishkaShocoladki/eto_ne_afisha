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
    public partial class AddMusician : Form
    {
        public AddMusician()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Insert("INSERT INTO `participants` (name, descript)" +
                " VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')");
            MessageBox.Show("Созхранено");
        }
    }
}
