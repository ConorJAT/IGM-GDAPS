using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class Player : GameObject
    {
        // Fields:
        private bool isHidden;
        private bool faceRight;
        private Point lastCheckpoint;
        private int lastCheckpointLevelIndex;

        // Constructor:
        public Player(Texture2D png, int x, int y, int w, int h)
             : base(png, x, y, w, h)
        {
            isHidden = false;
            faceRight = true;
            lastCheckpoint = new Point(x, y);
        }


        // Properties:
        public bool IsHidden { get { return isHidden; } set { isHidden = value; } }

        public Point LastSave { get { return lastCheckpoint; } set { lastCheckpoint = value; } }

        public int LastCheckpointLevel { get { return lastCheckpointLevelIndex; } set { lastCheckpointLevelIndex = value; } }


        // Methods:
        /// <summary>
        /// Moves the player 
        /// </summary>
        /// <param name="moveFactor">the player's speed</param>
        public void MovePlayer(int moveFactor)
        {
            KeyboardState kb = Keyboard.GetState();

            //moves the player in the x direction based on the keys being pressed
            if (kb.IsKeyDown(Keys.D)) 
            {
                faceRight = true;
                X += moveFactor; 
            }
            if (kb.IsKeyDown(Keys.A)) 
            {
                faceRight = false;
                X -= moveFactor;
            }

        }

        /// <summary>
        /// Draws the player
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            //makes sure the player is facing in the right direction
            if (!faceRight)
            {
                sb.Draw(base.texture, base.position, null, Color.White, 0.0f,
                Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                base.Draw(sb);
            }
        }

        /// <summary>
        /// Draws the player in reference to spritesheet
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="currentFrame"></param>
        public void Draw(SpriteBatch sb, int currentFrame, bool crouch)
        {
            int width = 31;
            int height = 72;
            if (crouch)
            {
                width = 80;
                height = 40;
            }
            //makes sure the player is facing in the right direction
            if (!faceRight)
            {
                sb.Draw(base.texture, base.position, 
                    new Rectangle(width * currentFrame, 0, width, height), 
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                sb.Draw(base.texture, base.position,
                    new Rectangle(width * currentFrame, 0, width, height),
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
            }
        }
    }
}
