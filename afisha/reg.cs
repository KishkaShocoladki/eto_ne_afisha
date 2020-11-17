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
                Text = "ВХОД";
                button1.Text = "ВОЙТИ";
                button1.Click += new EventHandler(BUTT_Click);
            }
            else if (name == "РЕГИСТРАЦИЯ")
            {
                Text = "РЕГИСТРАЦИЯ";
                button1.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
                button1.Click += new EventHandler(BUT_Click);
            }
        }

        private void BUT_Click(object sender, EventArgs e)
        {
            int login = Convert.ToInt32(Program.Select("SELECT COUNT(login) FROM users WHERE login ='" + textBox1.Text + "' AND pass ='" + textBox2.Text + "'")[0]);
            if (login == 0)
            {
                Program.Insert("INSERT INTO `users` (login, pass)" +
                          "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')");
                Program.user = textBox1.Text;
                MessageBox.Show("ВЫ ТИПА ЗАРЕГИСТРИРОВАЛИСЬ");
            }
            else
            {
                Button but = (Button)sender;
                notreg f = new notreg(but.Text);
                f.Show();
            }
        }
        private void BUTT_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                int login = Convert.ToInt32(Program.Select("SELECT COUNT(login) FROM users WHERE login ='" + textBox1.Text + "' AND pass ='" + textBox2.Text + "'")[0]);
                if (login == 0)
                {
                    Button but = (Button)sender;
                    notreg f = new notreg(but.Text);
                    f.Show();
                }
                else if (login != 0)
                {
                    Program.user = textBox1.Text;
                    string ident = Program.Select("SELECT ident FROM users WHERE login ='" + textBox1.Text + "'")[0];
                    Program.userid = ident;
                }
            }
            else
            {
                MessageBox.Show("ЗАПОЛНИТЕ ОБА ПОЛЯ");
            }
        }

        private void reg_Load(object sender, EventArgs e)
        {

        }
    }
}
