﻿using System;
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
    public partial class browseOtzv : Form
    {
        public browseOtzv()
        {
            InitializeComponent();
            List<string> rews = Program.Select("SELECT `ivent`, `otzv` FROM `tipacomments` WHERE user ='" + Program.user + "'");
            for (int i = 0; i < rews.Count; i = i + 2)
            {
                string[] row = new string[2];
                row[0] = rews[i];
                row[1] = rews[i + 1];
                dataGridView1.Rows.Add(row);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.Insert("DELETE FROM tipacomments WHERE user ='" + Program.user + "' AND ivent ='" + delete + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ivent = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string otzv = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (e.ColumnIndex == 1)
            {
                Program.Select("UPDATE tipacomments SET otzv ='" + otzv + "' WHERE user ='" + Program.user + "' AND ivent ='" + ivent + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }
    }
}
