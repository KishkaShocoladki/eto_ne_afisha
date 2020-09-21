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
        public Label labeI;
        public PictureBox picB;

        public Participants(string name1, string descript1, string sobytia1)
        {
            name = name1;
            descript = descript1;
            sobytia = sobytia1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class sobytie : Form
    {
        public static Participants[] part = new Participants[8];
        Ivent sob;
        public sobytie(Ivent sobytie1)
        {
            sob = sobytie1;
            InitializeComponent();
            Text = "Информация о " + sob.name;

            part[0] = new Participants("SLIPKNOT", "тип описание", "PARK LIVE 2021");
            part[1] = new Participants("MY CHEMICAL ROMANCE", "тип описание", "PARK LIVE 2021");
            part[2] = new Participants("GORILLAZ", "тип описание", "PARK LIVE 2021");
            part[3] = new Participants("PLACEBO", "тип описание", "PARK LIVE 2021");
            part[4] = new Participants("BLACK VEIL BRIDES", "тип описание", "DOWNLOAD FESTIVAL");
            part[5] = new Participants("FUNERAL FOR A FRIEND", "тип описание", "DOWNLOAD FESTIVAL");
            part[6] = new Participants("KISS", "тип описание", "DOWNLOAD FESTIVAL");
            part[7] = new Participants("SYSTEM OF A DOWN", "тип описание", "DOWNLOAD FESTIVAL");

            int x = 510;
            int y = 323;
            for (int i = 0; i < 8; i = i + 1)
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

            try
            {
                label1.Text = sob.name;
                label2.Text = sob.area;
                //label2.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
               // label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
                label3.Text = sob.agelimit;
                //label3.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                //label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
                pictureBox1.Load("../../kartinochki/" + sob.name + ".jpg");
                pictureBox2.Load("../../kartinochki/" + sob.name + "2" + ".jpg");
                pictureBox3.Load("../../kartinochki/" + sob.name + "3" + ".jpg");
                pictureBox4.Load("../../kartinochki/" + sob.name + "4" + ".jpg");
                pictureBox4.Tag = sob.name;
                textBox1.Text = sob.descript;
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
            }
            catch (Exception) { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i = i + 1)
            {
                if (((PictureBox)sender).Image == part[i].picB.Image)
                {
                    participants f = new participants(part[i]);
                    f.Show();
                }
            }
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
