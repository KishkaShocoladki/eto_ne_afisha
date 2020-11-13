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
    public partial class allIvents : Form
    {
        public allIvents()
        {
            InitializeComponent();
            List<string> ivs = Program.Select("SELECT `name`, `area` FROM `ivents`"); //ТУТ ДОЛЖНА БЫТЬ ЕЩЕ ДАТА
            for (int i = 0; i < ivs.Count; i = i + 2)
            {
                string[] row = new string[2];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
               // row[1] = ivs[i + 2];
                dataGridView1.Rows.Add(row);
            }
        }

        private void allIvents_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string delete1 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                // string delete2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Program.Insert("DELETE FROM ivents WHERE name ='" + delete + "' AND area ='" + delete1 + "'"); //AND dt = '" + delete2 +"'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ivent = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string area = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                Program.Select("UPDATE ivents SET name ='" + ivent + "' WHERE area ='" + area + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE ivents SET area ='" + area + "' WHERE name ='" + ivent + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }
    }
}
