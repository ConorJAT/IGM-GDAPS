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
using System.IO;

namespace Level_Editor
{
    public partial class FormEditor : Form
    {
        // FIELDS:
        // Height/Length of each individual tile:
        int tileLength;

        // How many tiles long will the map be:
        int widthTiles;

        // How many tiles high will the map be:
        int heightTiles;

        // Used for if file is already created or not.
        // If it is, the Save Dialog is NOT opened, and save
        // occurs automatically:
        bool hasSaved;

        // Used to warn user of any unsaved changes when
        // exiting or loading another file:
        bool unsavedChange;

        // File name used for saving info:
        string saveFile;

        // File name used for loading in a file and keeping
        // track of current saved/unsaved info:
        string loadFile;

        // Current color the user has selected:
        Color currentColor;

        // 2D array to hold the data of all tiles:
        PictureBox[,] theTiles;


        // CONSTRUCTORS / FORMS:
        /// <summary>
        /// Constructor for FormEditor. Holds information regarding the grid's info and
        /// regarding user color selection.
        /// </summary>
        /// <param name="wTiles"> Quantity of tiles in horizontal direction. </param>
        /// <param name="hTiles"> Quantity of tiles in vertical direction. </param>
        public FormEditor(int wTiles, int hTiles)
        {
            InitializeComponent();

            widthTiles = wTiles;
            heightTiles = hTiles;
            tileLength = 600 / hTiles;

            hasSaved = false;
            unsavedChange = false;

            loadFile = null;

            currentColor = Color.Black;
            theTiles = new PictureBox[heightTiles, widthTiles];

            CreateNewMap();
        }


        /// <summary>
        /// Default constructor for FormEditor. Used primarely for loading maps from start.
        /// </summary>
        public FormEditor()
        {
            InitializeComponent();

            widthTiles = 0;
            heightTiles = 0;
            tileLength = 0;

            hasSaved = false;
            unsavedChange = false;

            loadFile = null;

            currentColor = Color.Black;
            theTiles = new PictureBox[heightTiles, widthTiles];
        }


        // METHODS / EVENTS:
        /// <summary>
        /// Creates a custom grid for which the map can be drawn on, based on user input.
        /// Also, sets a default color for the user.
        /// </summary>
        public void CreateNewMap()
        {
            int i = 0;
            int j = 0;

            // Loop for vertical tiles:
            for (int y = 30; y < 600; y += tileLength)
            {
                j = 0;
                // Loop for horizontal tiles:
                for (int x = 180; x < 180 + (widthTiles * tileLength); x += tileLength)
                {
                    // Creates a new PictureBox object every iteration:
                    PictureBox tile = new PictureBox();
                    tile.Size = new Size(tileLength, tileLength);
                    tile.Location = new Point(x, y);
                    tile.BackColor = Color.FromArgb(212, 208, 207);
                    this.Controls.Add(tile);

                    // Adds event to every single PictureBox:
                    tile.Click += ChangeTileColor;

                    // Adds each tile to a local 2D array:
                    theTiles[i, j] = tile;
                    j++;
                }
                i++;
            }

            // Sets a default color for the user:
            pictureBoxChosen.BackColor = currentColor;
        }


        /// <summary>
        /// Allows the user to change color for use.
        /// </summary>
        /// <param name="sender"> Corresponding color user has chosen. </param>
        private void PickColor(object sender, EventArgs e)
        {
            Button clr = (Button)sender;
            currentColor = clr.BackColor;
            pictureBoxChosen.BackColor = currentColor;
        }


        /// <summary>
        /// Changes the color of the selected tile.
        /// </summary>
        /// <param name="sender"> Corresponding tile user has chosen. </param>
        private void ChangeTileColor(object sender, EventArgs e)
        {
            PictureBox t = (PictureBox)sender;
            t.BackColor = currentColor;
            
            // When new changes are made and aren't immediately saved:
            unsavedChange = true;

            // Adds asterisk to file name to denote new changes:
            if (loadFile == null)
            {
                this.Text = "Level Editor *";
            }
            else
            {
                this.Text = "Level Editor - " + loadFile + " *";
            }
            
        }


