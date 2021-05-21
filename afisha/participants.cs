using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using HtmlAgilityPack;

namespace AfishA
{
    public partial class participants : UserControl
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        string name;
        public participants(string nm)
        {
            name = nm;
            InitializeComponent();
            designTupoy.ApplyDesign(this);
            textBox1.BackColor = Properties.Settings.Default.color;
            // MessageBox.Show(Convert.ToString(Program.navigation_pos));
            if (Program.navigation.Count > Program.navigation_pos)
                Program.navigation.RemoveRange(Program.navigation_pos + 1, Program.navigation.Count - Program.navigation_pos - 1);
            Program.navigation.Add(this);
            Program.navigation_pos++;

            //ЗАПОЛНЕНИЕ ИНФОРМАЦИИ ОБ ИСПОЛНИТЕЛЕ
            Text = "Информация о " + name;
            label1.Text = name;
            label1.ForeColor = Color.Gold; ;
            label1.Font = new Font("Lucida Console", 20F, FontStyle.Regular, GraphicsUnit.Point, (204));

            List<string> info = Program.Select("SELECT descript, genre, country, mVmest, year FROM participants WHERE name = '" + name + "'");

            textBox1.Text = info[0];
            label2.Text = info[1];
            label2.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            label2.ForeColor = Color.Gold;
            label5.Text = info[2];
            label5.Location = new Point(16, 70);
            label5.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            label5.ForeColor = Color.Gold;
            label13.Text = "ГОД ОСНОВАНИЯ: " + info[4] + "";

            //ЗАПОЛНЕНИЕ ПОХОЖИХ ИСПОЛНИТЕЛЕЙ
            List<string> simpart = Program.Select("SELECT name, genre, year, country, mVmest FROM `participants` WHERE name != '" + name + "'");
            int wid = 5;
            int high = 5;
            for (int i = 0; i < simpart.Count; i += 5)
            {
                float diss = 0;

                if (simpart[i + 3] != info[2])
                    diss += 5;
                if (simpart[i + 2] != info[1])
                    diss += 10;

                int vmest1 = Convert.ToInt32(info[3]);
                int vmest2 = Convert.ToInt32(simpart[i + 4]);
                if (vmest1 > vmest2)
                    diss += 3 / 10 * vmest1 / vmest2;
                else
                    diss += 3 / 10 * vmest2 / vmest1;

                int year1 = Convert.ToInt32(info[4]);
                int year2 = Convert.ToInt32(simpart[i + 2]);
                if (year1 > year2)
                    diss += (year1 - year2) / 2;
                else
                    diss += (year2 - year1) / 2;

                if (diss < 15)
                {
                    PictureBox picB = new PictureBox();
                    picB.Location = new Point(wid, high);
                    picB.Size = new Size(120, 120);
                    try
                    {
                        picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + simpart[i] + "'");
                    }
                    catch (Exception) { }
                    picB.SizeMode = PictureBoxSizeMode.Zoom;

                    Label lbl = new Label();
                    lbl.Location = new Point(wid, high + 120);
                    lbl.Size = new Size(120, 30);
                    lbl.Text = simpart[i];
                    lbl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = Color.Gold;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += new EventHandler(button_Click);
                    wid = wid + 130;
                    if (wid + 130 > panel1.Width)
                    {
                        wid = 5;
                        high = high + 150;
                    }
                    panel5.Controls.Add(picB);
                    panel5.Controls.Add(lbl);
                }
            }

            //ЗАПОЛНЕНИЕ ПАНЕЛЬКИ СНИЗУ (ПРЕДЫДУЩИЕ И БУДУЩИЕ(СОЛЬНЫЕ) ВЫСТУПЛЕНИЯ)
            int his = Convert.ToInt32(Program.Select("SELECT COUNT(dt) FROM `history` WHERE participant='" + name + "'")[0]);
            int fut = Convert.ToInt32(Program.Select("SELECT COUNT(dt) FROM `ivents` WHERE name='" + name + "'")[0]);

