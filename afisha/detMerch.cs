using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfishA
{
    public partial class detMerch : UserControl
    {
        string name;
        public detMerch(string name1)
        {
            name = name1;
            InitializeComponent();
            label1.Text = name;

            List<string> info = Program.Select("SELECT description, price, type FROM `merch` WHERE name ='" + name + "'");
            label2.Text = info[0];
            label3.Text = "ЦЕНА: " + info[1];
            string type = info[2];
            pictureBox1.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + name + "'");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            if (info[2] == "CD" || info[2] == "винил")
            {
                label4.Visible = true;
                panel1.Visible = true;
                label4.Text = "ТРЕКЛИСТ";
                List<string> tracks = Program.Select("SELECT tracklist FROM merch WHERE name = '" + name + "'");
                List<string> trackss = new List<string>();
                foreach (string track in tracks)
                {
                    string[] track1 = track.Split(new string[] { "; " }, StringSplitOptions.None);
                    foreach (string tr in track1)
                    {
                        if (!trackss.Contains(tr))
                            trackss.Add(tr);
                    }
                }
                int x = 5;
                int y = 5;
                for (int i = 0; i < trackss.Count; i = i + 1)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(x, y);
                    lbl.Size = new Size(100, 40);
                    lbl.Text = trackss[i];
                    lbl.Font = new Font("Segoe IU", 9F, FontStyle.Regular, GraphicsUnit.Point, (204));
                    lbl.ForeColor = Color.Khaki;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    x = x + 100;
                    if (x + 100 > 100)
                    {
                        x = 5;
                        y = y + 40;
                    }
                    panel1.Controls.Add(lbl);
                }
            }

        }

        private void detMerch_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = Program.Select("SELECT id FROM `merch` WHERE name ='" + name + "'")[0];
            if (Program.userid != "_")
            {
                Program.Insert("INSERT INTO trash (id_user, id_merch) VALUES ('" + Program.userid + "', '" + id + "')");
                MessageBox.Show("мерч ДОБАВЛЕН");
            }
            else
                MessageBox.Show("ДЛЯ ТОГО ЧТОБЫ ДОБАВИТЬ ТОВАР В КОРЗИНУ ВОЙДИТЕ В АККАУНТ(ﾒ｀ﾛ´)/");
        }
    }
}
