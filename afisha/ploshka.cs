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
    public partial class ploshka : Form
    {
        string ploshk;
        public ploshka(string plosh)
        {
            ploshk = plosh;
            InitializeComponent();
            try
            {
                Text = "Информация о " + ploshk;
                label1.Text = ploshk;
                label2.Text = ploshk;
                label4.Text = "Вместимость: " + ploshk;
                pictureBox1.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + ploshk + "'");
                pictureBox2.Image = Program.SelectImage("SELECT kartinka2 FROM ploshki WHERE name = '" + ploshk + "'");
                textBox1.Text = ploshk;
            }
            catch (Exception) { }
            List<string> parts = Program.Select("SELECT name FROM ivents WHERE area = '" + ploshk + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(x, y);
                    picB.Size = new Size(120, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 120);
                    lbl.Size = new Size(120, 30);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 10F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button1_Click);
                    x = x + 130;
                    if (x + 130 > panel1.Width)
                    {
                        x = 5;
                        y = y + 150;
                    }
                    panel1.Controls.Add(picB);
                    panel1.Controls.Add(lbl);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            sobytie f = new sobytie(lbl.Text);
            f.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ploshka_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}