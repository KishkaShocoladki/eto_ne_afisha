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
    public struct Ivent
    {
        public string name;
        public string descript;
        public string city;
        public string country;
        public string type;
        public string area;
        public string dt;
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
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class mainCntrl : UserControl
    {
        Panel panel;
        public static List<Ivent> sobytia = new List<Ivent>();
        public mainCntrl(Panel _panel1)
        {
            panel = _panel1;
            InitializeComponent();
            if (Program.navigation.Count > Program.navigation_pos)
                Program.navigation.RemoveRange(Program.navigation_pos + 1, Program.navigation.Count - Program.navigation_pos - 1);
            Program.navigation.Add(this);
            Program.navigation_pos++;

            List<string> fillCountry = Program.Select("SELECT DISTINCT country FROM ivents");
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
            comboBox3.DataSource = genress.ToArray();
            List<string> fillType = Program.Select("SELECT DISTINCT type FROM ivents");
            comboBox2.DataSource = fillType;

            List<string> results = Program.Select("SELECT `name`, `descript`, `city`, `country`, `type`, `area`, `dt` FROM `ivents`");//ts
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

            int x = 10;
            int y = 140;
            for (int i = 0; i < sobytia.Count; i = i + 1)
            {
                sobytia[i].picB.Location = new Point(x, y);
                sobytia[i].picB.Size = new Size(250, 200);
                sobytia[i].picB.Text = sobytia[i].name;
                sobytia[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                sobytia[i].picB.Click += new EventHandler(button3_Click);

                sobytia[i].labeI.Location = new Point(x, y + 210);
                sobytia[i].labeI.Size = new Size(250, 60);
                sobytia[i].labeI.Text = sobytia[i].name;
                sobytia[i].labeI.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, (204));
                sobytia[i].labeI.ForeColor = SystemColors.ButtonFace;
                sobytia[i].labeI.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 260;
                if (x + 260 > 855)
                {
                    x = 10;
                    y = y + 300;
                }
            }

            foreach (Ivent iv in sobytia)
            {
                try
                {
                    iv.picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + iv.name + "'");
                }
                catch (Exception) { }
                panel1.Controls.Add(iv.labeI);
                panel1.Controls.Add(iv.picB);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            plashadka fm = new plashadka();
            panel1.Controls.Clear();
            panel1.Controls.Add(fm);
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
                    sobytia[i].picB.Size = new Size(250, 200);
                    sobytia[i].picB.Click += new EventHandler(button3_Click);
                    sobytia[i].labeI.Visible = true;
                    sobytia[i].labeI.Location = new Point(x, y + 210);
                    sobytia[i].labeI.Size = new Size(250, 60);
                    x = x + 260;
                    if (x + 260 > 855)
                    {
                        x = 10;
                        y = y + 300;
                    }
                    panel1.Controls.Add(sobytia[i].labeI);
                    panel1.Controls.Add(sobytia[i].picB);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sobytia.Count; i = i + 1)//sobytia.Count
            {
                if (sobytia[i].type == "ФЕСТИВАЛЬ")
                {
                    //if (((PictureBox)sender).Image == sobytia[i].picB.Image)

                    PictureBox pic = (PictureBox)sender;
                    sobytie f = new sobytie(pic.Text);
                    Program.panel1.Controls.Clear();
                    Program.panel1.Controls.Add(f);

                }
                else if (sobytia[i].type == "СОЛО КОНЦЕРТ")
                {
                    PictureBox pic = (PictureBox)sender;
                    solo f = new solo(pic.Text);
                    Program.panel1.Controls.Clear();
                    Program.panel1.Controls.Add(f);
                }
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
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                List<string> ivents = Program.Select("SELECT ivents.name FROM `ivents` JOIN tipasvyaznaverno ON ivents.name = tipasvyaznaverno.ivent JOIN participants ON tipasvyaznaverno.part = participants.name WHERE genre LIKE '%" + comboBox3.Text + "%'");//, tipasvyaznaverno.part, participants.name
                List<string> solo = Program.Select("SELECT ivents.name FROM ivents JOIN participants ON ivents.name = participants.name WHERE genre LIKE '%" + comboBox3.Text + "%'");

                int x = 10;
                int y = 140;
                for (int i = 0; i < sobytia.Count; i = i + 1)
                {
                    sobytia[i].labeI.Visible = false;
                    sobytia[i].picB.Visible = false;
                    bool show = false;

                    for (int z = 0; z < ivents.Count; z = z + 1)
                    {
                        for (int q = 0; q < solo.Count; q = q + 1)
                        {
                            if (sobytia[i].name == ivents[z])
                            {
                                show = true;
                            }
                            else if (sobytia[i].name == solo[q])
                            {
                                show = true;
                            }
                        }
                    }
                    if (show)
                    {
                        sobytia[i].picB.Visible = true;
                        sobytia[i].picB.Location = new Point(x, y);
                        sobytia[i].picB.Size = new Size(250, 200);
                        sobytia[i].picB.Click += new EventHandler(button3_Click);
                        sobytia[i].labeI.Visible = true;
                        sobytia[i].labeI.Location = new Point(x, y + 210);
                        sobytia[i].labeI.Size = new Size(250, 60);
                        x = x + 260;
                        if (x + 260 > 855)
                        {
                            x = 10;
                            y = y + 300;
                        }
                        panel1.Controls.Add(sobytia[i].labeI);
                        panel1.Controls.Add(sobytia[i].picB);
                    }
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string yMd = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            List<string> ivents = Program.Select("SELECT name FROM `ivents` WHERE dt = '" + yMd + "'");
            int x = 10;
            int y = 140;
            if (ivents.Count == 0)
            {
                if (MessageBox.Show("СОБЫТИЙ НА ВЫБРАННУЮ ДАТУ НЕТ. ПРИ НАЖАТИИ НА «ОК» ПОКАЖУТСЯ СОБЫТИЯ ПОЗЖЕ ВЫБРАННОЙ ДАТЫ") == DialogResult.OK)
                {
                    for (int i = 0; i < sobytia.Count; i = i + 1)
                    {
                        sobytia[i].labeI.Visible = false;
                        sobytia[i].picB.Visible = false;
                        bool show = false;

                        List<string> ivent = Program.Select("SELECT name FROM `ivents` WHERE dt >= '" + yMd + "'");
                        for (int z = 0; z < ivent.Count; z = z + 1)
                        {
                            if (sobytia[i].name == ivent[z])
                            {
                                show = true;
                            }
                        }
                        if (show)
                        {
                            sobytia[i].picB.Visible = true;
                            sobytia[i].picB.Location = new Point(x, y);
                            sobytia[i].picB.Size = new Size(250, 200);
                            sobytia[i].picB.Click += new EventHandler(button3_Click);
                            sobytia[i].labeI.Visible = true;
                            sobytia[i].labeI.Location = new Point(x, y + 210);
                            sobytia[i].labeI.Size = new Size(250, 60);
                            x = x + 260;
                            if (x + 260 > 1050)
                            {
                                x = 10;
                                y = y + 300;
                            }
                        }
                    }
                }
            }
            else if (ivents.Count > 0)
            {
                for (int i = 0; i < sobytia.Count; i = i + 1)
                {
                    sobytia[i].labeI.Visible = false;
                    sobytia[i].picB.Visible = false;
                    bool show = false;
                    for (int z = 0; z < ivents.Count; z = z + 1)
                    {
                        if (sobytia[i].name == ivents[z])
                        {
                            show = true;
                        }
                    }
                    if (show)
                    {
                        sobytia[i].picB.Visible = true;
                        sobytia[i].picB.Location = new Point(x, y);
                        sobytia[i].picB.Size = new Size(250, 200);
                        sobytia[i].picB.Click += new EventHandler(button3_Click);
                        sobytia[i].labeI.Visible = true;
                        sobytia[i].labeI.Location = new Point(x, y + 210);
                        sobytia[i].labeI.Size = new Size(250, 60);
                        x = x + 260;
                        if (x + 260 > 855)
                        {
                            x = 10;
                            y = y + 300;
                        }
                        panel1.Controls.Add(sobytia[i].labeI);
                        panel1.Controls.Add(sobytia[i].picB);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
