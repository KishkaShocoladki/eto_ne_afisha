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
    
    public partial class parts : UserControl
    {
        public parts()
        {
            InitializeComponent();
            //MessageBox.Show(Convert.ToString(Program.navigation_pos));
            if (Program.navigation.Count > Program.navigation_pos)
                Program.navigation.RemoveRange(Program.navigation_pos + 1, Program.navigation.Count - Program.navigation_pos - 1);
            Program.navigation.Add(this);
            Program.navigation_pos++;
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
                picB.Size = new Size(170, 120);
                try
                {
                    picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 120);
                lbl.Size = new Size(170, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(button2_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 160);
                labl.Size = new Size(170, 40);
                labl.Text = genre[0];
                labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;
                x = x + 190;
                if (x + 190 > panel1.Width)
                {
                    x = 10;
                    y = y + 185;
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
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
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
                    picB.Size = new Size(170, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 120);
                    lbl.Size = new Size(170, 40);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 160);
                    labl.Size = new Size(170, 40);
                    labl.Text = genre[0];
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 190;
                    if (x + 190 > panel1.Width)
                    {
                        x = 10;
                        y = y + 185;
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
                    picB.Size = new Size(170, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 120);
                    lbl.Size = new Size(170, 40);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 160);
                    labl.Size = new Size(170, 40);
                    labl.Text = genre[0];
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 190;
                    if (x + 190 > panel1.Width)
                    {
                        x = 10;
                        y = y + 185;
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
                    picB.Size = new Size(170, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y + 120);
                    lbl.Size = new Size(170, 40);
                    lbl.Text = parts[i];
                    lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = SystemColors.ButtonFace;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button2_Click);

                    Label labl = new Label();
                    labl.Location = new Point(x, y + 160);
                    labl.Size = new Size(170, 40);
                    labl.Text = genre;
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 190;
                    if (x + 190 > panel1.Width)
                    {
                        x = 10;
                        y = y + 185;
                    }
                    panel1.Controls.Add(picB);
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(labl);
                }
            }
            #endregion
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
