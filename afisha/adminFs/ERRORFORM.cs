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
            string adres = System.IO.Path.GetTempPath() + "AFSH.txt";
            textBox1.Text = System.IO.File.ReadAllText(adres);
            textBox1.ForeColor = Color.Khaki;
        }
    }
}
