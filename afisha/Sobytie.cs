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
    public struct Participants
    {
        public string name;
        public string descript;
        public string sobytia;
        public string genre;
        public Label labeI;
        public PictureBox picB;

        public Participants(string name1, string descript1, string sobytia1, string genre1)
        {
            name = name1;
            descript = descript1;
            sobytia = sobytia1;
            genre = genre1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
    public partial class sobytie : UserControl
    {
        public static List<Participants> part = new List<Participants>();

        string name;
        public sobytie(string sob)
        {
            name = sob;
            InitializeComponent();
            Program.navigation.Add(this);
            List<string> history = Program.Select("SELECT dt FROM `history` WHERE ivent='" + name + "'");
            for (int i = 0; i < history.Count; i = i + 1)
            {
                List<string> hCountry = Program.Select("SELECT country FROM `history` WHERE ivent='" + name + "'");//' AND dt ='" + history[i] + "'"
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = hCountry[i];
                lbl.Size = new Size(115, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(5, 10 + 30 * i);
                
                Label labl = new Label();
                labl.ForeColor = Color.White;
                labl.Text = Convert.ToDateTime(history[i]).ToString("d.MM.yyyy");
                labl.Size = new Size(61, 30);
                labl.AutoSize = false;
                labl.Location = new Point(121, 10 + 30 * i);
                panel2.Controls.Add(labl);
                panel2.Controls.Add(lbl);
            }
            
            List<string> parts = Program.Select("SELECT part FROM `tipasvyaznaverno` WHERE ivent='" + sob + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(120, 120);
                try
                {
                    picB.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + parts[i] + "'");
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
                lbl.Click += new EventHandler(button2_Click);
                x = x + 130;
                if (x + 130 > panel1.Width)
                {
                    x = 5;
                    y = y + 150;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
            }

            Text = "Информация о " + sob;
            List<string> info = Program.Select("SELECT area, descript FROM ivents WHERE name = '" + sob + "'");

            try
            {
                label1.Text = sob;
                label2.Text = info[0];
                pictureBox1.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + sob + "'");
                pictureBox2.Image = Program.SelectImage("SELECT pic2 FROM ivents WHERE name = '" + sob + "'");
                pictureBox3.Image = Program.SelectImage("SELECT ploshki.kartinka1 FROM ploshki JOIN ivents ON ploshki.name = ivents.area WHERE ivents.name = '" + name + "'");
                textBox1.Text = info[1];
            }
            catch (Exception) { }

            foreach (Participants part in part)
            {
                Controls.Add(part.labeI);
                Controls.Add(part.picB);
            }           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            participants f = new participants(lbl.Text);
            f.Show();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            cacaгеo f = new cacaгеo();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dt = Program.Select("SELECT dt FROM ivents WHERE name='" + name + "'")[0];
            DateTime dat = Convert.ToDateTime(dt);
            if (dat >= DateTime.Now)
            {
                if (Program.user == "_")
                {
                    MessageBox.Show("ЗАРЕГИСТРИРУЙТЕСЬ ИЛИ ВОЙДИТЕ В АККАУНТ, ЧТОБЫ КУПИТЬ БИЛЕТ  ┬┴┬┴┤(･_├┬┴┬┴");
                }
                else
                {
                    buy f = new buy(name);
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("БИЛЕТОВ НЕТ, Т.К. СОБЫТИЕ УЖЕ ЗАКОНЧИЛОСЬ");
            }
        }

        private void sobytie_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            rewievs f = new rewievs(name);
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            rewievs f = new rewievs();
            f.Show();
        }*/
    }
}