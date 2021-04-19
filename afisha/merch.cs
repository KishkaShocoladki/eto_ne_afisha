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
    public partial class merch : UserControl
    {
        string band;
        public merch(string band1)
        {
            band = band1;
            InitializeComponent();
            main.fname = band1;
            try
            {
                pictureBox1.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + band1 + "'"); ;
            }
            catch (Exception) { }
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            panel5.Controls.Clear();
            string type = e.TabPage.Text.ToString();
            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type ='" + type + "' AND band ='" + band + "'");
            int x = 5;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                List<string> price = Program.Select("SELECT price FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(150, 100);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                picB.Click += new EventHandler(BUTT_Click);

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 100);
                lbl.Size = new Size(150, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                // lbl.Click += new EventHandler();

                Label labl = new Label();
                labl.Location = new Point(x, y + 140);
                labl.Size = new Size(155, 55);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;
                
                x = x + 160;
                if (x + 160 > panel5.Width)
                {
                    x = 15;
                    y = y + 190;
                }
                    panel5.Controls.Add(picB);
                    panel5.Controls.Add(lbl);
                    panel5.Controls.Add(labl);
            }
        }
        private void BUTT_Click(object sender, EventArgs e)
        {
            //добавление в корзину, открывающуюся в профиле
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
