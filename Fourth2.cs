using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw2
{
    public partial class Fourth2 : Form
    {
        public Good x;


        public Fourth2(Good tmp)
        {
            InitializeComponent();
            x = tmp;
            if (x.Name != null)
            {
                textBox1.Text = x.Name;
                textBox2.Text = x.Country;
                textBox3.Text = textBox3.Text = x.Price.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены"); return;
            }
            try
            {
                x.Price = float.Parse(textBox3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат числа. Пожалуйста, введите число в правильном формате.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            x.Name = textBox1.Text;
            x.Country = textBox2.Text;

            DialogResult = DialogResult.OK;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

