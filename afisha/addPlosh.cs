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
    public partial class addPlosh : Form
    {
        public addPlosh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Insert("INSERT INTO `ploshki` (name, description, city, vmest)" +
                           "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + Convert.ToInt32(textBox4.Text) + "')");
            MessageBox.Show("СОХРАНЕНО");
        }

        private void addPlosh_Load(object sender, EventArgs e)
        {

        }
    }
}
