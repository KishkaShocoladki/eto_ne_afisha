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
    public partial class solo : UserControl
    {
        string sbyt;
        string plosh;
        public solo(string name)
        {
            sbyt = name;
            InitializeComponent();
            designTupoy.ApplyDesign(this);
            textBox1.BackColor = Properties.Settings.Default.color;

            Program.navigation.Add(this);

            List<string> parts = Program.Select("SELECT dt FROM `history` WHERE participant='" + name + "'");
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> ivents = Program.Select("SELECT ivent FROM `history` WHERE participant='" + name + "'");
                List<string> country = Program.Select("SELECT country FROM `history` WHERE participant='" + name + "'");
                Label lbl = new Label();
                lbl.ForeColor = Color.Khaki;
                lbl.Text = ivents[i];
                lbl.Size = new Size(93, 40);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 10 + 40 * i);
                
                Label labl = new Label();
                labl.ForeColor = Color.Khaki;
                labl.Text = Convert.ToDateTime(parts[i]).ToString("d.MM.yyyy");
                labl.Size = new Size(93, 30);
                labl.AutoSize = false;
                labl.Location = new Point(103, 10 + 40 * i);
                
                Label lbel = new Label();
                lbel.ForeColor = Color.Khaki;
                lbel.Text = country[i];
                lbel.Size = new Size(93, 30);
                lbel.AutoSize = false;
                lbel.Location = new Point(206, 10 + 40 * i);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
                panel1.Controls.Add(lbel);
            }
            Text = "Информация о " + name;
            List<string> info = Program.Select("SELECT area, descript FROM ivents WHERE name = '" + name + "'");
            try
            {
                label1.Text = name;
                label2.Text = info[0];
                plosh = info[0];
                pictureBox1.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + name + "'");
                pictureBox2.Image = Program.SelectImage("SELECT pic2 FROM ivents WHERE name = '" + name + "'");
                pictureBox3.Image = Program.SelectImage("SELECT ploshki.kartinka1 FROM ploshki JOIN ivents ON ploshki.name = ivents.area WHERE ivents.name = '" + name + "'");
                textBox1.Text = info[1];
            }
            catch (Exception) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string dt = Program.Select("SELECT dt FROM ivents WHERE name='" + sbyt + "'")[0];
            DateTime dat = Convert.ToDateTime(dt);
            if (dat >= DateTime.Now)
            {
                if (Program.user == "_")
                {
                    MessageBox.Show("ЗАРЕГИСТРИРУЙТЕСЬ ИЛИ ВОЙДИТЕ В АККАУНТ, ЧТОБЫ КУПИТЬ БИЛЕТ  ┬┴┬┴┤(･_├┬┴┬┴");
                }
                else
                {
                    buy f = new buy(sbyt);
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("БИЛЕТОВ НЕТ, Т.К. СОБЫТИЕ УЖЕ ЗАКОНЧИЛОСЬ");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rewievs f = new rewievs(sbyt);
            f.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ploshka f = new ploshka(plosh);
            Program.panel1.Controls.Clear();
            Program.panel1.Controls.Add(f);
        }
    }
}
