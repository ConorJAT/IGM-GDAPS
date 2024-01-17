using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Unseen_Group_Game
{
    class EnemyManager
    {
        //fields----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<Enemy> allEnemies { get; set; }
        public List<DogEnemy> allDogs { get; set; }
        public List<CameraEnemy> allCameras { get; set; }
        public List<CameraEnemy> allSpotlights { get; set; }

        //whether an off switch has been pressed


        //constructor---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public EnemyManager()
        {
            allEnemies = new List<Enemy>();
            allDogs = new List<DogEnemy>();
            allCameras = new List<CameraEnemy>();
            allSpotlights = new List<CameraEnemy>();
        }

        //methods-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Change the enemies, in the case of a level change or something
        /// </summary>
        /// <param name="newEnemies"></param>
        public void ChangeEnemies (List<Enemy> newEnemies, List<DogEnemy> newDogs, List<CameraEnemy> newCams, List<CameraEnemy> newSpotlights)
        {
            allEnemies = newEnemies;
            allDogs = newDogs;
            allCameras = newCams;
            allSpotlights = newSpotlights;
        }

        /// <summary>
        /// updates the state of the enemies
        /// </summary>
        /// <param name="player"> the player that can run into the enemy </param>
        public bool UpdateState(Player player, List<GameObject> walls, bool switchPressed)
        {
            for(int i = 0; i < allEnemies.Count; i++)
            {
                allEnemies[i].MoveEnemy();
                allEnemies[i].WallCollision(walls);

                if(allEnemies[i].Interact(player))
                {
                    return true;
                }
            }

            foreach (DogEnemy dog in allDogs)
            {
                dog.MoveDog(player);
                dog.DogWallCollision(walls);

                if (dog.Interact(player))
                {
                    return true;
                }
            }

            foreach (CameraEnemy cam in allCameras)
            {
                if (cam.Interact(player) && !switchPressed)
                {
                    return true;
                }
            }

            foreach(CameraEnemy spotlight in allSpotlights)
            {
                if (spotlight.Interact(player) && !switchPressed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// updates the drawing of the enemies
        /// </summary>
        /// <param name="sb"> the SpriteBatch being used to draw the enemy </param>
        public void UpdateDrawing(SpriteBatch sb, int currentFrame, int currentFrame2   )
        {
            for(int i = 0; i < allEnemies.Count; i++)
            {
                allEnemies[i].Draw(sb, currentFrame);
            }

            foreach (DogEnemy dog in allDogs)
            {
                dog.Draw(sb, currentFrame2);
            }

            foreach (CameraEnemy cam in allCameras)
            {
                cam.Draw(sb);
            }

            foreach(CameraEnemy spotlight in allSpotlights)
            {
                spotlight.Draw(sb);
            }
        }

        /// <summary>
        /// Resets the enemy to its original position
        /// </summary>
        public void ResetPosition()
        {
            for(int i = 0; i < allEnemies.Count; i++)
            {
                allEnemies[i].X = allEnemies[i].StartingPosition.X;
                allEnemies[i].Steps = 0;
            }
        }
    }
}
