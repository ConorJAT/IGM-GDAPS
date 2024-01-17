// Demo of message boxes

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFormDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Instantiate this form ONCE:
        }

        private void buttonPopUp_Click(object sender, EventArgs e)
        {
            // Display a message to the user:
            DialogResult result = MessageBox.Show(
                "This is the message text",
                "This is a caption",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);

            // Let's see the result:
            MessageBox.Show("You clicked:" + result);
        }

        /*private void buttonOpen_Click(object sender, EventArgs e)
        {
            // First, show the file picker to the user:
            DialogResult result = openFileDialog1.ShowDialog();

            // Determine if the user actually chose a file:
            if (result == DialogResult.OK)
            {
                MessageBox.Show("You chose: " + openFileDialog1.FileName);
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("You did not select a file.");
            }
            {

            }
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a new object of our custom form class:
            Form2 form2 = new Form2();

            // Need to show form:
            form2.ShowDialog();
        }
    }
}
