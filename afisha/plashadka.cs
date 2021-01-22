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
    public partial class plashadka : UserControl
    {
        public plashadka()
        {
            InitializeComponent();
            if (Program.navigation.Count > Program.navigation_pos)
                Program.navigation.RemoveRange(Program.navigation_pos + 1, Program.navigation.Count - Program.navigation_pos - 1);
            Program.navigation.Add(this);
            Program.navigation_pos++;
            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM ivents");
            comboBox1.DataSource = fillCountry;

            List<string> ploshk = Program.Select("SELECT name FROM `ploshki`");
            int x = 10;
            int y = 5;
            for (int i = 0; i < ploshk.Count; i = i + 1)
            {
                string city = Program.Select("SELECT city FROM ploshki WHERE name ='" + ploshk[i] + "'")[0];
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(170, 120);
                try
                {
                    picB.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + ploshk[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 120);
                lbl.Size = new Size(170, 40);
                lbl.Text = ploshk[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(button2_Click);

                Label labl = new Label();
                labl.Location = new Point(x, y + 160);
                labl.Size = new Size(170, 40);
                labl.Text = city;
                labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;
                x = x + 190;
                if (x + 190 > 605)
                {
                    x = 10;
                    y = y + 185;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plashadka form2 = new plashadka();
            form2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            #region
            if (comboBox2.Text != "")
            {
                List<string> parts = Program.Select("SELECT name FROM `ploshki` WHERE city='" + comboBox2.Text + "'");
                int x = 10;
                int y = 5;
                for (int i = 0; i < parts.Count; i = i + 1)
                {
                    List<string> city = Program.Select("SELECT city FROM ploshki WHERE name ='" + parts[i] + "'");
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(x, y);
                    picB.Size = new Size(170, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + parts[i] + "'");
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
                    labl.Text = city[0];
                    labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    labl.ForeColor = SystemColors.ControlDark;
                    labl.TextAlign = ContentAlignment.MiddleCenter;
                    x = x + 190;
                    if (x + 190 > 605)
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
        private static void button3_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            ploshka f = new ploshka(lbl.Text);
            f.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> fillPlosh = Program.Select("SELECT DISTINCT city FROM ivents WHERE country ='" + Convert.ToString(comboBox1.SelectedItem) + "'");
            comboBox2.DataSource = fillPlosh;
        }

        private void plashadka_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
