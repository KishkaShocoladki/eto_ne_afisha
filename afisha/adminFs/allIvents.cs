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
    public partial class allIvents : UserControl
    {
        public allIvents()
        {
            InitializeComponent();
            List<string> fillBox = Program.Select("SELECT DISTINCT country FROM ivents");
            comboBox1.DataSource = fillBox;
            List<string> fillBox2 = Program.Select("SELECT DISTINCT type FROM ivents");
            comboBox2.DataSource = fillBox2;
            List<string> ivs = Program.Select("SELECT `ident`, `name`, `descript`, `city`, `country`, `type`, `pay`, `area`, `dt` FROM `ivents`"); //ТУТ ДОЛЖНА БЫТЬ ЕЩЕ ДАТА
            for (int i = 0; i < ivs.Count; i = i + 9)
            {
                string[] row = new string[9];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                row[5] = ivs[i + 5];
                row[6] = ivs[i + 6];
                row[7] = ivs[i + 7];
                row[8] = ivs[i + 8];
                dataGridView1.Rows.Add(row);
            }
        }

        private void allIvents_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string delete1 = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                string delete2 = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                Program.Insert("DELETE FROM ivents WHERE name ='" + delete + "' AND area ='" + delete1 + "' AND dt = '" + delete2 + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ident = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string ivent = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string descript = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string city = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string country = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string type = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string pay = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string area = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            string dt = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE ivents SET name ='" + ivent + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 2)
            {
                Program.Select("UPDATE ivents SET descript ='" + descript + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 3)
            {
                Program.Select("UPDATE ivents SET city ='" + city + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 4)
            {
                Program.Select("UPDATE ivents SET country ='" + country + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 5)
            {
                Program.Select("UPDATE ivents SET type ='" + type + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 6)
            {
                Program.Select("UPDATE ivents SET pay ='" + pay + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 7)
            {
                Program.Select("UPDATE ivents SET area ='" + area + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 8)
            {
                Program.Select("UPDATE ivents SET dt ='" + dt + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string com = "SELECT `ident`, `name`, `descript`, `city`, `country`, `type`, `pay`, `area`, `dt` FROM `ivents` WHERE 1";

            if (comboBox1.Text != "")
                com += " AND country = '" + comboBox1.Text + "'";
            
            if (comboBox2.Text != "")
                com += " AND type = '" + comboBox2.Text + "'";
            
            List<string> ivs = Program.Select(com);
            for (int i = 0; i < ivs.Count; i = i + 9)
            {
                string[] row = new string[9];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                row[5] = ivs[i + 5];
                row[6] = ivs[i + 6];
                row[7] = ivs[i + 7];
                row[8] = ivs[i + 8];
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