            if (his != 0)//ЕСЛИ УЖЕ ГДЕ-ТО ВЫСТУПАЛ
            {
                List<string> part = Program.Select("SELECT dt FROM `history` WHERE participant='" + name + "'");
                for (int i = 0; i < part.Count; i = i + 1)
                {
                    /*List<string> ivent = Program.Select("SELECT ivent FROM `history` WHERE dt='" + part[i] + "'");*///тут должен быть поиск по дате (part[i]) и участнику (name) но пока как то никак
                    Label lbl = new Label();
                    lbl.ForeColor = Color.Gold;
                    lbl.Text = Convert.ToDateTime(part[i]).ToString("yyyy.MM.dd"); ;
                    lbl.Size = new Size(120, 30);
                    lbl.AutoSize = false;
                    lbl.Location = new Point(140, 10 + 30 * i);
                    panel3.Controls.Add(lbl);

                    Label labl = new Label();
                    labl.ForeColor = Color.Gold;
                    labl.Text = name;
                    labl.Size = new Size(120, 30);
                    labl.AutoSize = false;
                    labl.Location = new Point(10, 10 + 30 * i);
                    labl.Click += new EventHandler(solo_Click);
                    panel3.Controls.Add(labl);

                    string country = Program.Select("SELECT country FROM `history` WHERE dt='" + lbl.Text + "'")[0];//тут должен быть поиск по дате part[i] но пока как то никак
                    Label label = new Label();
                    label.ForeColor = Color.Gold;
                    label.Text = country;
                    label.Size = new Size(120, 30);
                    label.AutoSize = false;
                    label.Location = new Point(270, 10 + 30 * i);
                    panel3.Controls.Add(label);
                }
            }
            if (fut != 0)//ЕСЛИ ЕСТЬ ЗАПЛАНИРОВАННЫЕ КОНЦЕРТЫ(СОЛЬНЫЕ) 
            {
                List<string> part = Program.Select("SELECT dt FROM `ivents` WHERE name='" + name + "'");
                for (int i = 0; i < part.Count; i = i + 1)
                {
                    Label lbl = new Label();
                    lbl.ForeColor = Color.Gold;
                    lbl.Text = Convert.ToDateTime(part[i]).ToString("yyyy.MM.dd"); ;
                    lbl.Size = new Size(120, 30);
                    lbl.AutoSize = false;
                    lbl.Location = new Point(140, 10 + 30 * i);
                    panel4.Controls.Add(lbl);

                    Label labl = new Label();
                    labl.ForeColor = Color.Gold;
                    labl.Text = name;
                    labl.Size = new Size(120, 30);
                    labl.AutoSize = false;
                    labl.Location = new Point(10, 10 + 30 * i);
                    labl.Click += new EventHandler(solo_Click);
                    panel4.Controls.Add(labl);

                    string country = Program.Select("SELECT country FROM `ivents` WHERE dt='" + lbl.Text + "'")[0];//тут должен быть поиск по дате part[i] но пока как то никак
                    Label label = new Label();
                    label.ForeColor = Color.Gold;
                    label.Text = country;
                    label.Size = new Size(120, 30);
                    label.AutoSize = false;
                    label.Location = new Point(270, 10 + 30 * i);
                    panel4.Controls.Add(label);
                }
            }


            //ЗАПОЛНЕНИЕ ПАНЕЛИ СЛЕВА СНИЗУ(МУЗЫКА) 
            List<string> music = Program.Select("SELECT musicName1, musicName2, musicName3 FROM songs WHERE part_name = '" + name + "'");
            label6.Text = music[0];
            label7.Text = music[1];
            label8.Text = music[2];

            //КАРТИНКА ДА
            try
            {
                pictureBox1.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + name + "'");
            }
            catch (Exception) { }

            //ЗАПОЛНЕНИЕ ПАНЕЛИ СПРАВА(СОБЫТИЯ)
            List<string> parts = Program.Select("SELECT ivent FROM `tipasvyaznaverno` WHERE part= '" + name + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(120, 120);
                try
                {
                    picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 120);
                lbl.Size = new Size(120, 30);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = Color.Gold;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(button1_Click);
                x = x + 130;
                if (x + 130 > panel1.Width)
                {
                    x = 5;
                    y = y + 150;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
            }
        }
        private void solo_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            solo f = new solo(lbl.Text);
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            sobytie f = new sobytie(lbl.Text);
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }
        //PLAY
        #region
        private void button1_Click_1(object sender, EventArgs e)
        {
            string track1 = Program.Select("SELECT track1 FROM `participants` WHERE name='" + name + "'")[0];
            wmp.URL = "_.mp3";
            Program.SelectMusic(track1);
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            string track2 = Program.Select("SELECT track2 FROM `participants` WHERE name='" + name + "'")[0];
            wmp.URL = "_.mp3";
            Program.SelectMusic(track2);
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
            string track3 = Program.Select("SELECT track3 FROM `participants` WHERE name='" + name + "'")[0];
            wmp.URL = "_.mp3";
            Program.SelectMusic(track3);
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        #endregion
        //STOP
        private void button2_Click(object sender, EventArgs e)
        {
            wmp.controls.stop();
            wmp.URL = "_.mp3";
        }

        private void participants_FormClosing(object sender, FormClosingEventArgs e)
        {
            wmp.controls.stop();
            wmp.URL = "_.mp3";
        }

        private void button_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            participants f = new participants(lbl.Text);
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

