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
    public struct Ploshadka
    {
        public string name;
        public string descript;
        public int vmestimost;
        public string city;
        public Label labeI;
        public PictureBox picB;

        public Ploshadka(string name1, string descript1, int vmestimost1, string city1)
        {
            name = name1;
            descript = descript1;
            vmestimost = vmestimost1;
            city = city1;
            labeI = new Label();
            picB = new PictureBox();
        }
    }
        public partial class plashadka : Form
        {
            public static Ploshadka[] ploshka = new Ploshadka[2];
        public plashadka()
        {
            InitializeComponent();
               /* if ((Convert.ToString(comboBox1.SelectedItem)) == "США")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("ВАШИНГТОН");
                    comboBox2.Items.Add("АЙОВА");
                    comboBox2.Items.Add("МАССАЧУСЕТС");
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
                }*/

            

            ploshka[0] = new Ploshadka("ЛУЖНИКИ ПАРК", "ОПИСАНИЕ ПЛОЩАДКИ(КАК ДОБРАТЬсЯ И ПРОЧЕЕ)", 120000, "МОСКВА");
            ploshka[1] = new Ploshadka("ДОНИНГТОН-ПАРК", "ОПИСАНИЕ ПЛОЩАДКИ(КАК ДОБРАТЬсЯ И ПРОЧЕЕ ага)", 300000, "ЛЕСТЕРШИР");

            int x = 10;
            int y = 80;
            for (int i = 0; i < 2; i = i + 1)
            {
                ploshka[i].picB.Location = new Point(x, y);
                ploshka[i].picB.Size = new Size(250, 200);
                ploshka[i].picB.Text = ploshka[i].name;
                ploshka[i].picB.SizeMode = PictureBoxSizeMode.Zoom;
                ploshka[i].picB.Click += new EventHandler(button3_Click);
                try
                {
                    ploshka[i].picB.Load("../../kartinochki/" + ploshka[i].name + ".jpg");
                }
                catch (Exception) { }

                ploshka[i].labeI.Location = new Point(x, y + 200);
                ploshka[i].labeI.Size = new Size(250, 60);
                ploshka[i].labeI.Text = ploshka[i].name;
                ploshka[i].labeI.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                ploshka[i].labeI.ForeColor = System.Drawing.SystemColors.ButtonFace;

                x = x + 270;
                if (x + 270 > 550)
                {
                    x = 10;
                    y = y + 210;
                }
            }

            foreach (Ploshadka pl in ploshka)
            {
                Controls.Add(pl.labeI);
                Controls.Add(pl.picB);
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
            for (int i = 0; i < 2; i = i + 1)
            {
                ploshka[i].labeI.Visible = false;
                ploshka[i].picB.Visible = false;
                bool show = true;             
                    
                if (comboBox2.Text != "" && ploshka[i].city != comboBox2.Text)
                {
                    show = false;
                }
                if (show)
                {
                    ploshka[i].picB.Visible = true;
                    ploshka[i].picB.Location = new Point(x, y);
                    ploshka[i].labeI.Visible = true;
                    ploshka[i].labeI.Location = new Point(x, y + 200);
                    x = x + 270;
                    if (x + 270 > 550)
                    {
                        x = 10;
                        y = y + 210;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i = i + 1)
            {
                if (((PictureBox)sender).Image == ploshka[i].picB.Image)
                {
                    ploshka form = new ploshka(ploshka[i]);
                    form.Show();
                }
            }
        }

        private void plashadka_Load(object sender, EventArgs e)
        {

        }
    }
}
