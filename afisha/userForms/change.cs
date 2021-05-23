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
    public partial class change : Form
    {

        public change()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Program.Select("UPDATE `users` SET `login` = '" + textBox2.Text + "' WHERE ident = '" + Program.userid + "'");
            MessageBox.Show("ЛОГИН ИЗМЕНЕН");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Select("UPDATE `users` SET `pass` = '" + textBox1.Text + "' WHERE login = '" + Program.user + "'");
            MessageBox.Show("ПАРОЛЬ ИЗМЕНЕН");
        }
    }
}
