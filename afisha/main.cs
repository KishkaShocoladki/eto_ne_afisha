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
       // public string agelimit;
        public Label labeI;
        public PictureBox picB;

        public Ivent(string name1, string descript1, string city1, string country1, string type1, string area1)
        {
            name = name1;
            descript = descript1;
            city = city1;
            country = country1;
            type = type1;
            area = area1;
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
            int y = 120;
            for (int i = 0; i < sobytia.Count; i = i + 1)
            {
                sobytia[i].picB.Location = new Point(x, y);
                sobytia[i].picB.Size = new Size(250, 200);
                sobytia[i].picB.Text = sobytia[i].name;
                sobytia[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                sobytia[i].picB.Click += new EventHandler(button3_Click);
                try
                {
                    sobytia[i].picB.Load("../../kartinochki/" + sobytia[i].name + ".jpg");
                }
                catch (Exception) { }

                sobytia[i].labeI.Location = new Point(x, y + 200);
                sobytia[i].labeI.Size = new Size(250, 60);
                sobytia[i].labeI.Text = sobytia[i].name;
                sobytia[i].labeI.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                sobytia[i].labeI.ForeColor = System.Drawing.SystemColors.ButtonFace;
                sobytia[i].labeI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                x = x + 270;
                if (x + 270 > 1000)
                {
                    x = 10;
                    y = y + 210;
                }
            }
        }
        public main()
        {
            InitializeComponent();
          //  string connString = "Server=VH287.spaceweb.ru; Database = beavisabra_afish;"
           //         + "port = 3306; User Id = beavisabra_afish; password = Beavis1989";
          //  conn = new MySqlConnection(connString);
            List<string> results = Program.Select("SELECT * FROM `ivents`");
            for (int i = 0; i < results.Count; i = i + 12)
            {
                string name = results[i];
                string descript = results[i + 1];
                string city = results[i + 2];
                string country = results[i + 3];
                string type = results[i + 4];
                string area = results[i + 5];
                sobytia.Add(new Ivent(name, descript, city, country, type, area));
            }
            fillsob();

            foreach (Ivent iv in sobytia)
            {
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
            int y = 100;
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
            for (int i = 0; i < sobytia.Count; i = i + 1)
            {
                if (sobytia[i].type == "ФЕСТИВАЛЬ")
                {
                    if (((PictureBox)sender).Image == sobytia[i].picB.Image)
                    {
                        sobytie f = new sobytie(sobytia[i]);
                        f.Show();
                    }
                }
                else if (sobytia[i].type == "СОЛО КОНЦЕРТ")
                {
                    if (((PictureBox)sender).Image == sobytia[i].picB.Image)
                    {
                        //solnyk f = new solnyk(sobytia[i]);
                        //f.Show();
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
      /*  private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            int year = new Year();

        }*/
    }
}

