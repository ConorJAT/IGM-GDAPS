// Conor Race
// Jan 24th, 2022
// IGME.106.07

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Button_Drawer__Windows_UI_
{
    class MyForm : Form
    {
        public MyForm()
        {
            // Sets the overall window format.
            this.Text = "Button Drawer Program";
            this.Size = new Size(620, 640);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            Button button;


            // Creates the 100 buttons (controls rows).
            for (int y = 0; y < 600; y += 60)
            {
                // Creates the 100 buttons (controls columns).
                for (int x = 0; x < 600; x += 60)
                {
                    // Creates a new button per interation of the secondary for loop.
                    button = new Button();
                    button.BackColor = Color.FromArgb(28, 184, 212);
                    button.Size = new Size(60, 60);
                    button.Location = new Point(x, y);


                    // Adds each new button to the overall window.
                    this.Controls.Add(button);


                    // Events that trigger the buttons to change color whenever moused over.
                    button.MouseEnter += ChangeColorEnter;
                    button.MouseLeave += ChangeColorLeave;
                }
            }
  
        }


        /// <summary>
        /// Changes the color of buttons when the mouse leaves the button. 
        /// </summary>
        private void ChangeColorLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(14, 95, 110);
        }


        /// <summary>
        /// Changes the color of buttons when the mouse enters the button.
        /// </summary>
        private void ChangeColorEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(31, 7, 77);
        }
    }
}
