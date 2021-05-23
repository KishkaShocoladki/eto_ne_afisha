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
    public partial class notreg : Form
    {
        string name;
        public notreg(string nm)
        {
            name = nm;
            InitializeComponent();
            if (name == "ВОЙТИ")
            {
               Text = "НЕПРАВИЛЬНЫЙ ЛОГИН ИЛИ ПАРОЛЬ";
            }
            else if (name == "ЗАРЕГИСТРИРОВАТЬСЯ")
            {
                Text = "ПОЛЬЗОВАТЕЛЬ С ТАКИМИ ЛОГИНОМ И ПАРОЛЕМ УЖЕ СУЩЕСТВУЕТ";
            }
        }
    }
}
