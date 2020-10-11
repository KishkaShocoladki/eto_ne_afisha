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
        public static void fills()
        {
            String connString = "Server=VH287.spaceweb.ru; Database = beavisabra_afish;"
                    + "port = 3306; User Id = beavisabra_afish; password = Beavis1989";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            List<string> result = new List<string>();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ivents`", conn);
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string descript = reader.GetString(1);
                string city = reader.GetString(2);
                string country = reader.GetString(3);
                string type = reader.GetString(4);
                string area = reader.GetString(5);
                //DateTime dt = reader.GetDateTime(7);
                // reader.GetValue.ToString
                sobytia.Add(new Ivent(name, descript, city, country, type, area));
                result.Add(name);
            }
            reader.Close();
            conn.Close();
        }
        SoundPlayer player = null;
        public static void fillsob()
        {
            /* string[] lines = System.IO.File.ReadAllLines("ивентеки.txt");
             foreach (string str in lines)
             {
                 string[] parts = str.Split(new string[] { ", " }, StringSplitOptions.None);
                 sobytia.Add(new Ivent(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]));
             }*/
            fills();
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
                        solnyk f = new solnyk(sobytia[i]);
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
      /*  private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            int year = new Year();

        }*/
    }
}

