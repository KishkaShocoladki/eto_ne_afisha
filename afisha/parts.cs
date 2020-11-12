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
    public struct part 
    {
        public string name;
        public string genre;
        public string country;
        public Label lbl;
        public Label labl;
        public PictureBox picB;
        public part(string name1, string genre1, string country1)
        {
            name = name1;
            genre = genre1;
            country = country1;
            lbl = new Label();
            labl = new Label();
            picB = new PictureBox();
        }
    }
    public partial class parts : Form
    {
        public static List<part> prt = new List<part>();
        public parts()
        {
            InitializeComponent();
            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM ivents");
            comboBox1.DataSource = fillCountry;
            List<string> part = Program.Select("SELECT name, genre, country FROM `participants`");
            for (int i = 0; i < part.Count; i = i + 3)
            {
                string name = part[i];
                string genre = part[i + 1];
                string country = part[i + 2];
                prt.Add(new part(name, genre, country));
            }
            int x = 10;
            int y = 80;
            for (int i = 0; i < prt.Count; i = i + 1)
            {
                prt[i].picB.Location = new Point(x, y);
                prt[i].picB.Size = new Size(250, 200);
                try
                {
                    prt[i].picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + prt[i].name + "'");
                }
                catch (Exception) { }
                prt[i].picB.SizeMode = PictureBoxSizeMode.Zoom;

                prt[i].lbl.Location = new Point(x, y + 200);
                prt[i].lbl.Size = new Size(250, 60);
                prt[i].lbl.Text = prt[i].name;
                prt[i].lbl.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, (204));
                prt[i].lbl.ForeColor = SystemColors.ButtonFace;
                prt[i].lbl.TextAlign = ContentAlignment.MiddleCenter;
                prt[i].lbl.Click += new EventHandler(button2_Click);

                prt[i].labl.Location = new Point(x, y + 255);
                prt[i].labl.Size = new Size(250, 60);
                prt[i].labl.Text = prt[i].genre;
                prt[i].labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                prt[i].labl.ForeColor = SystemColors.ControlDark;
                prt[i].labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 270;
                if (x + 270 > 600)
                {
                    x = 10;
                    y = y + 320;
                }
                panel1.Controls.Add(prt[i].picB);
                panel1.Controls.Add(prt[i].lbl);
                panel1.Controls.Add(prt[i].labl);
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
            int x = 10;
            int y = 80;
            for (int i = 0; i < prt.Count; i = i + 1)
            {
                prt[i].lbl.Visible = false;
                prt[i].labl.Visible = false;
                prt[i].picB.Visible = false;
                bool show = true;

                if (comboBox1.Text != "" && prt[i].country != comboBox1.Text)
                {
                    show = false;
                }
                if (show)
                {
                    prt[i].picB.Visible = true;
                    prt[i].picB.Location = new Point(x, y);
                    prt[i].lbl.Visible = true;
                    prt[i].lbl.Location = new Point(x, y + 200);
                    prt[i].labl.Visible = true;
                    prt[i].labl.Location = new Point(x, y + 255);
                    x = x + 270;
                    if (x + 270 > 600)
                    {
                        x = 10;
                        y = y + 320;
                    }
                }

            }
        }
    }
}
