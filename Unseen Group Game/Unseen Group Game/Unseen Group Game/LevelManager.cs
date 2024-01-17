using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Unseen_Group_Game
{
    class LevelManager
    {
        //fields------------------------------------------------------------------------------------------------------------------------------
        public List<Level> AllLevels { get; set; }
        public Level CurrentLevel { get; set; }
        public int CurrentLevelIndex { get; set; }
        public int CurrentBackgroundIndex { get; set; }


        public bool FirstLevel
        {
            get
            {
                if (CurrentLevelIndex == 0)
                    return true;
                else
                    return false;
            }
        }
        public bool FinalLevel
        {
            get
            {
                if (CurrentLevelIndex == AllLevels.Count - 1)
                    return true;
                else
                    return false;
            }
        }

        private List<Texture2D> levelTextures;
        private List<Texture2D> enemyTextures;
        private List<Texture2D> backgroundTextures;

        //TEXTURES:
        //Level textures:
        //Position 0 is white rectangle
        //Position 1 is ladder texture
        //Position 2/3 is checkpoint collected/uncollected
        //Position 4 is hiding spot
        //Position 5 is vent
        //Position 6 is platform
        //Position 7 is off switch on
        //Position 8 is off switch off

        //Enemy textures:
        //guard texture is position 0

        //BG textures:
        //Position 0 is standard
        //Position 1 is final level 1
        //Position 2 is final level 2
        //Position 3 is final level 3

        //constructor-------------------------------------------------------------------------------------------------------------------------
        public LevelManager(List<Texture2D> tex, List<Texture2D> enemyTex, List<Texture2D> bgs)
        {
            //subject to change based off of what we load the levels into
            AllLevels = new List<Level>();
            levelTextures = tex;
            enemyTextures = enemyTex;
            backgroundTextures = bgs;
            CurrentLevelIndex = 0;
            CurrentBackgroundIndex = 0;          

        }

        public void LoadLevel(string filename)
        {
            Stream inStream = File.OpenRead(filename);
            StreamReader file = new StreamReader(inStream);

            Level loadedLevel = new Level();

            //read the background in
            loadedLevel.CurrentBackground = (char)file.Read();

            int width = 24;
            int height = 14;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    char currentTile = (char)file.Read();
                    Point currentPosition = new Point(i * 80, j * 80);

                    switch (currentTile)
                    {
                        case 'G': //add a guard
                            loadedLevel.Enemies.Add(new Enemy(enemyTextures[0], currentPosition.X, currentPosition.Y - 80, 195, 160));                        
                            break;

                        case 'C': // add a checkpoint
                            loadedLevel.Checkpoints.Add(new Checkpoint(levelTextures[3], levelTextures[2], currentPosition.X, currentPosition.Y - 40, 40, 120));
                            break;

                        case 'P': //add a platform
                            loadedLevel.Platforms.Add(new GameObject(levelTextures[6], new Rectangle(currentPosition, new Point(80,80))));                         
                            break;

                        case 'L': //add a ladder
                            loadedLevel.TempLadders.Add(new Ladder(levelTextures[1], new Rectangle(currentPosition, new Point(80, 80)), 5));                   
                            break;

                        case 'W': //add a wall
                            loadedLevel.Walls.Add(new GameObject(levelTextures[0], new Rectangle(currentPosition, new Point(80, 80))));
                            break;
                        case 'D': //add a dog
                            loadedLevel.DogEnemies.Add(new DogEnemy(enemyTextures[1], new Rectangle(new Point (currentPosition.X, currentPosition.Y - 30), new Point(160, 110))));
                            break;
                        case 'S': //add camera
                            loadedLevel.CameraEnemies.Add(new CameraEnemy(enemyTextures[2], enemyTextures[3], new Rectangle(new Point(currentPosition.X - 160, currentPosition.Y), new Point(240, 240))));
                            break;
                        case 'H': //add hiding spot
                            loadedLevel.HidingSpots.Add(new HidingSpot(levelTextures[4], currentPosition.X, currentPosition.Y - 80, 80, 160));
                            break;
                        case 'V': //add vent
                            loadedLevel.Vents.Add(new Vent(levelTextures[5], new Rectangle(currentPosition, new Point(80, 80))));
                            break;
                        case 'O': //add off switch
                            loadedLevel.OffSwitches.Add(new OffSwitch(levelTextures[7], levelTextures[8], new Rectangle(currentPosition, new Point(80, 80))));
                            break;
                        case 'X': //add spotlight
                            loadedLevel.Spotlights.Add(new CameraEnemy(enemyTextures[4], enemyTextures[5], new Rectangle(new Point(currentPosition.X, currentPosition.Y), new Point(160, 240))));
                            break;

                        default: //add nothing
                            break;
                    }
                }
            }
            //close file
            file.Close();

            //vent hook up
            if (loadedLevel.Vents.Count == 2)
            {
                loadedLevel.Vents[0].ConnectingVent = loadedLevel.Vents[1];
                loadedLevel.Vents[1].ConnectingVent = loadedLevel.Vents[0] ;
            }

            loadedLevel.MakeLaddersOnePartOne();
            loadedLevel.MakeLaddersOnePartTwo(levelTextures[1]);

            //add the loaded level to the level list
            AllLevels.Add(loadedLevel);
            CurrentLevel = loadedLevel;
        }
 

        /// <summary>
        /// Update method- checks collision
        /// </summary>
        /// <param name="player"></param>
        public void UpdateLevel(Player player)
        {
            foreach(GameObject wall in CurrentLevel.Walls)
            {
                if (wall.Interact(player))
                {
                    Rectangle intersectRect = Rectangle.Intersect(wall.Position, player.Position);

                    //Collision in the X direction
                    //if the player is to the left of the object, move them left
                    if (intersectRect.Width <= intersectRect.Height)
                    {
                        if (player.X <= wall.X)
                        {
                            player.X -= intersectRect.Width;
                        }
                        //otherwise move them right
                        else if (player.X >= wall.X)
                        {
                            player.X += intersectRect.Width;
                        }
                    }

                    //collision in the Y direction
                    else
                    {                         
                        //if above the wall
                        if (player.Y + player.Height >= wall.Y)
                        {
                            player.Y -= intersectRect.Height;
                        }
                        //below te wall
                        else
                        {
                            player.Y += intersectRect.Height;
                        }
                    }
                }

                foreach (GameObject p in CurrentLevel.Platforms)
                {
                    //only y collision
                    //and only for going down throught a platform


                    if (p.Interact(player))
                    { 
                        Rectangle intersectRect = Rectangle.Intersect(p.Position, player.Position);

                        //if the player is above the object, move them up
                        if (player.Y <= p.Y)
                        {
                            player.Y -= intersectRect.Height;
                        }

                    }
                }

            }

            foreach(Checkpoint checkpoint in CurrentLevel.Checkpoints)
            {
                if(checkpoint.Interact(player))
                    player.LastCheckpointLevel = CurrentLevelIndex;
            }

        }

        /// <summary>
        /// Draws the objects in the level
        /// </summary>
        /// <param name="sb"></param>
        public void DrawLevel(SpriteBatch sb)
        {
            //draws the background
                sb.Draw(backgroundTextures[CurrentBackgroundIndex], new Rectangle(0, 0, 1920, 1080), Color.White);

            //loops through each list of objects and draws them
            foreach (GameObject wall in CurrentLevel.Walls)
            {
                sb.Draw(wall.Texture, wall.Position, Color.Black);
            }

            foreach (GameObject platform in CurrentLevel.Platforms)
            {
                sb.Draw(platform.Texture, platform.Position, Color.DarkGray);
            }

            foreach (Ladder ladder in CurrentLevel.TempLadders)
            {
                sb.Draw(ladder.Texture, ladder.Position, Color.White);
            }

            foreach (Checkpoint checkpoint in CurrentLevel.Checkpoints)
            {
                sb.Draw(checkpoint.Texture, checkpoint.Position, Color.White);
            }

            foreach (HidingSpot hidingSpot in CurrentLevel.HidingSpots)
            {
                sb.Draw(hidingSpot.Texture, hidingSpot.Position, Color.White);
            }

            foreach (Vent vent in CurrentLevel.Vents)
            {
                sb.Draw(vent.Texture, vent.Position, Color.White);
            }

            foreach(OffSwitch offSwitch in CurrentLevel.OffSwitches)
            {
                sb.Draw(offSwitch.Texture, offSwitch.Position, Color.White);
            }
        }

        public void ResetLevels()
        {
            foreach (Level l in AllLevels)
            {
                l.Reset();
            }
        }
    }
}
