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
    public partial class allBrons : UserControl
    {
        public allBrons()
        {
            InitializeComponent();
            List<string> fillBox = Program.Select("SELECT DISTINCT ivent FROM bron");
            comboBox1.DataSource = fillBox;
            List<string> rews = Program.Select("SELECT `user`, `ivent`, `place` FROM bron");
            for (int i = 0; i < rews.Count; i = i + 3)
            {
                string[] row = new string[3];
                row[0] = rews[i];
                row[1] = rews[i + 1];
                row[2] = rews[i + 2];
                dataGridView1.Rows.Add(row);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string delet = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.Insert("DELETE FROM bron WHERE place ='" + delete + "' AND user ='" + delet + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string com = "SELECT `user`, `ivent`, `place` FROM bron WHERE 1";
            if (comboBox1.Text != "")
                com += " AND ivent = '" + comboBox1.Text + "'";
            List<string> rews = Program.Select(com);
            for (int i = 0; i < rews.Count; i = i + 3)
            {
                string[] row = new string[3];
                row[0] = rews[i];
                row[1] = rews[i + 1];
                row[2] = rews[i + 2];
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
