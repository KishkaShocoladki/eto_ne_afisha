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
    public partial class browseBron : Form
    {
        public browseBron()
        {
            InitializeComponent();
            List<string> bron = Program.Select("SELECT `ivent`, `place` FROM `bron` WHERE user ='" + Program.user + "'");
            for (int i = 0; i < bron.Count; i = i + 2)
            {
                string[] row = new string[2];
                row[0] = bron[i];
                row[1] = bron[i + 1];
                dataGridView1.Rows.Add(row);
            }
            
        }

        private void browseBron_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string delete = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Program.Insert("DELETE FROM bron WHERE place ='" + delete + "'");
                MessageBox.Show("УДАЛЕНО");
            }
        }
    }
}
