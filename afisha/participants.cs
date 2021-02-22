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
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Font = new Font("Lucida Console", 20F, FontStyle.Regular, GraphicsUnit.Point, (204));
            
            List<string> info = Program.Select("SELECT descript, genre, country FROM participants WHERE name = '" + name + "'");
            textBox1.Text = info[0];
            label2.Text = info[1];
            label2.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            label5.Text = info[2];
            label5.Location = new Point(16, 70);
            label5.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
          
            //

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
                    lbl.ForeColor = Color.White;
                    lbl.Text = Convert.ToDateTime(part[i]).ToString("yyyy.MM.dd"); ;
                    lbl.Size = new Size(120, 30);
                    lbl.AutoSize = false;
                    lbl.Location = new Point(140, 10 + 30 * i);
                    panel3.Controls.Add(lbl);

                    Label labl = new Label();
                    labl.ForeColor = Color.White;
                    labl.Text = name;
                    labl.Size = new Size(120, 30);
                    labl.AutoSize = false;
                    labl.Location = new Point(10, 10 + 30 * i);
                    labl.Click += new EventHandler(solo_Click);
                    panel3.Controls.Add(labl);
                    
                    string country = Program.Select("SELECT country FROM `history` WHERE dt='" + lbl.Text + "'")[0];//тут должен быть поиск по дате part[i] но пока как то никак
                    Label label = new Label();
                    label.ForeColor = Color.White;
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
                    lbl.ForeColor = Color.White;
                    lbl.Text = Convert.ToDateTime(part[i]).ToString("yyyy.MM.dd"); ;
                    lbl.Size = new Size(120, 30);
                    lbl.AutoSize = false;
                    lbl.Location = new Point(140, 10 + 30 * i);
                    panel4.Controls.Add(lbl);

                    Label labl = new Label();
                    labl.ForeColor = Color.White;
                    labl.Text = name;
                    labl.Size = new Size(120, 30);
                    labl.AutoSize = false;
                    labl.Location = new Point(10, 10 + 30 * i);
                    labl.Click += new EventHandler(solo_Click);
                    panel4.Controls.Add(labl);

                    string country = Program.Select("SELECT country FROM `ivents` WHERE dt='" + lbl.Text + "'")[0];//тут должен быть поиск по дате part[i] но пока как то никак
                    Label label = new Label();
                    label.ForeColor = Color.White;
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
           
            //ЗАПОЛНЕНИЕ ПАНЕЛИ СЛЕВА(СОБЫТИЯ)
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
                    lbl.ForeColor = SystemColors.ButtonFace;
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
            wmp.URL = "_.mp3";
            Program.SelectMusic("SELECT song1 FROM participants WHERE name='" + name + "'");
            try 
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            wmp.URL = "_.mp3";
            Program.SelectMusic("SELECT song2 FROM participants WHERE name='" + name + "'");
            try
            {
                wmp.URL = "sample.mp3";
                wmp.controls.play();
            }
            catch (Exception) { }
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
            wmp.URL = "_.mp3";
            Program.SelectMusic("SELECT song3 FROM participants WHERE name='" + name + "'");
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void participants_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

