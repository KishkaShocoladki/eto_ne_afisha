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
    public partial class sobytie : Form
    {
        public static List<Participants> part = new List<Participants>();
        Ivent sob;
       /* public static void fillsob()
        {
            string[] lines = System.IO.File.ReadAllLines("участнеки.txt");
            foreach (string str in lines)
            {
                string[] parts = str.Split(new string[] { "/ " }, StringSplitOptions.None);
                part.Add(new Participants(parts[0], parts[1], parts[2], parts[3]));
            }
        }*/

        public sobytie(Ivent sobytie1)
        {
            sob = sobytie1;
            InitializeComponent();

            List<string> parts = Program.Select("SELECT part FROM `tipasvyaznaverno` WHERE ivent='" + sob.name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
                PictureBox picB = new PictureBox();
                picB.Location = new Point(10, 5 + 130 * i);
                picB.Size = new Size(120, 120);
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }

                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(120, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 120 + 130 * i);
                lbl.Click += new EventHandler(button2_Click);

                button2.Tag = lbl.Text;
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(picB);
            }

            Text = "Информация о " + sob.name;
            
            try
            {
                label1.Text = sob.name;
                label2.Text = sob.area;
                pictureBox1.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + sob.name + "'");
                pictureBox2.Image = Program.SelectImage("SELECT pic2 FROM ivents WHERE name = '" + sob.name + "'");
                pictureBox3.Image = Program.SelectImage("SELECT pic3 FROM ivents WHERE name = '" + sob.name + "'");
                pictureBox4.Image = Program.SelectImage("SELECT pic4 FROM ivents WHERE name = '" + sob.name + "'");
                textBox1.Text = sob.descript;
                //System.IO.File.ReadAllLines("../../Pictures/" + sob.name + "Б1" + ".txt");
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
            if (Program.user == "_")
            {
                MessageBox.Show("ЗАРЕГИСТРИРУЙТЕСЬ ИЛИ ВОЙДИТЕ В АККАУНТ, ЧТОБЫ КУПИТЬ БИЛЕТ  ┬┴┬┴┤(･_├┬┴┬┴");
            }
            else
            {
                buy f = new buy(sob.name);
                f.Show();
            }
            
        }

        private void sobytie_Load(object sender, EventArgs e)
        {

        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            rewievs f = new rewievs();
            f.Show();
        }*/
    }
}