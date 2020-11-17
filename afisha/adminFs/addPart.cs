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
    public partial class addPart : Form
    {
        public addPart()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (genreBox2.Text != "" && genreBox3.Text != "")
            {
                Program.Insert("INSERT INTO `participants` (name, descript, genre, mVmest, tipgonorar, neGo)" +
                               "VALUES ('" + nameBox.Text + "', '" + descriptBox.Text + "', '" + genreBox1.Text + ", " + genreBox2.Text + ", " + genreBox3.Text + "', '" + Convert.ToInt32(vmestBox.Text) + "', '" + Convert.ToInt32(payBox.Text) + "', '" + negoBox.Text + "')");
                int genre = Convert.ToInt32(Program.Select("SELECT COUNT(genre) FROM genres WHERE genre ='" + genreBox1.Text + "' OR genre ='" + genreBox2.Text + "'OR genre ='" + genreBox2.Text + "'")[0]);
                int genre2 = Convert.ToInt32(Program.Select("SELECT COUNT(genre) FROM genres WHERE genre ='" + genreBox2.Text + "'")[0]);
                int genre3 = Convert.ToInt32(Program.Select("SELECT COUNT(genre) FROM genres WHERE genre ='" + genreBox3.Text + "'")[0]);
                if (genre == 0)
                {
                    Program.Insert("INSERT INTO `genres` (genre)" +
                                   "VALUES ('" + genreBox1.Text + "')");
                }
                else if(genre2 == 0)
                {
                    Program.Insert("INSERT INTO `genres` (genre)" +
                                   "VALUES ('" + genreBox2.Text + "')");
                }
                else if (genre3 == 0)
                {
                    Program.Insert("INSERT INTO `genres` (genre)" +
                                   "VALUES ('" + genreBox3.Text + "')");
                }
                MessageBox.Show("СОХРАНЕНО");
            }
            else if (genreBox3.Text == "")
            {
                Program.Insert("INSERT INTO `participants` (name, descript, genre, mVmest, tipgonorar, neGo)" +
                               "VALUES ('" + nameBox.Text + "', '" + descriptBox.Text + "', '" + genreBox1.Text + ", " + genreBox2.Text + "', '" + Convert.ToInt32(vmestBox.Text) + "', '" + Convert.ToInt32(payBox.Text) + "', '" + negoBox.Text + "')");
                int genre = Convert.ToInt32(Program.Select("SELECT COUNT(genre) FROM genres WHERE genre ='" + genreBox1.Text + "'")[0]);
                int genre2 = Convert.ToInt32(Program.Select("SELECT COUNT(genre) FROM genres WHERE genre ='" + genreBox2.Text + "'")[0]);
                if (genre == 0)
                {
                    Program.Insert("INSERT INTO `genres` (genre)" +
                                   "VALUES ('" + genreBox1.Text + "')");
                }
                else if (genre2 == 0)
                {
                    Program.Insert("INSERT INTO `genres` (genre)" +
                                   "VALUES ('" + genreBox2.Text + "')");
                }
                MessageBox.Show("СОХРАНЕНО");
            }
        }

        private void addPart_Load(object sender, EventArgs e)
        {

        }
    }
}
