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
    public partial class allParts : Form
    {
        public allParts()
        {
            InitializeComponent();
            List<string> ivs = Program.Select("SELECT `ident`, `name`, `descript`, `genre`, `country` FROM `participants`");
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

        private void allParts_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string delete1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.Insert("DELETE FROM participants WHERE name ='" + delete + "' AND ident  ='" + delete1 + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string part = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string ident = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string descript = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string genre = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string country = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE participants SET name ='" + part + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 2)
            {
                Program.Select("UPDATE participants SET descript ='" + descript + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 3)
            {
                Program.Select("UPDATE participants SET genre ='" + genre + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 4)
            {
                Program.Select("UPDATE participants SET country ='" + country + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }
    }
}
