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
    public partial class addSob : Form
    {
        public addSob()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Insert("INSERT INTO `ivents` (name, descript, city, country, type, area, pay)" +
                          "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text  + "', '" + textBox7.Text + "', '" + Convert.ToInt32(textBox8.Text) + "')");
            MessageBox.Show("СОХРАНЕНО");
        }

        private void addSob_Load(object sender, EventArgs e)
        {

        }
    }
}
