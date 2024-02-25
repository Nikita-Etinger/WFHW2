using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            First frm = new First();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            second frm = new second(); 
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            third frm = new third(); 
            frm.ShowDialog();
        }

    }
}
