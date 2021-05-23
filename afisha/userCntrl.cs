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
        private void button3_Click(object sender, EventArgs e)
        {
            change f = new change();
            f.Show();
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            ERRORFORM f = new ERRORFORM();
            f.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            designTupoy f = new designTupoy();
            f.ShowDialog();

            designTupoy.ApplyDesign(this);
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            trash f = new trash();
            f.Show();
        }
    }
}
