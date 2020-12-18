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
    public partial class ERRORFORM : Form
    {
        public ERRORFORM()
        {
            InitializeComponent();
          //  string address = System.IO.Path.GetTempPath() + "AFSH.txt";
            foreach (var line in System.IO.File.ReadLines(System.IO.Path.GetTempPath() + "AFSH.txt"))
            {
                var array = line.Split(new char[] { ';' });
                dataGridView1.Rows.Add(array);
            }
            //string[] str;
            // dataGridView1.ColumnCount = 3; //например вот здесь

            /* using (System.IO.StreamReader read = new System.IO.StreamReader(System.IO.Path.GetTempPath() + "AFSH.txt"))
            {
                str = read.ReadToEnd().Split(new Char[] { ' ', '\r' });
                int pos = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (str[pos] != "")
                            dataGridView1[j, i].Value = str[pos];
                        pos++;
                    }

                }
            }*/

        }

        private void ERRORFORM_Load(object sender, EventArgs e)
        {

        }
    }
}
