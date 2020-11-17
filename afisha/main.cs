using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AfishA
{
    public struct Ivent
    {
        public string name;
        public string descript;
        public string city;
        public string country;
        public string type;
        public string area;
        public string dt;
        // public string agelimit;
        public Label labeI;
        public PictureBox picB;

        public Ivent(string name1, string descript1, string city1, string country1, string type1, string area1, string dt1)
        {
            name = name1;
            descript = descript1;
            city = city1;
            country = country1;
            type = type1;
            area = area1;
            dt = dt1; 
            //agelimit = agelimit1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class main : Form
    {
        public static List<Ivent> sobytia = new List<Ivent>();
        SoundPlayer player = null;
        public static void fillsob()
        { 
            int x = 10;
            int y = 140;
            for (int i = 0; i < sobytia.Count; i = i + 1)
            {
                sobytia[i].picB.Location = new Point(x, y);
                sobytia[i].picB.Size = new Size(250, 200);
                sobytia[i].picB.Text = sobytia[i].name;
                sobytia[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                sobytia[i].picB.Click += new EventHandler(button3_Click);
                
               // sobytia[i].picB.BackgroundImage = Image.FromFile("C:/Users/User/Desktop/eto_ne_afisha-master/kartinochki/про щяй.jpg");
               // sobytia[i].picB.BackgroundImageLayout = ImageLayout.Zoom;

                sobytia[i].labeI.Location = new Point(x, y + 210);
                sobytia[i].labeI.Size = new Size(250, 60);
                sobytia[i].labeI.Text = sobytia[i].name;
                sobytia[i].labeI.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, (204));
                sobytia[i].labeI.ForeColor = SystemColors.ButtonFace;
                sobytia[i].labeI.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 260;
                if (x + 260 > 1000)
                {
                    x = 10;
                    y = y + 300;
                }
            }
        }
        public main()
        {
            InitializeComponent();
            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM ivents");
            comboBox1.DataSource = fillCountry;
            List<string> fillType = Program.Select("SELECT DISTINCT type FROM ivents");
            comboBox2.DataSource = fillType;

            List<string> results = Program.Select("SELECT `name`, `descript`, `city`, `country`, `type`, `area`, `dt` FROM `ivents`");
            for (int i = 0; i < results.Count; i = i + 7)
            {
                string name = results[i];
                string descript = results[i + 1];
                string city = results[i + 2];
                string country = results[i + 3];
                string type = results[i + 4];
                string area = results[i + 5];
                string dt = results[i + 6];
                Ivent iv = new Ivent(name, descript, city, country, type, area, dt);
                sobytia.Add(iv);
            }
            fillsob();

            foreach (Ivent iv in sobytia)
            {
                try 
                {
                    //DateTime myDate = DateTime.ParseExact(iv.dt, "dd-MM-yyyy HH:mm:ss",
                     //                  System.Globalization.CultureInfo.InvariantCulture);
                    iv.picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + iv.name + "'");
                }
                catch(Exception) { }
                Controls.Add(iv.labeI);
                Controls.Add(iv.picB);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plashadka form = new plashadka();
            form.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 140;
            for (int i = 0; i < sobytia.Count; i = i + 1)
            {
                sobytia[i].labeI.Visible = false;
                sobytia[i].picB.Visible = false;
                bool show = true;

                if (comboBox1.Text != "" && sobytia[i].country != comboBox1.Text)
                {
                    show = false;
                }
                else if (comboBox2.Text != "" && sobytia[i].type != comboBox2.Text)
                {
                    show = false;
                }
                else if (comboBox4.Text != "" && sobytia[i].area != comboBox4.Text)
                {
                    show = false;
                }
                
                if (show)
                {
                    sobytia[i].picB.Visible = true;
                    sobytia[i].picB.Location = new Point(x, y);
                    sobytia[i].labeI.Visible = true;
                    sobytia[i].labeI.Location = new Point(x, y + 200);
                    x = x + 270;
                    if (x + 270 > Width)
                    {
                        x = 10;
                        y = y + 210;
                    }
                }
            }
        }
        public static void button3_Click(object sender, EventArgs e)
        {
           for (int i = 0; i < sobytia.Count; i = i + 1)//sobytia.Count
            {
                if (sobytia[i].type == "ФЕСТИВАЛЬ")
                {
                    if (((PictureBox)sender).Image == sobytia[i].picB.Image)
                    {
                        PictureBox pic = (PictureBox)sender;
                        sobytie f = new sobytie(pic.Text);
                        f.Show();
                    }
                }
                else if (sobytia[i].type == "СОЛО КОНЦЕРТ")
                {
                    if (((PictureBox)sender).Image == sobytia[i].picB.Image)
                    {
                        PictureBox pic = (PictureBox)sender;
                        solo f = new solo(pic.Text);
                        f.Show();
                    }
                }
            }
        }
        private void main_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                player.SoundLocation = ("../../kartinochki/Driving.wav.wav");
                player.Play();
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button lbl = (Button)sender;
            reg f = new reg(lbl.Text);
            f.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Button lbl = (Button)sender;
            reg f = new reg(lbl.Text);
            f.ShowDialog();
            if (Program.user != "_")
            {
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = true;
                button9.Visible = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = false;
            button9.Visible = false;

            Program.user = "_";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Program.user != "_")
            {
                user f = new user();
                f.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> fillPlosh = Program.Select("SELECT DISTINCT area FROM ivents WHERE country ='" + Convert.ToString(comboBox1.SelectedItem) + "'");
            comboBox4.DataSource = fillPlosh;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            parts f = new parts();
            f.Show();
        }



        /*  private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
{
DateTime date = dateTimePicker1.Value;
int year = new Year();

}*/
    }
}

