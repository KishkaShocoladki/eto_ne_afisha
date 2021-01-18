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
    public partial class rewievs : Form
    {
        string name;
        public rewievs(string sobyt)
        {
            name = sobyt;
            InitializeComponent();
            Text = "ОТЗЫВЫ О " + name;
            List<string> rews = Program.Select("SELECT `user`, `otzv`, `rat` FROM `tipacomments` WHERE ivent ='" + name + "'");
            for (int i = 0; i < rews.Count; i = i + 3)
            {
                string[] row = new string[3];
                row[0] = rews[i];
                row[1] = rews[i + 1];
                row[2] = rews[i + 2];
                dataGridView1.Rows.Add(row);
            }
            if (Program.user == "_")
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Program.user == "_")
            {
                MessageBox.Show("ВОЙДИТЕ ИЛИ ЗАРЕГИСТРИРУЙТЕСЬ, ЧТОБЫ ОТСТАВИТЬ СВОЙ ОТЗЫВ ┬┴┬┴┤(･_├┬┴┬┴");
            }
            else
            {
                Program.Insert("INSERT INTO tipacomments (user, otzv, rat, ivent) VALUES ('" + Program.user + "', '" + textBox1.Text + "', '" + Convert.ToInt32(comboBox1.Text) + "', '" + name + "')");
                MessageBox.Show("ОТЗЫВ ДОБАВЛЕН");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rewievs_Load(object sender, EventArgs e)
        {

        }
    }
}
