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
    public partial class addPart : Form
    {
        public addPart()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Insert("INSERT INTO `participants` (name, descript, genre, mVmest, tipgonorar, neGo)" +
                           "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '"  + textBox4.Text + "', '" + Convert.ToInt32(textBox5.Text) + "', '" + Convert.ToInt32(textBox6.Text) + "', '" + textBox7.Text + "')");
            MessageBox.Show("СОХРАНЕНО");
        }

        private void addPart_Load(object sender, EventArgs e)
        {

        }
    }
}
