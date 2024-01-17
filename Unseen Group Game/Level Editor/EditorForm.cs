using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Level_Editor
{
    public partial class EditorForm : Form
    {
        private int width = 24; //width of the level in picture boxes
        private int height = 14; //height of the level
        Color currentColor; //current color the user has selected
        Image currentImage;
        int currentBackground;
        bool saved; //if the user has saved their changes

        /// <summary>
        /// constructor which makes a clean level
        /// </summary>
        public EditorForm()
        {
            InitializeComponent();

            //the user does not have unsaved changes
            saved = true;

            //start with the current color as transparent
            currentColor = Color.Transparent;

            //start with 1 for background
            currentBackground = 1;
            radioButtonBackground1.Checked = true;

            //the point in the groupbox where the top left corner of the level is
            Point startingPoint = new Point(15, 35);

            //creates an array of picture boxes
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(46, 46);
                    pb.Location = new Point((i * pb.Size.Height) + startingPoint.X, (j * pb.Size.Height) + startingPoint.Y);
                    pb.BackColor = Color.Transparent;
                    pb.Click += MapTileClick;
                    groupBoxMap.Controls.Add(pb);
                }
            }

            //adjust right margin of the group box
            groupBoxMap.Width = 1143;

            //adjust right margin of the form
            this.Width = (groupBoxMap.Right + 40);
        }

        /// <summary>
        /// constructor which takes a filename to load
        /// </summary>
        /// <param name="filename"></param>
        public EditorForm(string filename)
        {
            InitializeComponent();

            LoadFile(filename);
        }

        /// <summary>
        /// Event where if the user clicks one of the color pallet buttons, their current color is changed to that
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorButtonClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            currentColor = p.BackColor;
            currentImage = p.BackgroundImage;
            pictureBoxCurrent.BackColor = currentColor;
            pictureBoxCurrent.BackgroundImage = currentImage;
        }

        /// <summary>
        /// Event where if the user clicks one of the map tiles, that tile is changed to their current color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapTileClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            pb.BackColor = currentColor;
            pb.BackgroundImage = currentImage;
        }

        /// <summary>
        /// Event where if the user tries to close the form with unsaved changes, they are stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show(
                    "There are unsaved changes. Are you sure you want to quit?",
                    "Unsaved changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    e.Cancel = true;
            }    
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialogEditor.ShowDialog();

            //if the user selects a place to put the file
            if (result == DialogResult.OK)
            {
                //initialize file writing objects
                Stream outStream = File.OpenWrite(saveFileDialogEditor.FileName);
                BinaryWriter output = new BinaryWriter(outStream);

                //write the current background
                output.Write((char)currentBackground);

                //write each box
                foreach (PictureBox currentBox in groupBoxMap.Controls)
                {
                    if (currentBox.BackColor == pictureBoxGuard.BackColor &&
                        currentBox.BackgroundImage == pictureBoxGuard.BackgroundImage)
                        output.Write('G');
                    else if (currentBox.BackColor == pictureBoxCheckpoint.BackColor &&
                             currentBox.BackgroundImage == pictureBoxCheckpoint.BackgroundImage)
                        output.Write('C');
                    else if (currentBox.BackColor == pictureBoxPlatform.BackColor &&
                             currentBox.BackgroundImage == pictureBoxPlatform.BackgroundImage)
                        output.Write('P');
                    else if (currentBox.BackColor == pictureBoxLadder.BackColor &&
                             currentBox.BackgroundImage == pictureBoxLadder.BackgroundImage)
                        output.Write('L');
                    else if (currentBox.BackColor == pictureBoxWall.BackColor &&
                             currentBox.BackgroundImage == pictureBoxWall.BackgroundImage)
                        output.Write('W');
                    else if (currentBox.BackColor == pictureBoxDog.BackColor &&
                        currentBox.BackgroundImage == pictureBoxDog.BackgroundImage)
                        output.Write('D');
                    else if (currentBox.BackColor == pictureBoxCamera.BackColor &&
                        currentBox.BackgroundImage == pictureBoxCamera.BackgroundImage)
                        output.Write('S');
                    else if (currentBox.BackColor == pictureBoxHidingSpot.BackColor &&
                        currentBox.BackgroundImage == pictureBoxHidingSpot.BackgroundImage)
                        output.Write('H');
                    else if (currentBox.BackColor == pictureBoxVent.BackColor &&
                        currentBox.BackgroundImage == pictureBoxVent.BackgroundImage)
                        output.Write('V');
                    else if (currentBox.BackColor == pictureBoxButton.BackColor &&
                        currentBox.BackgroundImage == pictureBoxButton.BackgroundImage)
                        output.Write('O');
                    else if (currentBox.BackColor == pictureBoxSpotlight.BackColor &&
                        currentBox.BackgroundImage == pictureBoxSpotlight.BackgroundImage)
                            output.Write('X');
                        else
                        output.Write('-');                     
                }

                //close the file
                output.Close();

                //if the file has unsaved changes (noted with an asterisk) remove it
                if (!saved)
                {
                    this.Text = this.Text.Remove(this.Text.Length - 1);
                }

                saved = true;

                MessageBox.Show(
                    "File saved succesfully",
                    "File saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Load button event- calls a load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogEditor.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadFile(openFileDialogEditor.FileName);
            }
        }

        /// <summary>
        /// Load function- takes a filename and loads it
        /// </summary>
        /// <param name="filename"></param>
        private void LoadFile(string filename)
        {
            //clear the old map
            groupBoxMap.Controls.Clear();

            Point startingPoint = new Point(15, 25);

            Stream inStream = File.OpenRead(filename);
            StreamReader file = new StreamReader(inStream);

            //read the background in
            currentBackground = (char)file.Read();

            //check the radio button with the proper background
            foreach (RadioButton rb in groupBoxBackground.Controls)
            {
                if (int.Parse(rb.Name[rb.Name.Length - 1].ToString()) == currentBackground)
                    rb.Checked = true;
            }

            //Create an array of picture boxes with width and height
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(44, 44);
                    pb.Location = new Point((i * pb.Size.Height) + startingPoint.X, (j * pb.Size.Height) + startingPoint.Y);

                    char currentTile = (char)file.Read();

                    switch (currentTile)
                    {
                        case 'G':
                            pb.BackColor = pictureBoxGuard.BackColor;
                            pb.BackgroundImage = pictureBoxGuard.BackgroundImage;
                            break;
                        case 'C':
                            pb.BackColor = pictureBoxCheckpoint.BackColor;
                            pb.BackgroundImage = pictureBoxCheckpoint.BackgroundImage;
                            break;
                        case 'P':
                            pb.BackColor = pictureBoxPlatform.BackColor;
                            pb.BackgroundImage = pictureBoxPlatform.BackgroundImage;
                            break;
                        case 'L':
                            pb.BackColor = pictureBoxLadder.BackColor;
                            pb.BackgroundImage = pictureBoxLadder.BackgroundImage;
                            break;
                        case 'W':
                            pb.BackColor = pictureBoxWall.BackColor;
                            pb.BackgroundImage = pictureBoxWall.BackgroundImage;
                            break;
                        case 'D':
                            pb.BackColor = pictureBoxDog.BackColor;
                            pb.BackgroundImage = pictureBoxDog.BackgroundImage;
                            break;
                        case 'S':
                            pb.BackColor = pictureBoxCamera.BackColor;
                            pb.BackgroundImage = pictureBoxCamera.BackgroundImage;
                            break;
                        case 'H':
                            pb.BackColor = pictureBoxHidingSpot.BackColor;
                            pb.BackgroundImage = pictureBoxHidingSpot.BackgroundImage;
                            break;
                        case 'V':
                            pb.BackColor = pictureBoxVent.BackColor;
                            pb.BackgroundImage = pictureBoxVent.BackgroundImage;
                            break;
                        case 'O':
                            pb.BackColor = pictureBoxButton.BackColor;
                            pb.BackgroundImage = pictureBoxButton.BackgroundImage;
                            break;
                        case 'X':
                            pb.BackColor = pictureBoxSpotlight.BackColor;
                            pb.BackgroundImage = pictureBoxSpotlight.BackgroundImage;
                            break;
                        default:
                            pb.BackColor = Color.Transparent;
                            break;
                    }
                    pb.Click += MapTileClick;
                    groupBoxMap.Controls.Add(pb);
                }
            }

            //close file
            file.Close();

            //adjust right margin of the group box
            groupBoxMap.Width = 1095;

            //adjust right margin of the form
            this.Width = (groupBoxMap.Right + 40);

            MessageBox.Show(
                "File loaded successfully",
                "File Loaded",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            //adds filename to top bar
            this.Text = "Level Editor - " + filename;
            saved = true;
        }

        private void radioButtonBackground_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            //set the last letter of the background button to the current background
            currentBackground = int.Parse(rb.Text[rb.Text.Length - 1].ToString());
        }
    }
}
