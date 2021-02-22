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
    public partial class userCntrl : UserControl
    {
        public userCntrl()
        {
            InitializeComponent();
            label1.Text = Program.user;
            if (Program.user == "admin")
            {
                button.Visible = true;
                button1.Visible = true;
            }
            try
            {
                pictureBox1.Image = Program.SelectImage("SELECT pict FROM users WHERE login = '" + Program.user + "'");
            }
            catch (Exception) { }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> bron = Program.Select("SELECT ivent FROM bron WHERE user ='" + Program.user + "'");
            if (bron.Count <= 0)
            {
                MessageBox.Show("ВЫ ЕЩЕ НИЧЕГО НЕ ЗАБРОНИРОВАЛИ	┐(︶▽︶)┌");
            }
            else
            {
                browseBron f = new browseBron();
                f.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> otzv = Program.Select("SELECT otzv FROM tipacomments WHERE user ='" + Program.user + "'");
            if (otzv.Count <= 0)
            {
                MessageBox.Show("ВЫ ЕЩЕ НЕ ОСТАВИЛИ НИ ОДНОГО ОТЗЫВА ┐(︶▽︶)┌");
            }
            else
            {
                browseOtzv f = new browseOtzv();
                f.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            allParts f = new allParts();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            allPloshks f = new allPloshks();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            allIvents f = new allIvents();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            allBrons f = new allBrons();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            allUsers f = new allUsers();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            allOtzvs f = new allOtzvs();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change f = new change();
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            adding f = new adding();
            f.Show();
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            ERRORFORM f = new ERRORFORM();
            f.Show();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            designTupoy f = new designTupoy();
            f.ShowDialog();

            designTupoy.ApplyDesign(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
