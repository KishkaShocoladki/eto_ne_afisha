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
    public partial class ploshka : UserControl
    {
        string ploshk;
        public ploshka(string plosh)
        {
            ploshk = plosh;
            InitializeComponent();
            if (Program.navigation.Count > Program.navigation_pos)
                Program.navigation.RemoveRange(Program.navigation_pos + 1, Program.navigation.Count - Program.navigation_pos - 1);
            Program.navigation.Add(this);
            Program.navigation_pos++;
            List<string> parts = Program.Select("SELECT name FROM ivents WHERE area= '" + ploshk + "'");
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
            try
            {
                Text = "Информация о " + ploshk;
                label1.Text = ploshk;
                string pl_city = Program.Select("SELECT city FROM ploshki WHERE name = '" + ploshk + "'")[0];
                string pl_vmest = Program.Select("SELECT vmest FROM ploshki WHERE name = '" + ploshk + "'")[0];
                string pl_descr = Program.Select("SELECT description FROM ploshki WHERE name = '" + ploshk + "'")[0];
                label2.Text = pl_city;
                label4.Text = "Вместимость: " + pl_vmest;
                textBox1.Text = pl_descr;
                
                pictureBox2.Image = Program.SelectImage("SELECT kartinka1 FROM ploshki WHERE name = '" + ploshk + "'");
            }
            catch (Exception) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            string type = Program.Select("SELECT type FROM ivents WHERE name = '" + lbl.Text + "'")[0];
           // MessageBox.Show(type);
            if (type == "ФЕСТИВАЛЬ")
            {
                sobytie f = new sobytie(lbl.Text);
                f.Show();
            }
            else if (type == "СОЛО КОНЦЕРТ") 
            {
                solo f = new solo(lbl.Text);
                f.Show();
            }
        }

        private void ploshka_Load(object sender, EventArgs e)
        {

        }
    }
}