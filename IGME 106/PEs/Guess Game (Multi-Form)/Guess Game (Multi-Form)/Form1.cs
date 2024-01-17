// Conor Race
// Jan 29th, 2022
// IGME.106.07

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Game__Multi_Form_
{
    public partial class FormParameters : Form
    {
        public FormParameters()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Before starting a game, checks to see if all parameters are usable.
        /// If all parameters are usable, the game starts.
        /// </summary>
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                // Try/Catch intended to test if input are ints:
                int min = int.Parse(textBoxMin.Text);
                int max = int.Parse(textBoxMax.Text);
                int time = int.Parse(textBoxTime.Text);


                // Checks if the min is greater than the max:
                if (min > max)
                {
                    DialogResult result = MessageBox.Show("Min value cannot be greater than max value!", "Input Error",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Checks if the difference of the max and min is less than 10:
                else if (max - min < 10)
                {
                    DialogResult result = MessageBox.Show("Difference between min and max has to be 10 or greater!", "Input Error",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Checks if the time is less than or equal to 0:
                else if (time <= 0)
                {
                    DialogResult result = MessageBox.Show("Unacceptable time interval!", "Input Error",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If all conditions are fulfilled, a FormGame form is created:
                else
                {
                    FormGame gameForm = new FormGame(max, min, time);
                    gameForm.ShowDialog();
                }
            }
            catch
            {
                // Message is presented should the user enter any non-int parameters:
                DialogResult result = MessageBox.Show("Invalid input detected! Please enter int values only!", "Input Error",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
