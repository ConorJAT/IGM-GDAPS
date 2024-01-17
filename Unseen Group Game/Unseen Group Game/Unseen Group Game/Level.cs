using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class Level
    {
        //fields
        public int CurrentBackground { get; set; }
        public List<GameObject> Walls { get; set; }
        public List<GameObject> Platforms { get; set; }
        public List<GameObject> Checkpoints { get; set; }

        //ladder fields
        public List<Ladder> TempLadders { get; set; }
        public List<Ladder> Ladders { get; set; }
        public List<List<Ladder>> listOfLadders;
        int numberOfLadders;

        public List<GameObject> HidingSpots { get; set; }
        public List<Vent> Vents { get; set; }
        public List<CameraEnemy> Spotlights { get; set; }
        public List<OffSwitch> OffSwitches { get; set; }

        public List<Enemy> Enemies { get; set; }
        public List<DogEnemy> DogEnemies { get; set; }
        public List<CameraEnemy> CameraEnemies { get; set; }

        public bool SwitchPressed { get; set; }

        public Level()
        {
            Walls = new List<GameObject>();
            Platforms = new List<GameObject>();
            Checkpoints = new List<GameObject>();

            //ladder stuff
            TempLadders = new List<Ladder>();
            Ladders = new List<Ladder>();
            listOfLadders = new List<List<Ladder>>();
            numberOfLadders = 0;

            HidingSpots = new List<GameObject>();
            Vents = new List<Vent>();
            OffSwitches = new List<OffSwitch>();

            Enemies = new List<Enemy>();
            DogEnemies = new List<DogEnemy>();
            CameraEnemies = new List<CameraEnemy>();
            Spotlights = new List<CameraEnemy>();

            SwitchPressed = false;
        }

        public void Reset()
        {
            foreach(Checkpoint c in Checkpoints)
            {
                c.ResetTexture();
            }

            foreach (CameraEnemy c in CameraEnemies)
            {
                c.ResetTexture();
            }

            foreach (OffSwitch os in OffSwitches)
            {
                os.ResetTexture();
            }

            foreach(CameraEnemy spotlight in Spotlights)
            {
                spotlight.ResetTexture();
            }

            SwitchPressed = false;
        }

        public void MakeLaddersOnePartOne()
        {
            numberOfLadders = 0;
            listOfLadders.Add(new List<Ladder>());

            try
            {
                listOfLadders[numberOfLadders].Add(TempLadders[0]);

                for (int i = 0; i < TempLadders.Count - 1; i++)
                {
                    if (TempLadders[i].Position.Intersects(TempLadders[i + 1].Position)
                        || ((TempLadders[i].Position.Y + TempLadders[i].Position.Height + 3 >= TempLadders[i + 1].Position.Y) && (TempLadders[i].Position.X == TempLadders[i + 1].Position.X)))
                    {
                        listOfLadders[numberOfLadders].Add(TempLadders[i + 1]);
                    }
                    else
                    {
                        ++numberOfLadders;
                        listOfLadders.Add(new List<Ladder>());
                        listOfLadders[numberOfLadders].Add(TempLadders[i + 1]);
                    }
                }
            }
            catch (Exception)
            {

            }


        }

        public void MakeLaddersOnePartTwo(Texture2D texture)
        {
            try
            {
                foreach (List<Ladder> list in listOfLadders)
                {
                    Ladder temp = new Ladder(texture, list[0].X, list[0].Y + 10, list[0].Width, list[0].Height, 5);

                    foreach (Ladder ladder in list)
                    {
                        if (ladder == list[0])
                        {
                            continue;
                        }
                        else
                        {
                            temp.Height += ladder.Height;
                        }
                    }

                    Ladders.Add(temp);
                }
            }
            catch (Exception)
            {

            }

        }

    }
}
