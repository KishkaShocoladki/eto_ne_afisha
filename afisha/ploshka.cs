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
    public partial class ploshka : Form
    {
        Ploshadka plosh;
        public ploshka(Ploshadka ploshka1)
        {
            plosh = ploshka1;
            InitializeComponent();
            Text = "Информация о " + plosh.name;

            try
            {
                label1.Text = plosh.name;
                label2.Text = plosh.city;
                label4.Text = "Вместимость: " + plosh.vmestimost;
                pictureBox1.Load("../../kartinochki/" + plosh.name + ".jpg");
                pictureBox2.Load("../../kartinochki/" + plosh.name + "2" + ".jpg");
                pictureBox3.Load("../../kartinochki/" + plosh.name + "3" + ".jpg");
                textBox1.Text = plosh.descript;
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
            }
            catch (Exception) { }

            int x = 640;
            int y = 35;
            foreach (Ivent sob in main.sobytia)
            {
                if (sob.area == plosh.name)
                {
                    PictureBox pix = new PictureBox();
                    Label but = new Label();

                    pix.Text = sob.picB.Text;
                    pix.Size = new Size(280, 240);
                    pix.SizeMode = sob.picB.SizeMode;
                    pix.Location = new Point(x, y);
                    pix.Click += new EventHandler(main.button3_Click);
                    pix.Image = sob.picB.Image;

                    but.Location = new Point(x, y + 230);
                    but.Size = new Size(280, 45);
                    but.Text = sob.labeI.Text;
                    but.TextAlign = ContentAlignment.MiddleCenter;
                    but.Font = new Font("Lucida Console", 12);
                    but.ForeColor = System.Drawing.SystemColors.ButtonFace;

                    Controls.Add(pix);
                    Controls.Add(but);

                    x = x + 280;
                    if (x + 280 > Width)
                    {
                        x = 650;
                        y = y + 260;
                    }
                }
            }
        }

        private void ploshka_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
