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
using HtmlAgilityPack;
using System.Data.SqlTypes;

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
            if (textBox2.Text != "")
            {
                textBox3.Text = "";
                textBox3.Clear();
                WebRequest wr = WebRequest.Create("https://www.last.fm/ru/music/" + textBox2.Text + "/+wiki");
                wr.Method = "GET";
                WebResponse resp = wr.GetResponse();

                Stream stream = resp.GetResponseStream();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(stream);

                var Nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wiki-content')]");
                var anchors = Nodes[0].SelectNodes("//a[starts-with(@href, '/')]");
                foreach (var anchor in anchors.ToList())
                    anchor.Remove();

                string str = Nodes[0].InnerHtml;
                str = str.Replace("</p>", "");
                textBox3.Text = str;
                /*byte[] b = Encoding.Default.GetBytes(str);
                byte[] utf8Bytes = System.Text.Encoding.Convert(System.Text.Encoding.Unicode,
                    System.Text.Encoding.UTF8, b);
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                string outputString = encoder.GetString(utf8Bytes);
                textBox3.Text = outputString;*/
                
                resp.Close();
            }
            else MessageBox.Show("mem");

        }

        private void tester_Load(object sender, EventArgs e)
        {

        }
    }
}
