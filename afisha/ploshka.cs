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
    public struct IV
    {
        public string name;
        public Label labeI;
        public PictureBox picB;

        public IV(string name1)
        {
            name = name1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class ploshka : Form
    {
        public static List<IV> ivt = new List<IV>();
        PLOSH ploshk;
        public ploshka(PLOSH ploshka1)
        {
            ploshk = ploshka1;
            InitializeComponent();
            try
            {
                Text = "Информация о " + ploshk.name;
                label1.Text = ploshk.name;
                label2.Text = ploshk.city;
                label4.Text = "Вместимость: " + ploshk.vmest;
                pictureBox1.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + ploshk.name + "'");
                pictureBox2.Image = Program.SelectImage("SELECT kartinka2 FROM ploshki WHERE name = '" + ploshk.name + "'");
                pictureBox3.Image = Program.SelectImage("SELECT kartinka3 FROM ploshki WHERE name = '" + ploshk.name + "'");
                textBox1.Text = ploshk.descript;
            }
            catch (Exception) { }
            List<string> parts = Program.Select("SELECT name FROM ivents WHERE area = '" + ploshk.name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(120, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 120 + 130 * i);
                lbl.Click += new EventHandler(button2_Click);
                panel1.Controls.Add(lbl);

                PictureBox picB = new PictureBox();
                picB.Location = new Point(10, 5 + 130 * i);
                picB.Size = new Size(120, 120);
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                panel1.Controls.Add(picB);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ploshka_Load(object sender, EventArgs e)
        {

        }
    }
}