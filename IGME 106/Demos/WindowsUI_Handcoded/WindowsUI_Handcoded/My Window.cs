using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Windows UI using statements.
using System.Windows.Forms;
using System.Drawing;

namespace WindowsUI_Handcoded
{
    class My_Window : Form
    {
        /// <summary>
        /// Sets up the form object.
        /// </summary>
        public My_Window()
        {
            // Set up the basic look of the form.
            this.Text = "My Totally Radical Form!";
            this.Size = new Size(400, 400);

            // Restricts from resizing the form.
            // this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Make a simple control - a button!
            Button button = new Button();
            button.Text = "Click Me!";
            button.Size = new Size(100, 50);
            button.Location = new Point(20, 20);

            // Hook up the button's Click event to a custom method.
            button.Click += Button_Click;
            button.MouseEnter += Button_MouseEnter;

            // Need to tell form object about any and all
            // controls we want it to display!
            // Do this with the form's .Controls list.
            this.Controls.Add(button);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Change the button's color.
            // b.BackColor = Color.Maroon;

            // Or, we can generate color from numbers.
            Random rng = new Random()
            b.BackColor = Color.FromArgb(0, 0, 0);
        }

        /// <summary>
        /// Called when the button is clicked.
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            // Confident that "sender" is our button, because
            // that's the only object we've hooked up to this
            // method.
            Button b = (Button)sender;
            

            // Copy, Alter, Replace!
            Point loc = this.Location;
            loc.X += 50;
            this.Location = loc;
        }
    }
}
