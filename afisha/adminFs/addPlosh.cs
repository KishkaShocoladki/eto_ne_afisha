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
    public partial class addPlosh : Form
    {
        public addPlosh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int ivents = Convert.ToInt32(Program.Select("SELECT COUNT(name) FROM ploshki WHERE name ='" + textBox1.Text + "' AND description ='" + textBox2.Text + "' AND city='" + textBox3.Text + "'AND vmest='" + Convert.ToInt32(textBox4.Text) + "'")[0]);
            if (ivents == 0)
            {
                Program.Insert("INSERT INTO `ploshki` (name, description, city, vmest)" +
                           "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + Convert.ToInt32(textBox4.Text) + "')");
                MessageBox.Show("СОХРАНЕНО");
            }
            else if (ivents != 0)
            {
                MessageBox.Show("ТАКОЕ СОБЫТИЕ УЖЕ СУЩЕСТВУЕТ");
            }
        }

        private void addPlosh_Load(object sender, EventArgs e)
        {

        }
    }
}
