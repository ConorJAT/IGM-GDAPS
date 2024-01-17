using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class Checkpoint : GameObject
    {
        //fields
        Texture2D collected;
        Texture2D uncollected;

        // Constructor:
        public Checkpoint(Texture2D uc, Texture2D c, int x, int y, int w, int h)
             : base(uc, x, y, w, h) 
        {
            collected = c;
            uncollected = uc;
        }

        //Constructor which takes a rectangle:
        public Checkpoint(Texture2D uncollected, Texture2D collected, Rectangle pos)
             : base(uncollected, pos)
        {
            this.collected = collected;
        }


        // Methods:
        /// <summary>
        /// Checks if the player has interacted with the checkpoint
        /// </summary>
        /// <param name="interObject"></param>
        /// <returns></returns>
        public override bool Interact(Player interObject)
        {
            //if the player touches the checkpoint, their position gets saved to teleport back to 
            //and the texture of it changes
            if (Position.Intersects(interObject.Position))
            {
                interObject.LastSave = new Point(interObject.X, interObject.Y);
                texture = collected;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the checkpoint
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {

            base.Draw(sb);
        }

        public void ResetTexture()
        {
            texture = uncollected;
        }
    }
}
