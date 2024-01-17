// Conor Race
// Feb. 6th, 2022
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

namespace Level_Editor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Tests whether map parameters are acceptable, and if so, generates a new map.
        /// </summary>
        private void CreateMap(object sender, EventArgs e)
        {
            string error = "Errors:";

            int w = 0;
            int h = 0;

            // Testing width acceptability:
            try
            {
                // Tests if width is an int:
                int width = int.Parse(textBoxWidth.Text);

                // Tests if width is too small:
                if (width < 10)
                {
                    error += "\n  > Width is too small. Minimum value is 10.";
                }
                // Tests if width is too large:
                else if (width > 30)
                {
                    error += "\n  > Width is too large. Maximum value is 30.";
                }
                // If width is acceptable, it is saved for map generation:
                else
                {
                    w = width;
                }
            }
            catch
            {
                error += "\n  > Invalid width parameter. Please enter int values only.";
            }


            // Testing height acceptability:
            try
            {
                // Tests if height is an int:
                int height = int.Parse(textBoxHeight.Text);

                // Tests if height is too small:
                if (height < 10)
                {
                    error += "\n  > Height is too small. Minimum value is 10.";
                }
                // Tests if height is too large:
                else if (height > 30)
                {
                    error += "\n  > Height is too large. Maximum value is 30.";
                }
                // If width is acceptable, it is also saved for map generation:
                else
                {
                    h = height;
                }
            }
            catch
            {
                error += "\n  > Invalid height parameter. Please enter int values only.";
            }


            // If any errors were detected, an error message pop-up is show and
            // the map is NOT generated:
            if (error != "Errors:")
            {
                DialogResult showError = MessageBox.Show(error, "Error Generating Map:",
                                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If parameters show no error, a FormEditor is created and shown to the user:
            else
            {
                FormEditor myMap = new FormEditor(w, h);
                myMap.ShowDialog();
            }
        }


        /// <summary>
        /// Loads a map directly from the load dialog and opens the FormEditor.
        /// </summary>
        private void LoadMap(object sender, EventArgs e)
        {
            OpenFileDialog loadMap = new OpenFileDialog();
            loadMap.Title = "Load a Level File:";
            loadMap.Filter = "Level Files|*.level";

            if (loadMap.ShowDialog() == DialogResult.OK)
            {
                FormEditor mapToLoad = new FormEditor();
                mapToLoad.LoadFromStart(loadMap.FileName);
                mapToLoad.ShowDialog();
            }
        }
    }
}
