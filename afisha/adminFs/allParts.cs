using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace AfishA
{
    public partial class allParts : UserControl
    {
        public allParts()
        {
            InitializeComponent();
            List<string> fillBox = Program.Select("SELECT DISTINCT country FROM participants");
            comboBox1.DataSource = fillBox;

            List<string> genres = Program.Select("SELECT genre FROM participants");
            List<string> genress = new List<string>();
            foreach (string genre in genres)
            {
                string[] genre1 = genre.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string gen in genre1)
                {
                    if (!genress.Contains(gen))
                        genress.Add(gen);
                }
            }
            genress.Sort();
            comboBox2.DataSource = genress.ToArray();

            List<string> ivs = Program.Select("SELECT `ident`, `name`, `descript`, `genre`, `country`, `mVmest`, `tipgonorar`, `neGo` FROM `participants`");
            for (int i = 0; i < ivs.Count; i = i + 8)
            {
                string[] row = new string[8];
                row[0] = ivs[i];
                row[1] = ivs[i + 1]; 
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                row[5] = ivs[i + 5];
                row[6] = ivs[i + 6];
                row[7] = ivs[i + 7];
                dataGridView1.Rows.Add(row);
            }
        }

        private void allParts_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
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
            string mVmest = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string tipgonorar = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string neGo = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
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
            if (e.ColumnIndex == 5)
            {
                Program.Select("UPDATE participants SET mVmest ='" + mVmest + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 6)
            {
                Program.Select("UPDATE participants SET tipgonorar ='" + tipgonorar + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
            if (e.ColumnIndex == 7)
            {
                Program.Select("UPDATE participants SET neGo ='" + neGo + "' WHERE ident ='" + ident + "'");
                MessageBox.Show("ОТРЕДАКТИРОВАНО");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string com = "SELECT `ident`, `name`, `descript`, `genre`, `country`, `mVmest`, `tipgonorar`, `neGo` FROM `participants` WHERE 1";

            if (comboBox1.Text != "")
                com += " AND country = '" + comboBox1.Text + "'";
            if (comboBox2.Text != "")
                com += " AND genre LIKE '%" + comboBox2.Text + "%'";
            List<string> ivs = Program.Select(com);
            for (int i = 0; i < ivs.Count; i = i + 8)
            {
                string[] row = new string[8];
                row[0] = ivs[i];
                row[1] = ivs[i + 1];
                row[2] = ivs[i + 2];
                row[3] = ivs[i + 3];
                row[4] = ivs[i + 4];
                row[5] = ivs[i + 5];
                row[6] = ivs[i + 6];
                row[7] = ivs[i + 7];
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> ivs = Program.Select("SELECT `name` FROM `participants`");
            for (int i = 0; i < ivs.Count; i = i + 1)
            {
                string name = ivs[i];
                name = name.Replace(" ", "+");
                HtmlWeb webGet = new HtmlWeb();
                webGet.AutoDetectEncoding = false;
                webGet.OverrideEncoding = Encoding.GetEncoding("utf-8");
                HtmlAgilityPack.HtmlDocument doc = webGet.Load("https://www.last.fm/ru/music/" + name + "/+wiki");
                var Nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wiki-content')]");

                string str = Nodes[0].InnerHtml;
                    var anchors = Nodes[0].SelectNodes("//a[starts-with(@href, '/')]");
                    foreach (var anchor in anchors.ToList())
                    {
                        str = str.Replace(anchor.OuterHtml, anchor.InnerHtml);
                    }
                    str = str.Replace("<p>", Environment.NewLine + Environment.NewLine);
                    str = str.Replace("<strong>", Environment.NewLine);
                    str = str.Replace("</strong>", Environment.NewLine);
                    str = str.Replace("&quot", "''");
                    str = str.Replace("`", "");
                    str = str.Replace("'", "");
                    str = str.Replace("<li>", "");
                    str = str.Replace("</li>", "");
                    str = str.Replace("</ul>", "");
                    str = str.Replace("&#x27;", "'");
                    str = str.Replace("&amp", "&");
                    str = str.Replace("<em>", "");
                    str = str.Replace("</em>", "");
                    str = str.Replace("</a>", "");
                    str = str.Replace("</p>", "");
                    str = str.Replace("<br>", Environment.NewLine);
                Program.Select("UPDATE participants SET descript ='" + str + "' WHERE name ='" + name + "'");
                
            }
            MessageBox.Show("ОПИСАНИЕ ОБНОВЛЕНО");
        }
    }
}
