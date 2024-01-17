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
    public partial class Form1 : Form
    {
        private EditorForm editor;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event triggered when the create new map button is pressed and attempts to read in width and height to send to the editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
              editor = new EditorForm();
              editor.ShowDialog();
        }

        /// <summary>
        /// Event triggered when the load button is clicked, which sends the file to load to the editor form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();


            //if the user selects a file, send the filename to constructor of the editor form
            if (result == DialogResult.OK)
            {
                editor = new EditorForm(openFileDialog1.FileName);
                editor.ShowDialog();
            }
        }
    }
}
