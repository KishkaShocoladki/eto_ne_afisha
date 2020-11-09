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
    public partial class user : Form
    {
        public user()
        {
            Text = "ПРОФИЛЬ " + Program.user;
            InitializeComponent();
            label1.Text = Program.user;
            if (Program.user == "admin")
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
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
            List<string> otzv = Program.Select("SELECT ivent FROM bron WHERE user ='" + Program.user + "'");
            if (otzv.Count <= 0)
            {
                MessageBox.Show("ВЫ ЕЩЕ НИЧЕГО НЕ ЗАБРОНИРОВАЛИ	┐(︶▽︶)┌");
            }
            else
            {
                browseBron f = new browseBron();
                f.Show();
            }
        }
    }
}
