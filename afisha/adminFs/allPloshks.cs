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
    public partial class allPloshks : Form
    {
        public allPloshks()
        {
            InitializeComponent();
            List<string> fillBox = Program.Select("SELECT DISTINCT city FROM ploshki");
            comboBox1.DataSource = fillBox;
            List<string> ivs = Program.Select("SELECT `ident`, `name`, `city`, `description`, `vmest` FROM `ploshki`");
            for (int i = 0; i < ivs.Count; i = i + 5)
            {
                string[] row = new string[5];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.Insert("DELETE FROM ploshki WHERE ident ='" + delete + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }

        private void allPloshks_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ident = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string ploshk = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string descript = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string city = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string vmest = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE ivents SET name ='" + ploshk + "' WHERE ident ='" + ident + "'");
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
                Program.Select("UPDATE ivents SET vmest ='" + vmest + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ivs = Program.Select("SELECT `ident`, `name`, `city`, `description`, `vmest` FROM `ploshki` WHERE city='" + comboBox1.Text + "'");
            for (int i = 0; i < ivs.Count; i = i + 5)
            {
                string[] row = new string[5];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
