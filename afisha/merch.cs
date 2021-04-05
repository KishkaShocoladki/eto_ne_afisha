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
            main.fname = "";

            List<string> parts = Program.Select("SELECT name FROM `merch` WHERE type =" + tabPage1.Text + " AND band =" + band + "");
            int x = 10;
            int y = 5;
            for (int i = 0; i < parts.Count; i = i + 1)
            {
                List<string> description = Program.Select("SELECT description FROM merch WHERE name ='" + parts[i] + "'");
                PictureBox picB = new PictureBox();
                picB.Location = new Point(x, y);
                picB.Size = new Size(170, 120);
                try
                {
                    picB.Image = Program.SelectImage("SELECT picture FROM merch WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                picB.Click += new EventHandler(BUTT_Click);

                Label lbl = new Label();
                lbl.Location = new Point(x, y + 120);
                lbl.Size = new Size(170, 40);
                lbl.Text = parts[i];
                lbl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                lbl.ForeColor = SystemColors.ButtonFace;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
               // lbl.Click += new EventHandler();

                Label labl = new Label();
                labl.Location = new Point(x, y + 160);
                labl.Size = new Size(170, 40);
                labl.Text = description[0];
                labl.Font = new Font("Lucida Console", 14F, FontStyle.Regular, GraphicsUnit.Point, (204));
                labl.ForeColor = SystemColors.ControlDark;
                labl.TextAlign = ContentAlignment.MiddleCenter;
                x = x + 190;
                if (x + 190 > panel1.Width)
                {
                    x = 10;
                    y = y + 185;
                }
                panel1.Controls.Add(picB);
                panel1.Controls.Add(lbl);
                panel1.Controls.Add(labl);
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
    }
}
