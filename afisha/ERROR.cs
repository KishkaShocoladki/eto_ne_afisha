﻿using System;
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
    public partial class ERROR : Form
    {
       // string err;
        public ERROR(string error)
        {
            //err = error;
            InitializeComponent();
            Text = error;

        }
        private void ERROR_Load(object sender, EventArgs e)
        {

        }
        private void button_Click(object sender, KeyEventArgs e)
        {
            Close();
        }
    }
}
