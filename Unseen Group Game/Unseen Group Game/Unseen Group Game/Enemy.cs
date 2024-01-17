using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class Enemy : GameObject
    {
        // Fields:
        protected bool faceRight;
        protected int steps;
        protected int sleepTimer;
        protected Rectangle startingPosition;

        /// <summary>
        /// Property for the enemy's initial position
        /// </summary>
        public Rectangle StartingPosition { get { return startingPosition; } }

        /// <summary>
        /// Property for the number of steps the enemy has taken
        /// </summary>
        public int Steps { get { return steps; } set { steps = value; } }

        // Constructor:
        public Enemy(Texture2D png, int x, int y, int w, int h)
             : base(png, x, y, w, h)
        {
            startingPosition = new Rectangle(x, y, w, h);
            steps = 0;

            //start the enemy with a random sleep timer so they don't all move in sync
            Random rand = new Random();
            sleepTimer = rand.Next(1, 300);

            //and with a random facing value
            faceRight = Convert.ToBoolean(rand.Next(0, 2));
        }

        //constructor which takes a rectangle
        public Enemy(Texture2D png, Rectangle pos)
             : base(png, pos)
        {
            startingPosition = pos;
            steps = 0;

            //start the enemy with a random sleep timer so they don't all move in sync
            Random rand = new Random();
            sleepTimer = rand.Next(1, 300);

            //and with a random facing value
            faceRight = Convert.ToBoolean(rand.Next(0, 2));
        }


        // Methods:
        /// <summary>
        /// Moves the enemy back and forth in a set pattern
        /// </summary>
        public virtual void MoveEnemy()
        {
            if (sleepTimer > 0)
            {
                sleepTimer--;
                return;
            }

            if (faceRight)
            {
                steps += 1;

                if (steps <= 400)
                {
                    X += 1;
                }

                if (steps >= 600)
                {
                    faceRight = false;
                }
            }

            else if (!faceRight)
            {
                steps -= 1;

                if (steps >= 1)
                {
                    X -= 1;
                }


                if (steps <= -200)
                {
                    faceRight = true;
                }
            }
        }

        /// <summary>
        /// Checks wall collision
        /// </summary>
        /// <param name="walls"></param>
        public void WallCollision(List<GameObject> walls)
        {
            foreach (GameObject wall in walls)
            {
                if (Position.Intersects(wall.Position))
                {
                    Rectangle intersectRect = Rectangle.Intersect(position, wall.Position);

                    if (this.X <= wall.X)
                    {
                        this.X -= intersectRect.Width;
                        steps = 400;
                    }
                    //otherwise move them right
                    else if (this.X >= wall.X)
                    {
                        this.X += intersectRect.Width;
                        steps = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the enemy is touching the player object
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

        public void Draw(SpriteBatch sb, int currentFrame)
        {
            //draws the enemy in the direction they are facing
            if (sleepTimer > 0 || (faceRight && (steps>400 && steps<600)) || (!faceRight && (steps>-200 && steps < 1)))
            {
                currentFrame = 0;
            }
            if (!faceRight)
            {
                sb.Draw(base.texture, base.position,
                    new Rectangle(96 * currentFrame, 0, 96, 73),
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
            }
            else
            {
                sb.Draw(base.texture, base.position,
                    new Rectangle(96 * currentFrame, 0, 96, 73),
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            }
        }

    }
}
