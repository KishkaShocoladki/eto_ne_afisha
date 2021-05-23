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
    public partial class allOtzvs : UserControl
    {
        public allOtzvs()
        {
            InitializeComponent();
            List<string> fillBox = Program.Select("SELECT DISTINCT ivent FROM tipacomments");
            comboBox1.DataSource = fillBox;
            List<string> ivs = Program.Select("SELECT  `ident`, `user`, `otzv`, `ivent` FROM `tipacomments`");
            for (int i = 0; i < ivs.Count; i = i + 4)
            {
                string[] row = new string[4];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                dataGridView1.Rows.Add(row);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();//ТУТ ДОЛЖЕН БЫТЬ ID А НЕ ПОЛЬЗОВАТЕЛЬ
                string delete1 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string delete2 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                Program.Insert("DELETE FROM tipacomments WHERE user ='" + delete + "' AND otzv ='" + delete1 + "' AND ivent ='" + delete2 + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<string> ivs = Program.Select("SELECT  `ident`, `user`, `otzv`, `ivent` FROM `tipacomments` WHERE ivent='" + comboBox1.Text + "'");
            for (int i = 0; i < ivs.Count; i = i + 4)
            {
                string[] row = new string[4];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
