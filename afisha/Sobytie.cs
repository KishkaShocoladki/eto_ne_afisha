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
    public struct Participants
    {
        public string name;
        public string descript;
        public string sobytia;
        public string genre;
        public Label labeI;
        public PictureBox picB;

        public Participants(string name1, string descript1, string sobytia1, string genre1)
        {
            name = name1;
            descript = descript1;
            sobytia = sobytia1;
            genre = genre1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class sobytie : Form
    {
        public static List<Participants> part = new List<Participants>();
        Ivent sob;
        public static void fillsob()
        {
            string[] lines = System.IO.File.ReadAllLines("участнеки.txt");
            foreach (string str in lines)
            {
                string[] parts = str.Split(new string[] { "/ " }, StringSplitOptions.None);
                part.Add(new Participants(parts[0], parts[1], parts[2], parts[3]));
            }
        }

        public sobytie(Ivent sobytie1)
        {
            sob = sobytie1;
            InitializeComponent();

            List<string> parts = Program.Select("SELECT part FROM `tipasvyaznaverno` WHERE ivent='" + sob.name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(200, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 10 + 30 * i);
                lbl.Click += new EventHandler(button2_Click);
                panel1.Controls.Add(lbl);
            }


            Text = "Информация о " + sob.name;

            try
            {
                label1.Text = sob.name;
                label2.Text = sob.area;
                //label3.Text = sob.agelimit;
                pictureBox1.Load("../../kartinochki/" + sob.name + ".jpg");
                pictureBox2.Load("../../kartinochki/" + sob.name + "2" + ".jpg");
                pictureBox3.Load("../../kartinochki/" + sob.name + "3" + ".jpg");
                pictureBox4.Load("../../kartinochki/" + sob.name + "4" + ".jpg");
                pictureBox4.Tag = sob.name;
                textBox1.Text = sob.descript;
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
            }
            catch (Exception) { }

            int x = 510;
            int y = 323;
            for (int i = 0; i < part.Count; i = i + 1)
            {
                if (sob.name == part[i].sobytia)
                {
                    part[i].picB.Location = new Point(x, y);
                    part[i].picB.Size = new Size(120, 120);
                    part[i].picB.Text = part[i].name;
                    part[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                    part[i].picB.Click += new EventHandler(button2_Click);
                    try
                    {
                        part[i].picB.Load("../../kartinochki/" + part[i].name + ".jpg");
                    }
                    catch (Exception) { }

                    part[i].labeI.Location = new Point(x, y + 120);
                    part[i].labeI.Size = new Size(120, 60);
                    part[i].labeI.Text = part[i].name;
                    part[i].labeI.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    part[i].labeI.ForeColor = System.Drawing.SystemColors.ButtonFace;

                    x = x + 130;
                    if (x + 130 > 800)
                    {
                        x = 510;
                        y = y + 185;
                    }
                }
            }

            foreach (Participants part in part)
            {
                Controls.Add(part.labeI);
                Controls.Add(part.picB);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            participants f = new participants(lbl.Text);
            f.Show();
            /*for (int i = 0; i < part.Count; i = i + 1)
            {
                if (((PictureBox)sender).Image == part[i].picB.Image)
                {
                    participants f = new participants(part[i]);
                    f.Show();
                }
            }*/
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            cacaгеo f = new cacaгеo();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buy f = new buy();
            f.Show();
        }

        private void sobytie_Load(object sender, EventArgs e)
        {

        }
    }
}