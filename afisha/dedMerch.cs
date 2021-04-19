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
    public partial class dedMerch : Form
    {
        public dedMerch()
        {
            InitializeComponent();
           // List<string> dedmerch = Program.Select("SELECT trash.id_merch FROM `trash` WHERE id_user = '" + Program.userid + "' JOIN merch ON trash.id_merch = merch.id");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
