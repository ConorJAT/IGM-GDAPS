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
    public partial class FormGame : Form
    {
        int guessNum;
        int guessCount;
        Random rng = new Random();


        /// <summary>
        /// Constructor; Creates a FormGame form using parameters from the first form.
        /// </summary>
        /// <param name="max"> Max range from which a number is chosen. </param>
        /// <param name="min"> Min range from which a number is chosen. </param>
        /// <param name="time"> Time the user has to guess the number. </param>
        public FormGame(int max, int min, int time)
        {
            InitializeComponent();

            guessNum = rng.Next(min, max + 1);
            progressBarTime.Maximum = 10 * time;
            guessCount = 0;
        }


        /// <summary>
        /// Starts the timer when the form loads.
        /// </summary>
        private void FormGame_Load(object sender, EventArgs e)
        {
            timer.Start();
        }


        /// <summary>
        /// Increments the progress bar by 1. Also keeps track for "time up" losses.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            progressBarTime.Increment(1);

            // Should the user run out of time:
            if (progressBarTime.Value >= progressBarTime.Maximum)
            {
                // Stop the timer:
                timer.Stop();

                // Disable text box and button:
                textBoxGuess.Enabled = false;
                buttonGuess.Enabled = false;

                // Present a time up meesage:
                DialogResult result = MessageBox.Show("The correct number was: " + guessNum, "Time's Up!");

                // Close this form:
                this.Close();
            }
        }


        /// <summary>
        /// Uses user input to see where the user is in relation to the mystery number.
        /// </summary>
        private void buttonGuess_Click(object sender, EventArgs e)
        {
            try
            {
                // Try/Catch intended to test if input is an int:
                int guess = int.Parse(textBoxGuess.Text);

                // Tests if the input is greater than the mystery number:
                if (guess > guessNum)
                {
                    guessCount++;
                    textBoxResult.Text = "Guesses: " + guessCount + " | Guess is too high!";
                    textBoxResult.BackColor = Color.FromArgb(232, 130, 130);
                }

                // Tests if the input is less than the mystery number:
                else if (guess < guessNum)
                {
                    guessCount++;
                    textBoxResult.Text = "Guesses: " + guessCount + " | Guess is too low!";
                    textBoxResult.BackColor = Color.FromArgb(98, 138, 161);
                }

                // Should the user guess the right number:
                else
                {
                    // Stop the timer:
                    timer.Stop();

                    // Show a special victory message in result box:
                    guessCount++;
                    textBoxResult.Text = "Guesses: " + guessCount + " | Bullseye!";
                    textBoxResult.BackColor = Color.FromArgb(138, 194, 132);

                    // Disable text box and button:
                    textBoxGuess.Enabled = false;
                    buttonGuess.Enabled = false;

                    // Present congratulatory message:
                    DialogResult result = MessageBox.Show("Congratulations! You guessed the right number: " + guessNum, "You Won!");

                    // Close this form:
                    this.Close();
                }
            }
            catch
            {
                // Message is presented should the user enter any non-int guesses:
                textBoxResult.Text = "Guesses: " + guessCount + " | Invalid guess! Try an int?";
                textBoxResult.BackColor = Color.FromArgb(240, 240, 156);
                return;
            }
        }
    }
}
