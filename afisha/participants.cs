using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace AfishA
{
    public partial class participants : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        string name;
        public participants(string nm)
        {
            name = nm;
            InitializeComponent();
            Text = "Информация о " + name;
            label1.Text = name;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Font = new Font("Lucida Console", 20F, FontStyle.Regular, GraphicsUnit.Point, (204));

            List<string> info = Program.Select("SELECT descript, genre, country FROM participants WHERE name = '" + name + "'");

            textBox1.Text = info[0];
            label2.Text = info[1];
            label2.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            label5.Text = info[2];
            label5.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            List<string> music = Program.Select("SELECT musicName1, musicName2, musicaName3 FROM songs WHERE name = '" + name + "'");
            label6.Text = music[0];
            label7.Text = music[0];
            label8.Text = music[0];
            try
            {          
                pictureBox1.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + name + "'");
            }
            catch (Exception) { }
            List<string> parts = Program.Select("SELECT ivent FROM `tipasvyaznaverno` WHERE part= '" + name + "'");
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
                    lbl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
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
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            sobytie f = new sobytie(lbl.Text);
            f.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void participants_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            wmp.controls.stop();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.SelectMusic("SELECT song1 FROM participants WHERE name='" + name + "'");
            try 
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            Program.SelectMusic("SELECT song2 FROM participants WHERE name='" + name + "'");
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
            Program.SelectMusic("SELECT song3 FROM participants WHERE name='" + name + "'");
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
    }
}

