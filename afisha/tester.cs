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

                HtmlWeb webGet = new HtmlWeb();
                webGet.AutoDetectEncoding = false;
                webGet.OverrideEncoding = Encoding.GetEncoding("utf-8");
                HtmlAgilityPack.HtmlDocument doc = webGet.Load("https://www.last.fm/ru/music/" + textBox2.Text + "/+wiki");
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
                str = str.Replace("&#x27;", "'");
                str = str.Replace("&amp", "&");
                str = str.Replace("<em>", "");
                str = str.Replace("</em>", "");
                str = str.Replace("</a>", "");
                str = str.Replace("</p>", "");
                str = str.Replace("<br>", Environment.NewLine);
                textBox3.Text = str;
            }
            else MessageBox.Show("mem");

        }

        private void tester_Load(object sender, EventArgs e)
        {

        }
    }
}
