using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AfishA
{
    public struct PLOSH
    {
        public string name;
        public string descript;
        public string city;
        public string vmest;
        public Label labeI;
        public PictureBox picB;

        public PLOSH(string name1, string descript1, string city1, string vmest1)
        {
            name = name1;
            descript = descript1;
            city = city1;
            vmest = vmest1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class plashadka : Form
    {
        public static List<PLOSH> ploshk = new List<PLOSH>();
        public plashadka()
        {
            InitializeComponent();
            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM ivents");
            comboBox1.DataSource = fillCountry;
    
            List<string> pls = Program.Select("SELECT name, description, city, vmest FROM `ploshki`");
            for (int i = 0; i < pls.Count; i = i + 4)
            {
                string name = pls[i];
                string descript = pls[i + 1];
                string city = pls[i + 2];
                string vmest = pls[i + 3];
                ploshk.Add(new PLOSH(name, descript, city, vmest));
            }

            int x = 10;
            int y = 120;
            for (int i = 0; i < ploshk.Count; i = i + 1)
            {
                ploshk[i].picB.Location = new Point(x, y);
                ploshk[i].picB.Size = new Size(250, 200);
                ploshk[i].picB.Text = ploshk[i].name;
                ploshk[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                ploshk[i].picB.Click += new EventHandler(button3_Click);
                try
                {
                    ploshk[i].picB.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + ploshk[i].name + "'");
                }
                catch (Exception) { }

                ploshk[i].labeI.Location = new Point(x, y + 200);
                ploshk[i].labeI.Size = new Size(250, 60);
                ploshk[i].labeI.Text = ploshk[i].name;
                ploshk[i].labeI.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                ploshk[i].labeI.ForeColor = SystemColors.ButtonFace;
                ploshk[i].labeI.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 270;
                if (x + 270 > 600)
                {
                    x = 10;
                    y = y + 210;
                }
                foreach (PLOSH pl in ploshk)
                {
                    Controls.Add(pl.labeI);
                    Controls.Add(pl.picB);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plashadka form2 = new plashadka();
            form2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 120;
            for (int i = 0; i < ploshk.Count; i = i + 1)
            {
                ploshk[i].labeI.Visible = false;
                ploshk[i].picB.Visible = false;
                bool show = true;

                if (comboBox2.Text != "" && ploshk[i].city != comboBox2.Text)
                {
                    show = false;
                }
                if (show)
                {
                    ploshk[i].picB.Visible = true;
                    ploshk[i].picB.Location = new Point(x, y);
                    ploshk[i].labeI.Visible = true;
                    ploshk[i].labeI.Location = new Point(x, y + 200);
                    x = x + 270;
                    if (x + 270 > 550)
                    {
                        x = 10;
                        y = y + 210;
                    }
                }
            }
        }
        private static void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ploshk.Count; i = i + 1)
            {
                if (((PictureBox)sender).Image == ploshk[i].picB.Image)
                {
                    ploshka f = new ploshka(ploshk[i]);
                    f.Show();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> fillPlosh = Program.Select("SELECT DISTINCT city FROM ivents WHERE country ='" + Convert.ToString(comboBox1.SelectedItem) + "'");
            comboBox2.DataSource = fillPlosh;
        }

        private void plashadka_Load(object sender, EventArgs e)
        {

        }
    }
}
