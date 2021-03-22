using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfishA
{
    public partial class merch : UserControl
    {
        //Я ПЫТАЛСЯ ЧТО ТО СДЕЛАТЬ НО Я ТУПОЙ ПОЭТОМУ КАК ТО НИКАК
        /*public void DrawStringFloatFormat(PaintEventArgs e)
        {
            string hex = "#00FFFF";
            // Create font and brush.
            Font drawFont = new Font("Arial", 30);
            SolidBrush drawBrush = new SolidBrush(ColorTranslator.FromHtml(hex));
            label1.Font = drawFont;
            label1.Font.SolidBrush = drawBrush;
        }*/
            public merch()
            {   //СДЕЛАТЬ КАК НИБУДЬ ТЕКСТ ЛЕЙБЛА ПОЛУПРОЗРАЧНЫМ
                InitializeComponent();
                label1.Parent = pictureBox1;
                label1.BackColor = Color.Transparent;
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
