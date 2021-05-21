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
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        { 
                UserControl f = new UserControl();
                if (e.Node.Text == "профиль")
                {
                    f = new userCntrl();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                if (e.Node.Text == "пользователи")
                {
                     f = new allUsers();
                     panel11.Controls.Clear();
                     panel11.Controls.Add(f);
                }
                if (e.Node.Text == "мерч")
                {
                  f = new allMerch();
                  panel11.Controls.Clear();
                  panel11.Controls.Add(f);
                }
                if (e.Node.Text == "отзывы")
                {
                    f = new allOtzvs();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                else if (e.Node.Text == "брон. мероприятия")
                {
                    f = new allBrons();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                else if (e.Node.Text == "мероприятия")
                {
                    f = new allIvents();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                else if (e.Node.Text == "участники")
                {
                    f = new allParts();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                else if (e.Node.Text == "площадки")
                {
                    f = new allPloshks();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
                else if (e.Node.Text == "добавление")
                {
                    f = new adding();
                    panel11.Controls.Clear();
                    panel11.Controls.Add(f);
                }
        }

        private void user_Load(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

