using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class CameraEnemy : Enemy
    {
        public Texture2D OnTexture { get; set; }
        public Texture2D OffTexture { get; set; }
        
        // Constructor:
        public CameraEnemy(Texture2D pngOn, Texture2D pngOff, int x, int y, int w, int h)
             : base(pngOn, x, y, w, h)
        {
            faceRight = false;

            OnTexture = pngOn;
            OffTexture = pngOff;
        }

        // Constructor (Takes rectangle instead of values):
        public CameraEnemy(Texture2D pngOn, Texture2D pngOff, Rectangle pos)
             : base(pngOn, pos)
        {
            faceRight = false;

            OnTexture = pngOn;
            OffTexture = pngOff;
        }

        /// <summary>
        /// Checks if the camera is touching the player object:
        /// </summary>
        /// <param name="interObject"></param>
        /// <returns></returns>
        public override bool Interact(Player interObject)
        {
            if (base.Interact(interObject))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the camera
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
              base.Draw(sb);
        }

        public void ResetTexture()
        {
            texture = OnTexture;
        }

    }
}
