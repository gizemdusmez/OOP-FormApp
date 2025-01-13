using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektProgram
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Behövde ändra kod i någon konstig fil för att få detta att fungera, se "*"
        private void button1_Click(object sender, EventArgs e)
        {
            int diff = 1;
            //*
            Program.Form.startGame(diff);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int diff = 2;
            //*
            Program.Form.startGame(diff);
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int diff = 3;

            //*
            Program.Form.startGame(diff);
            Close();
        }
    }
}
