// Conor Race
// Jan. 27th, 2022
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

namespace Bomb_Game__GUI_Creation_
{
    public partial class formGame : Form
    {
        List<Button> wires;

        public formGame()
        {
            wires = new List<Button>();
            InitializeComponent();
        }

        /// <summary>
        /// Adds all wires to a local list upon load in (Original: formGame_Load).
        /// </summary>
        private void LoadGame(object sender, EventArgs e)         
        {
            wires.Add(buttonWire1);
            wires.Add(buttonWire2);
            wires.Add(buttonWire3);
            wires.Add(buttonWire4);
            wires.Add(buttonWire5);
        }


        /// <summary>
        /// Keeps track of user's time and enables changes if the user runs out of time.
        /// (Original: timerBomb_Tick)
        /// </summary>
        private void Tick(object sender, EventArgs e)
        {
            progressbarTime.Increment(1);

            // Should time run out...
            if (progressbarTime.Value >= 100)
            {
                // Disable all wires:
                for (int i = 0; i < wires.Count; i++)
                {
                    wires[i].Enabled = false;
                }

                // Change and enable start button:
                buttonStart.Text = "Restart Game";
                buttonStart.Enabled = true;

                // Stop timer:
                timerBomb.Stop();

                // Print result:
                textboxStatus.ForeColor = Color.Red;
                textboxStatus.Text = "Bomb Status: Blown to Smithereens!";
            }
        }


        /// <summary>
        /// Starts (or restarts) a game via a series of changes (Original: buttonStart_Click).
        /// </summary>
        private void StartGame(object sender, EventArgs e)
        {
            List<Color> wireColors = new List<Color>();
            wireColors.Add(Color.Red);
            wireColors.Add(Color.Yellow);
            wireColors.Add(Color.Blue);
            wireColors.Add(Color.Black);
            wireColors.Add(Color.White);

            Random rng = new Random();
            
            // Enable and give all wires a random color:
            for (int i = 0; i < wires.Count; i++)
            {
                wires[i].BackColor = wireColors[rng.Next(0, 5)];
                wires[i].Enabled = true;
            }

            // Disable start button:
            buttonStart.Enabled = false;

            // Reset progress bar and result:
            progressbarTime.Value = 0;
            textboxStatus.Text = "";

            // Start timer:
            timerBomb.Start();
        }


        /// <summary>
        /// Allows the user to cut wires in-game and reports success or failure.
        /// (Original: buttonWire1_Click)
        /// </summary>
        /// <param name="sender"> Associated wire that was cut. </param>
        private void CutWire(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Case 1: No Red Wires
            bool noRed = true;
            for (int i = 0; i < wires.Count; i++)
            {
                if (wires[i].BackColor == Color.Red)
                {
                    noRed = false;
                    break;
                }
            }

            if (noRed && b == wires[1])
            {
                Defusal();
                return;
            }
            else if (noRed && b != wires[1])
            {
                WrongWire();
                return;
            }


            // Case 2: Last Wire White
            if (wires[4].BackColor == Color.White && b == wires[4])
            {
                Defusal();
                return;
            }
            else if (wires[4].BackColor == Color.White && b == wires[4])
            {
                WrongWire();
                return;
            }


            // Case 3: Multi Blue, Last Blue
            int blueCount = 0;
            int lastBluePos = 0;
            for (int i = 0; i < wires.Count; i++)
            {
                if (wires[i].BackColor == Color.Blue)
                {
                    blueCount++;
                    lastBluePos = i;
                }
            }

            if (blueCount > 1 && b == wires[lastBluePos])
            {
                Defusal();
                return;
            }
            else if (blueCount > 1 && b != wires[lastBluePos])
            {
                WrongWire();
                return;
            }


            // Case 4: Cut Last Wire
            if (b == wires[4])
            {
                Defusal();
            }
            else
            {
                WrongWire();
            }
        }


        /// <summary>
        /// Helper method; Provides a series of changes when the user cuts the correct wire.
        /// </summary>
        private void Defusal()
        {
            // Stop timer:
            timerBomb.Stop();

            // Print result:
            textboxStatus.Text = "Bomb Status: Successfully Defused!";

            // Disable wires:
            for (int i = 0; i < wires.Count; i++)
            {
                wires[i].Enabled = false;
            }

            // Change and enable start button:
            buttonStart.Text = "Restart Game";
            buttonStart.Enabled = true;
        }


        /// <summary>
        /// Helper method; Provides a series of changes when the user cuts the wrong wire.
        /// </summary>
        private void WrongWire()
        {
            // Stop timer:
            timerBomb.Stop();

            // Print result:
            textboxStatus.Text = "Bomb Status: Blown to Smithereens!";

            // Disable wires:
            for (int i = 0; i < wires.Count; i++)
            {
                wires[i].Enabled = false;
            }

            // Change and enable start button:
            buttonStart.Text = "Restart Game";
            buttonStart.Enabled = true;
        }
    }
}
