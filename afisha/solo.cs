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
    public partial class solo : Form
    {
        string sob;
        public solo(string name)
        {
            sob = name;
            InitializeComponent();
            List<string> parts = Program.Select("SELECT dt FROM `history` WHERE participant='" + name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(120, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 10 + 30 * i);
                panel1.Controls.Add(lbl);
            }

            Text = "Информация о " + name;
            List<string> info = Program.Select("SELECT area, descript FROM ivents WHERE name = '" + name + "'");
            try
            {
                label1.Text = name;
                label2.Text = info[0];
                //label3.Text = sob.agelimit;
                pictureBox1.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + name + "'");
                pictureBox2.Image = Program.SelectImage("SELECT pic2 FROM ivents WHERE name = '" + name + "'");
                pictureBox3.Image = Program.SelectImage("SELECT pic3 FROM ivents WHERE name = '" + name + "'");
                textBox1.Text = info[1];
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
            }
            catch (Exception) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.user == "_")
            {
                MessageBox.Show("ЗАРЕГИСТРИРУЙТЕСЬ ИЛИ ВОЙДИТЕ В АККАУНТ, ЧТОБЫ КУПИТЬ БИЛЕТ  ┬┴┬┴┤(･_├┬┴┬┴");
            }
            else
            {
                buy f = new buy(sob);
                f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rewievs f = new rewievs(sob);
            f.Show();
        }
    }
}
