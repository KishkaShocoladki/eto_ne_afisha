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
        public string kartinochka;
        public string kartinochka2;
        public string kartinochka3;
        public string vmest;
        public Label labeI;
        public PictureBox picB;

        public PLOSH(string name1, string descript1, string city1, string kartinochka1, string kartinochka21, string kartinochka31, string vmest1)
        {
            name = name1;
            descript = descript1;
            city = city1;
            kartinochka = kartinochka1;
            kartinochka2 = kartinochka21;
            kartinochka3 = kartinochka31;
            vmest = vmest1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class plashadka : Form
    {
        public static List<PLOSH> ploshk = new List<PLOSH>();
        /*public static void fills()
        {
            String connString = "Server=VH287.spaceweb.ru; Database = beavisabra_afish;"
                  + "port = 3306; User Id = beavisabra_afish; password = Beavis1989";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            List<string> result = new List<string>();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ploshki`", conn);
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string descript = reader.GetString(1);
                string city = reader.GetString(2);
                string kartinochka = reader.GetString(3);
                string kartinochka2 = reader.GetString(4);
                string kartinochka3 = reader.GetString(5);
                string vmest = reader.GetString(6);
                ploshk.Add(new PLOSH(name, descript, city, kartinochka, kartinochka2, kartinochka3, vmest));
                result.Add(name);
            }
            reader.Close();
            conn.Close();
        }*/
        public plashadka()
        {
            InitializeComponent();
         
            List<string> pls = Program.Select("SELECT * FROM `ploshki`");
            for (int i = 0; i < pls.Count; i = i + 7)
            {
                string name = pls[i];
                string descript = pls[i + 1];
                string city = pls[i + 2];
                string kartinochka = pls[i + 3];
                string kartinochka2 = pls[i + 4];
                string kartinochka3 = pls[i + 5];
                string vmest = pls[i + 6];
                ploshk.Add(new PLOSH(name, descript, city, kartinochka, kartinochka2, kartinochka3, vmest));
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
                ploshk[i].labeI.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                ploshk[i].labeI.ForeColor = System.Drawing.SystemColors.ButtonFace;
                ploshk[i].labeI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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
            int y = 80;
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
            if ((Convert.ToString(comboBox1.SelectedItem)) == "США")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("САКРАМЕНТО");
                comboBox2.Items.Add("АЙОВА");
                comboBox2.Items.Add("ОРЛАНДО");
                comboBox2.Items.Add("НЕВАДА");
            }
            else if ((Convert.ToString(comboBox1.SelectedItem)) == "ВЕЛИКОБРИТАНИЯ")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("ЛОНДОН");
                comboBox2.Items.Add("ЛЕСТЕРШИР");
                comboBox2.Items.Add("БОСТОН");
                comboBox2.Items.Add("ГЛАЗГО");
            }
            else if ((Convert.ToString(comboBox1.SelectedItem)) == "РОССИЯ")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("МОСКВА");
                comboBox2.Items.Add("САНКТ-ПЕТЕРБУРГ");
                comboBox2.Items.Add("КАЗАНЬ");
                comboBox2.Items.Add("ЕКАТЕРИНБУРГ");
            }
            else if ((Convert.ToString(comboBox1.SelectedItem)) == "ЯПОНИЯ")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("ОСАКА");
                comboBox2.Items.Add("ТОКИО");
                comboBox2.Items.Add("НАЭБА");
                comboBox2.Items.Add("ТИБА");
            }
        }

        private void plashadka_Load(object sender, EventArgs e)
        {

        }
    }
}