        /// <summary>
        /// Allows the user to save their Map designs as .level files, which
        /// can then be loaded at a later time.
        /// </summary>
        private void SaveMap(object sender, EventArgs e)
        {
            // Condition if a local save file does not exist yet:
            if (!hasSaved)
            {
                // Prepares and shows the Save File Dialog:
                SaveFileDialog saveMap = new SaveFileDialog();
                saveMap.Title = "Save a Level File:";
                saveMap.Filter = "Level Files|*.level";

                // If the user decides to save their design...
                if (saveMap.ShowDialog() == DialogResult.OK)
                {
                    // Creates a binary writer aiming toward the entered file name:
                    Stream outStream = File.OpenWrite(saveMap.FileName);
                    BinaryWriter output = new BinaryWriter(outStream);

                    // Encodes the width, height and tile length into binary:
                    output.Write(widthTiles);
                    output.Write(heightTiles);
                    output.Write(tileLength);

                    // Encodes the color value of each tile as an int into binary:
                    for (int x = 0; x < theTiles.GetLength(0); x++)
                    {
                        for (int y = 0; y < theTiles.GetLength(1); y++)
                        {
                            output.Write(theTiles[x, y].BackColor.ToArgb());
                        }
                    }

                    // Closes the binary writer:
                    output.Close();

                    // Adds file name to form's title:
                    string[] path = saveMap.FileName.Split('\\');
                    loadFile = path[path.Length - 1];
                    this.Text = "Level Editor - " + loadFile;

                    // Shows success message when save is completed:
                    DialogResult saveSuccess = MessageBox.Show("Map saved successfully!", "File Saved",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                    hasSaved = true;
                    saveFile = saveMap.FileName;
                }
            }

            // Condition for if a local save file is already created:
            else
            {
                // Creates a binary writer aiming toward the entered file name:
                Stream outStream = File.Open(saveFile, FileMode.Create);
                BinaryWriter output = new BinaryWriter(outStream);

                // Encodes the width, height and tile length into binary:
                output.Write(widthTiles);
                output.Write(heightTiles);
                output.Write(tileLength);

                // Encodes the color value of each tile as an int into binary:
                for (int x = 0; x < theTiles.GetLength(0); x++)
                {
                    for (int y = 0; y < theTiles.GetLength(1); y++)
                    {
                        output.Write(theTiles[x, y].BackColor.ToArgb());
                    }
                }

                // Closes the binary writer:
                output.Close();

                // Adds file name to form's title:
                this.Text = "Level Editor - " + loadFile;

                // Shows success message when save is completed:
                DialogResult saveSuccess = MessageBox.Show("Map saved successfully!", "File Saved",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            unsavedChange = false;
        }


        /// <summary>
        /// Allows the user to load their Map designs from .level files.
        /// </summary>
        private void LoadMap(object sender, EventArgs e)
        {
            // If there are unsaved changes, warn user of unsaved changes before loading a map:
            if (unsavedChange)
            {
                DialogResult checkUser = MessageBox.Show("There are unsaved changes. Are you sure you'd like to quit?",
                                                         "Unsaved Changes Detected", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Information);
                if (checkUser == DialogResult.No)
                {
                    return;
                }
            }

            // Prepare and show the Load File Dialog:
            OpenFileDialog loadMap = new OpenFileDialog();
            loadMap.Title = "Load a Level File:";
            loadMap.Filter = "Level Files|*.level";

            // If the user decides to load one of their designs...
            if (loadMap.ShowDialog() == DialogResult.OK)
            {
                LoadFromStart(loadMap.FileName);
            }
        }


        /// <summary>
        /// Helper method for LoadMap event. Loads the actual files themselves.
        /// </summary>
        /// <param name="fileName"> Name of file to be loaded. </param>
        public void LoadFromStart(string fileName)
        {
            // Clears the current board of any tiles:
            for (int x = 0; x < theTiles.GetLength(0); x++)
            {
                for (int y = 0; y < theTiles.GetLength(1); y++)
                {
                    this.Controls.Remove(theTiles[x, y]);
                }
            }

            // Creates a binary reader aiming toward the entered file name:
            Stream inStream = File.OpenRead(fileName);
            BinaryReader input = new BinaryReader(inStream);

            // Reads in the width, height and tile length of particular file:
            widthTiles = input.ReadInt32();
            heightTiles = input.ReadInt32();
            tileLength = input.ReadInt32();

            // Creates and prepares new 2D array:
            theTiles = new PictureBox[heightTiles, widthTiles];
            int i = 0;
            int j = 0;

            // Recreates the map as translated in the file: 
            for (int y = 30; y < 600; y += tileLength)
            {
                j = 0;
                for (int x = 180; x < 180 + (widthTiles * tileLength); x += tileLength)
                {
                    PictureBox tile = new PictureBox();
                    tile.Size = new Size(tileLength, tileLength);
                    tile.Location = new Point(x, y);

                    // Every tile's color is translated from binary from the file:
                    tile.BackColor = Color.FromArgb(input.ReadInt32());
                    this.Controls.Add(tile);

                    tile.Click += ChangeTileColor;

                    theTiles[i, j] = tile;
                    j++;
                }
                i++;
            }

            // Closes the binary reader:
            input.Close();

            // Shows success message when load is completed:
            DialogResult loadSuccess = MessageBox.Show("Map loaded successfully!", "File Loaded",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Changes form name to display file name:
            string[] path = fileName.Split('\\');
            loadFile = path[path.Length - 1];
            this.Text = "Level Editor - " + loadFile;

            hasSaved = true;
            saveFile = fileName;
            unsavedChange = false;
        }


        /// <summary>
        /// Detects for any unsaved changes and if present, will alert the user
        /// before they close the file.
        /// </summary>
        private void CloseEditor(object sender, FormClosingEventArgs e)
        {
            if (unsavedChange)
            {
                // Presents a warning box of any unsaved changes before the form closes:
                DialogResult checkUser = MessageBox.Show("There are unsaved changes. Are you sure you'd like to quit?",
                                                         "Unsaved Changes Detected", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Information);
                if (checkUser == DialogResult.No)
                {
                    // If the user says no, they are returned to the form:
                    e.Cancel = true;
                }
            }
        }
    }
}
