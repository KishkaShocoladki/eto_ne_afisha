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
    
    public partial class parts : Form
    {
        public parts()
        {
            InitializeComponent();
            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM participants");
            comboBox1.DataSource = fillCountry;
            List<string> genres = Program.Select("SELECT genre FROM participants");
            List<string> genress = new List<string>();
            foreach (string genre in genres)
            {
                string[] genre1 = genre.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string gen in genre1)
                {
                    if (!genress.Contains(gen))
                        genress.Add(gen);
                }
            }
            genress.Sort();
            comboBox2.DataSource = genress.ToArray();
            List<string> parts = Program.Select("SELECT name FROM `participants`");
            int x = 10;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> genre = Program.Select("SELECT genre FROM participants WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(250, 200);
                try
                {
                    picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 200);
                lbl.Size = new Size(250, 60);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(button2_Click);
               
                Label labl = new Label();
                labl.Location = new Point(x, y + 255);
                labl.Size = new Size(250, 60);
                labl.Text = genre[0];
                labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;
                x = x + 270;
                if (x + 270 > 600)
                {
                    x = 10;
                    y = y + 320;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            participants f = new participants(lbl.Text);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            #region
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                List<string> parts = Program.Select("SELECT name FROM `participants` WHERE country ='" + comboBox1.Text + "' AND genre LIKE '%" + comboBox2.Text + "%'");
                int x = 10;
                int y = 5;
                for (int i = 0; i < parts.Count; i = i + 1)
                {
                    List<string> genre = Program.Select("SELECT genre FROM participants WHERE name ='" + parts[i] + "'");
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(x, y);
                    picB.Size = new Size(250, 200);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 200);
                    lbl.Size = new Size(250, 60);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 255);
                    labl.Size = new Size(250, 60);
                    labl.Text = genre[0];
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 270;
                    if (x + 270 > 600)
                    {
                        x = 10;
                        y = y + 320;
                    }
                    panel1.Controls.Add(picB);
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(labl);
                }
            }
            else if (comboBox1.Text != "")
            {
                List<string> parts = Program.Select("SELECT name FROM `participants` WHERE country ='" + comboBox1.Text + "'");
                int x = 10;
                int y = 5;
                for (int i = 0; i < parts.Count; i = i + 1)
                {
                    List<string> genre = Program.Select("SELECT genre FROM participants WHERE name ='" + parts[i] + "'");
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(x, y);
                    picB.Size = new Size(250, 200);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 200);
                    lbl.Size = new Size(250, 60);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 255);
                    labl.Size = new Size(250, 60);
                    labl.Text = genre[0];
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 270;
                    if (x + 270 > 600)
                    {
                        x = 10;
                        y = y + 320;
                    }
                    panel1.Controls.Add(picB);
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(labl);
                }
            }
            else if (comboBox2.Text != "")
            {
                List<string> parts = Program.Select("SELECT name FROM `participants` WHERE genre LIKE '%" + comboBox2.Text + "%'");
                int x = 10;
                int y = 5;
                for (int i = 0; i < parts.Count; i = i + 1)
                {
                    string genre = Program.Select("SELECT genre FROM participants WHERE name ='" + parts[i] + "'")[0];
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(x, y);
                    picB.Size = new Size(250, 200);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 200);
                    lbl.Size = new Size(250, 60);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 255);
                    labl.Size = new Size(250, 60);
                    labl.Text = genre;
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 270;
                    if (x + 270 > 600)
                    {
                        x = 10;
                        y = y + 320;
                    }
                    panel1.Controls.Add(picB);
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(labl);
                }
            }
            #endregion
        }

        private void parts_Load(object sender, EventArgs e)
        {

        }
    }
}
