using System;
using System.Threading;
using System.Windows.Forms;

namespace hw2
{
    public partial class First : Form
    {
        // Границы прямоугольника
        private const int RectangleMargin = 10;
        private bool mouseRightClick = false;
        public First()
        {
            InitializeComponent();
            this.MouseClick += Form_MouseClick;
            this.MouseMove += Form_MouseMove;
        }

        private void First_Load(object sender, EventArgs e)
        {

            
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                 if (Control.ModifierKeys == Keys.Control)
                {
                    Application.Exit(); 
                }

                // Проверяем, находится ли точка внутри прямоугольника
                if (e.X >= RectangleMargin && e.X <= this.ClientRectangle.Width - RectangleMargin &&
                    e.Y >= RectangleMargin && e.Y <= this.ClientRectangle.Height - RectangleMargin)
                {
                    MessageBox.Show("Точка внутри прямоугольника");
                }
                // Проверяем, находится ли точка на границе прямоугольника
                else if (e.X <= RectangleMargin || e.X >= this.ClientRectangle.Width - RectangleMargin ||
                         e.Y <= RectangleMargin || e.Y >= this.ClientRectangle.Height - RectangleMargin)
                {
                    MessageBox.Show("Точка на границе прямоугольника");
                }
                // В противном случае точка снаружи прямоугольника
                else
                {
                    MessageBox.Show("Точка снаружи прямоугольника");
                }


            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseRightClick)
            {
                this.Text = $"Ширина = {this.ClientRectangle.Width}, Высота = {this.ClientRectangle.Height}";
            }
            else

            this.Text = $"X = {e.X}, Y = {e.Y}";
        }

        private void First_MouseUp(object sender, MouseEventArgs e)
        {
            mouseRightClick = false;
        }

        private void First_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mouseRightClick = true;
            }
        }
    }
}