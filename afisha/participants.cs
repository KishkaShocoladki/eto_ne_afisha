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
    public partial class participants : Form
    {
        Participants parts;
        string name;

        public participants(string nm)
        {
            name = nm;
            InitializeComponent();
            label1.Text = name;

            List<string> info = Program.Select("SELECT name, descript, genre FROM participants WHERE name = '" + name + "'");
            label1.ForeColor = SystemColors.ButtonFace;

            textBox1.Text = info[1];
            label2.Text = info[2];
        }
        public participants(Participants part1)
        {
            parts = part1;
            InitializeComponent();
            Text = "Информация о " + parts.name;

            try
            {
                pictureBox1.Load("../../kartinochki/" + parts.name + ".jpg");
                label1.Text = parts.name;
                label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
                label2.Text = parts.genre;
                textBox1.Text = parts.descript;
            }
            catch (Exception) { }
            int x = 10;
            int y = 430;
            foreach (Ivent sob in main.sobytia)
            {
                if (sob.name == parts.sobytia)
                {
                    PictureBox pix = new PictureBox();
                    Label but = new Label();

                    pix.Text = sob.picB.Text;
                    pix.Size = new Size(150, 130);
                    pix.SizeMode = sob.picB.SizeMode;
                    pix.Location = new Point(x, y);
                    pix.Click += new EventHandler(main.button3_Click);
                    pix.Image = sob.picB.Image;

                    but.Location = new Point(x, y + 120);
                    but.Size = new Size(150, 35);
                    but.Text = sob.labeI.Text;
                    but.TextAlign = ContentAlignment.MiddleCenter;
                    but.Font = new Font("Lucida Console", 8);

                    Controls.Add(pix);
                    Controls.Add(but);

                    x = x + 160;
                    if (x + 160 > 500)
                    {
                        x = 10;
                        y = y + 155;
                    }
                }
            }
        }

        private void participants_Load(object sender, EventArgs e)
        {

        }
    }
}

