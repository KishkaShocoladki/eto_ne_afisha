using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace AfishA
{
    public partial class tester : Form
    {
        public tester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest wr = WebRequest.Create("https://www.last.fm/music/Survive+Said+The+Prophet/+wiki");
            wr.Method = "GET";
            WebResponse resp = wr.GetResponse();

            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            string[] parts = sReadData.Split(new string[] { "<div class=\"wiki\">", "</div></div>" }, StringSplitOptions.None);
            for (int i = 0; i < parts.Length; i++)
            {
                if(parts[i].Contains("<div class=\"wiki-content\" itemprop=\"description\">"))
                {
                    string str = parts[i + 1];
                    str = str.Replace("<p>", Environment.NewLine);
                    str = str.Replace("</p>", "");
                    textBox3.Text = str;
                }
            }

                //dynamic text = JsonConvert.DeserializeObject(sReadData);
           // textBox1.Text = text.city;
            //textBox3.Text = (1 / Convert.ToDouble(text.rates.USD)).ToString();
            resp.Close();

        }

        private void tester_Load(object sender, EventArgs e)
        {

        }
    }
}
