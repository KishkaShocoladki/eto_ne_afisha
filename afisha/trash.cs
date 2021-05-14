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
    public partial class trash : Form
    {
        public trash()
        {
            InitializeComponent();
            List<string> parts = Program.Select("SELECT name FROM `merch` JOIN trash ON merch.id = id_merch WHERE id_user ='" + Program.userid + "'");
            int prise = 0;
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                prise = prise + Convert.ToInt32(price[0]);
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                // picB.Click += new EventHandler(BUTT_Click);


                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = Color.Maroon;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new EventHandler(BUTT_Click);
               

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;

                x = x + 160;
                if (x + 160 > panel1.Width)
                {
                    x = 15;
                    y = y + 230;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
            }
            label2.Text = Convert.ToString(prise) + " руб.";
        }

        private void BUTT_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            string id = Program.Select("SELECT id FROM `merch` WHERE name ='" + lbl.Text + "'")[0];
            // Program.Insert("DELETE FROM trash WHERE id_user ='" + Program.userid + "' AND id_merch  ='" + id + "'");
            DialogResult result = MessageBox.Show("УДАЛИТЬ " + lbl.Text + "?", "точно?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Program.Insert("DELETE FROM trash WHERE id_user ='" + Program.userid + "' AND id_merch  ='" + id + "'");
                MessageBox.Show("товар " + lbl.Text + " удален из корзины");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            no f = new no();
            f.ShowDialog();
        }
    }
}