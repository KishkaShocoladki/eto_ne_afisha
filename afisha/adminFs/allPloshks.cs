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
            List<string> ivs = Program.Select("SELECT `name`, `city` FROM `ploshki`");
            for (int i = 0; i < ivs.Count; i = i + 2)
            {
                string[] row = new string[2];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string delete1 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Program.Insert("DELETE FROM ploshki WHERE name ='" + delete + "' AND city ='" + delete1 + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }

        private void allPloshks_Load(object sender, EventArgs e)
        {

        }
    }
}
