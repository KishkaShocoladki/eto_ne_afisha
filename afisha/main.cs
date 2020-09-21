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
        public string agelimit;
        public Label labeI;
        public PictureBox picB;

        public Ivent(string name1, string descript1, string city1, string country1, string type1, string area1, string agelimit1)
        {
            name = name1;
            descript = descript1;
            city = city1;
            country = country1;
            type = type1;
            area = area1;
            agelimit = agelimit1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class main : Form
    {
        public static Ivent[] sobytia = new Ivent[2];
        //SoundPlayer player = null;

        public main()
        {
            InitializeComponent();

            sobytia[0] = new Ivent("PARK LIVE 2021", "ТИП ЕГО ОПИСАНИЕ", "МОСКВА", "РОССИЯ", "ФЕСТИВАЛЬ", "ЛУЖНИКИ ПАРК", "16+");
            sobytia[1] = new Ivent("DOWNLOAD FESTIVAL", "А ГДЕ", "ЛЕСТЕРШИР", "ВЕЛИКОБРИТАНИЯ", "ФЕСТИВАЛЬ", "ДОНИНГТОН-ПАРК", "16+");

            int x = 10;
            int y = 100;
            for (int i = 0; i < 2; i = i + 1)
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

                x = x + 270;
                if (x + 270 > Width)
                {
                    x = 10;
                    y = y + 210;
                }
            }

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
            for (int i = 0; i < 2; i = i + 1)
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

        }

        private void main_Load(object sender, EventArgs e)
        {
            //player = new SoundPlayer();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

