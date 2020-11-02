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
    public partial class participants : Form
    {
        string name;
        public participants(string nm)
        {
            name = nm;
            InitializeComponent();
            Text = "Информация о " + name;
            label1.Text = name;

            List<string> info = Program.Select("SELECT name, descript, genre FROM participants WHERE name = '" + name + "'");
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Font = new Font("Lucida Console", 20F, FontStyle.Regular, GraphicsUnit.Point, (204));

            textBox1.Text = info[1];
            label2.Text = info[2];
            label2.Font = new Font("Lucida Console", 13F, FontStyle.Regular, GraphicsUnit.Point, (204));
            try
            {          
                pictureBox1.Image = Program.SelectImage("SELECT kartinochka FROM participants WHERE name = '" + name + "'");
            }
            catch (Exception) { }
            List<string> parts = Program.Select("SELECT ivent FROM `tipasvyaznaverno` WHERE part='" + name + "'");

            for (int i = 0; i < parts.Count; i = i + 1)
            {
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = parts[i];
                lbl.Size = new Size(120, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 120 + 130 * i);
                //lbl.Click += new EventHandler(button2_Click);
                panel1.Controls.Add(lbl);

                PictureBox picB = new PictureBox();
                picB.Location = new Point(10, 5 + 130 * i);
                picB.Size = new Size(120, 120);
                picB.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    picB.Image = Program.SelectImage("SELECT pic1 FROM ivents WHERE name = '" + parts[i] + "'");
                }
                catch (Exception) { }
                panel1.Controls.Add(picB);
            }
        }

        private void participants_Load(object sender, EventArgs e)
        {

        }
    }
}

