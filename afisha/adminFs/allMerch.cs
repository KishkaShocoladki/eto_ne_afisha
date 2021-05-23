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
    public partial class allMerch : UserControl
    {
        public allMerch()
        {
            InitializeComponent();
            List<string> fillBox1 = Program.Select("SELECT DISTINCT band FROM merch");
            comboBox1.DataSource = fillBox1;

            List<string> merch = Program.Select("SELECT `name`, `type`, `description`, `tracklist`, `band`, `price`, id FROM merch");
            for (int i = 0; i < merch.Count; i = i + 7)
            {
                string[] row = new string[7];
                row[0] = merch[i];
                row[1] = merch[i + 1];
                row[2] = merch[i + 2];
                row[3] = merch[i + 3];
                row[4] = merch[i + 4];
                row[5] = merch[i + 5];
                row[6] = merch[i + 6];
                dataGridView1.Rows.Add(row);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string com = "SELECT `name`, `type`, `description`, `tracklist`, `band`, `price`, id FROM merch WHERE 1";

            if (comboBox1.Text != "")
                com += " AND band = '" + comboBox1.Text + "'";
            List<string> merch = Program.Select(com);
            for (int i = 0; i < merch.Count; i = i + 7)
            {
                string[] row = new string[7];
                row[0] = merch[i];
                row[1] = merch[i + 1];
                row[2] = merch[i + 2];
                row[3] = merch[i + 3];
                row[4] = merch[i + 4];
                row[5] = merch[i + 5];
                row[6] = merch[i + 6];
                dataGridView1.Rows.Add(row);
            }
        }
        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string type = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string descript = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string tracklist = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string band = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string price = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                Program.Select("UPDATE merch SET name ='" + name + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE merch SET type ='" + type + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 2)
            {
                Program.Select("UPDATE merch SET description ='" + descript + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 3)
            {
                Program.Select("UPDATE merch SET tracklist ='" + tracklist + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 4)
            {
                Program.Select("UPDATE merch SET band ='" + band + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 6)
            {
                Program.Select("UPDATE merch SET price ='" + price + "' WHERE ident ='" + id + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.Insert("DELETE FROM merch WHERE name ='" + delete + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
    }
}
