using System;

// Need Windows UI-Specific using statements.
using System.Windows.Forms;

namespace WindowsUI_Handcoded
{
    class Program
    {
        static void Main(string[] args)
        {
            // Need to start application slightly differently,
            // now that we want the window to represent the app.

            // Once we start app by creating a new form ("window"),
            // almost all of the code will be written in that form
            // class.

            Application.EnableVisualStyles();
            Application.Run(new My_Window());
        }
    }
}
