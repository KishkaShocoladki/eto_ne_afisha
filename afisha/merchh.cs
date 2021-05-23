using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfishA
{
    public partial class merchh : UserControl
    {
        string band;
        public merchh(string band1)
        {
            band = band1;
            InitializeComponent();

            main.fname = band1;
            try
            {
                pictureBox1.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + band1 + "'"); ;
            }
            catch (Exception) { }
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

        }
        private void BUTT_Click(object sender, EventArgs e)
        { 
            UserControl f = new UserControl();
            Label lbl = (Label)sender;
            f = new detMerch(lbl.Text);
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type ='" + button1.Text + "' AND band ='" + band + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = Color.Khaki;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(BUTT_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = Color.LemonChiffon;
                labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 160;
                if (x + 160 > panel1.Width)
                {
                    x = 15;
                    y = y + 190;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type ='" + button2.Text + "' AND band ='" + band + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
               // picB.Click += new EventHandler(BUTT_Click);

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(BUTT_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 160;
                if (x + 160 > panel1.Width)
                {
                    x = 15;
                    y = y + 190;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
        }   
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type ='" + button3.Text + "' AND band ='" + band + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                //picB.Click += new EventHandler(BUTT_Click);

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(BUTT_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 160;
                if (x + 160 > panel1.Width)
                {
                    x = 15;
                    y = y + 190;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type ='" + button4.Text + "' AND band ='" + band + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                //picB.Click += new EventHandler(BUTT_Click);

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(BUTT_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 160;
                if (x + 160 > panel1.Width)
                {
                    x = 15;
                    y = y + 190;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
        }
    }
}