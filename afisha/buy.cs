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
    public partial class buy : Form
    {
        string ivt;
        public buy(string ivent)
        {
            ivt = ivent;
            InitializeComponent();
            List<string> dt = Program.Select("SELECT dt FROM ivents WHERE name = '" + ivent + "'");
            for (int i = 0; i < dt.Count; i++)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add(dt[i]);                
            }
            string area = Program.Select("SELECT area FROM ivents WHERE name ='" + ivent + "'")[0];
            int vmest = Convert.ToInt32(Program.Select("SELECT vmest FROM ploshki WHERE name ='" + area + "'")[0]);

            int x = 300;
            int y = 50;
            for (int i = 1; i <= vmest; i++)
            {
                Button btn = new Button();
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(50, 30);
                btn.Text = i.ToString();

                List<string> bron = Program.Select("SELECT ivent FROM bron WHERE ivent ='" + ivent + "' AND place =" + btn.Text);
                btn.Enabled = (bron.Count == 0);
                btn.Click += new EventHandler(bronirovanie);
                Controls.Add(btn);

                x = x + 60;
                if(x > 600)
                {
                    x = 300;
                    y = y + 40;
                }
            }
        }
        private void bronirovanie(object sender, EventArgs e)
        {
            string plosh = Program.Select("SELECT area FROM ivents WHERE name ='" + ivt + "'")[0];
            Button btn = (Button)sender;
            Program.Insert("INSERT INTO bron(ivent, ploshk, user, place) VALUES('" + ivt + "', '" + plosh  + "', '" + Program.user + "', '" + btn.Text + "')");
            btn.Enabled = false;
            MessageBox.Show("Вы забронировали место, поздравляю");
        }
    }
}
