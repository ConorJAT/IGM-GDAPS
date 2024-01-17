using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUIAdvDemo
{
    public partial class Form1 : Form
    {
        int counter;

        public Form1()
        {
            counter = 0;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            counter++;
            textCounter.Text = counter.ToString();
            progressCounter.Increment(1);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            counter--;
            textCounter.Text = counter.ToString();
            progressCounter.Increment(-1);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            counter = 0;
            textCounter.Text = counter.ToString();
            progressCounter.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display inital data:
            counter = 0;
            textCounter.Text = counter.ToString();
            progressCounter.Value = 0;

            // Start the timer so it generates Tick events:
            timerCounter.Start();
        }

        private void timerCounter_Tick(object sender, EventArgs e)
        {
            counter++;
            textCounter.Text = counter.ToString();
            progressCounter.Increment(1);
        }
    }
}
