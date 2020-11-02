using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AfishA
{
    public partial class reg : Form
    {
        string name;
        public reg(string nm)
        {
            name = nm;
            InitializeComponent();
            if (name == "ВХОД")
            {
                button1.Text = "ВОЙТИ";
                button1.Click += new EventHandler(BUTT_Click);
            }
            else if (name == "РЕГИСТРАЦИЯ")
            {
                button1.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
                button1.Click += new EventHandler(BUT_Click);
            }
        }

        private void BUT_Click(object sender, EventArgs e)
        {
            Program.Select("INSERT INTO `users` (login, pass)" +
                           "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')");
            MessageBox.Show("ВЫ ТИПА ЗАРЕГИСТРИРОВАЛИСЬ НО НЕТ");
        }
        private void BUTT_Click(object sender, EventArgs e)
        {
            Program.user = textBox1.Text;
        }

        private void reg_Load(object sender, EventArgs e)
        {

        }
    }
}
