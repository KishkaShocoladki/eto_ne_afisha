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
    public partial class addSob : Form
    {
        public addSob()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                int ivents = Convert.ToInt32(Program.Select("SELECT COUNT(name) FROM ivents WHERE name ='" + textBox1.Text + "' AND descript ='" + textBox2.Text + "' AND city='" + textBox4.Text + "'AND country='" + textBox5.Text + "'AND type='" + textBox6.Text + "'AND area='" + textBox7.Text + "'")[0]);
                if (ivents == 0)
                {
                    Program.Insert("INSERT INTO `ivents` (name, descript, city, country, type, area, pay)" +
                             "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + Convert.ToInt32(textBox8.Text) + "')");
                    MessageBox.Show("СОХРАНЕНО");
                }
                else if (ivents != 0)
                {
                    MessageBox.Show("ТАКОЕ СОБЫТИЕ УЖЕ СУЩЕСТВУЕТ!!!111!!1!11");
                }
            }
            else
                MessageBox.Show("ЗАПОЛНИТЕ ВСЕ ПОЛЯ!1111!!!");
        }
    }
}
