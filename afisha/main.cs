using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AfishA
{
    public partial class main : Form
    {
        public static List<Ivent> sobytia = new List<Ivent>();
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.color = designTupoy.colour;
            Properties.Settings.Default.Save();
        }
        public main()
        {
            InitializeComponent();

            designTupoy.colour = Properties.Settings.Default.color;
            designTupoy.ApplyDesign(this);
            treeView1.BackColor = Properties.Settings.Default.color;
            foreach (Control ctrl in panel1.Controls)
                designTupoy.ApplyDesign(ctrl);


            Program.panel1 = panel1;

            List<string> prt = Program.Select("SELECT name FROM `participants`");
            for (int i = 0; i < prt.Count; i = i + 1)
            {
                TreeNode tt = new TreeNode(prt[i]);
                treeView1.Nodes[1].Nodes.Add(tt);
            }
            List<string> plk = Program.Select("SELECT name FROM `ploshki`");
            for (int i = 0; i < plk.Count; i = i + 1)
            {
                TreeNode tt = new TreeNode(plk[i]);
                treeView1.Nodes[2].Nodes.Add(tt);
            }
            mainCntrl f = new mainCntrl(panel1);
            panel1.Controls.Clear();
            panel1.Controls.Add(f);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button lbl = (Button)sender;
            reg f = new reg(lbl.Text);
            f.ShowDialog();
            if (Program.user != "_")
            {
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = true;
                button9.Visible = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Button lbl = (Button)sender;
            reg f = new reg(lbl.Text);
            f.ShowDialog();
            if (Program.user != "_")
            {
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = true;
                button9.Visible = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = false;
            button9.Visible = false;

            Program.user = "_";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Program.user != "_")
            {
                user f = new user();
                if(Program.user != "admin")
                {
                    f.Width = 596;
                }
                f.ShowDialog();

                designTupoy.ApplyDesign(this);
                treeView1.BackColor = Properties.Settings.Default.color;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl f = new UserControl();
            if (e.Node.Text == "исполнители")
            {
                f = new parts();
                panel1.Controls.Clear();
                panel1.Controls.Add(f);
            }
            if (e.Node.Text == "главная")
            {
                f = new mainCntrl(panel1);
                panel1.Controls.Clear();
                panel1.Controls.Add(f);
            }
            else if (e.Node.Text == "площадки")
            {
                f = new plashadka();
                panel1.Controls.Clear();
                panel1.Controls.Add(f);
            }
            else if (e.Node.Level == 1 && e.Node.Parent.Text == "исполнители")
            {
                f = new participants(e.Node.Text);
                panel1.Controls.Clear();
                panel1.Controls.Add(f);
            }
            else if (e.Node.Level == 1 && e.Node.Parent.Text == "площадки")
            {
                f = new ploshka(e.Node.Text);
                panel1.Controls.Clear();
                panel1.Controls.Add(f);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.navigation_pos--;
            UserControl rf = Program.navigation[Program.navigation_pos];
            panel1.Controls.Clear();
            panel1.Controls.Add(rf);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.navigation_pos++;
            UserControl rf = Program.navigation[Program.navigation_pos];
            panel1.Controls.Clear();
            panel1.Controls.Add(rf);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = (Program.navigation_pos > 1);
            pictureBox2.Visible = (Program.navigation_pos < Program.navigation.Count - 1);
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            designTupoy f = new designTupoy();
            f.ShowDialog();

            designTupoy.ApplyDesign(panel1);
            designTupoy.ApplyDesign(panel2);
        }

        /* private void toolStripMenuItem1_Click(object sender, EventArgs e)
{
    designTupoy f = new designTupoy();
    f.ShowDialog();

    BackColor = f.colour;
    Font = f.font;
}*/
    }
}


