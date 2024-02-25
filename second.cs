using System;
using System.Windows.Forms;

namespace hw2
{
    public partial class second : Form
    {
        private int startTime=0;
        private int remainingSeconds; 
        private Timer timer1; 

        public second()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += timer1_Tick; 
            button2.Enabled = false;
        }
        private void startX()
        {
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            numericUpDown2.Enabled = false;
        }
        private void stopX()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            numericUpDown2.Value = startTime;
            numericUpDown2.Enabled = true;
            timer1.Stop();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            remainingSeconds = (int)numericUpDown2.Value;
            startTime = (int)numericUpDown2.Value;
            timer1.Interval = 1000;
            startX();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            stopX();
            int elapsedMinutes = (int)((startTime  - remainingSeconds) / 60);
            int elapsedSeconds = (int)(((int)startTime - remainingSeconds) % 60);
            MessageBox.Show($"Прошло {elapsedMinutes} минут и {elapsedSeconds} секунд.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            numericUpDown2.DownButton();

            if (remainingSeconds <= 0)
            {
                stopX();
                MessageBox.Show("Время истекло!");
            }
        }
    }
}
