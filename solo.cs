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
        Ivent sob;
        public solo(Ivent sobytie1)
        {
            sob = sobytie1;
            InitializeComponent();
            List<string> parts = Program.Select("SELECT dt FROM `history` WHERE participant='" + sob.name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
              /*  PictureBox picB = new PictureBox();
                picB.Location = new Point(10, 5 + 130 * i);
                picB.Size = new Size(120, 120);
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    picB.Load("../../kartinochki/" + parts[i] + ".jpg");
                }
                catch (Exception) { }*/

                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(120, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 10 + 30 * i);

                panel1.Controls.Add(lbl);
                //panel1.Controls.Add(picB);
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
                textBox1.Text = sob.descript;
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
            }
            catch (Exception) { }
        }
    }
}
