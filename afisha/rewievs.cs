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
    public partial class rewievs : Form
    {
        string name;
        public rewievs(string sobyt)
        {
            name = sobyt;
            InitializeComponent();
            List<string> rews = Program.Select("SELECT login FROM `users` WHERE ivent='" + name + "'");
            
            for (int i = 0; i < rews.Count; i = i + 1)
            {
                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Text = rews[i];
                lbl.Size = new Size(60, 30);
                lbl.AutoSize = false;
                lbl.Location = new Point(10, 30);// * i);

                List<string> texts = Program.Select("SELECT pass FROM `users` WHERE login='" + rews[i] + "'");
                TextBox textB = new TextBox();
                textB.Location = new Point(70, 30);// * i);
                textB.Size = new Size(60, 30);
                textB.Multiline = true;
                textB.BackColor = SystemColors.InactiveCaptionText;
                textB.ForeColor = SystemColors.ButtonFace;
                textB.ScrollBars = ScrollBars.Vertical;
                try
                {
                    textB.Text = texts[i];
                }
                catch (Exception) { }

                Controls.Add(lbl);
                Controls.Add(textB);
            }
        }

        private void rewievs_Load(object sender, EventArgs e)
        {

        }
    }
}
