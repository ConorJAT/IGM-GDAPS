using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class DogEnemy : Enemy
    {
        // faceRight boolean is a little awkward in this class b/c sprite starts off facing right.

        private Rectangle sightLine;
        private bool isChasing;

        // Constructor:
        public DogEnemy(Texture2D png, int x, int y, int w, int h)
             : base(png, x, y, w, h)
        {
            faceRight = true;
            sightLine = new Rectangle(X - 1000, Y, 1000, 10);
            isChasing = false;
        }

        // Constructor (Takes rectangle instead of values):
        public DogEnemy(Texture2D png, Rectangle pos)
             : base(png, pos)
        {
            faceRight = true;
            sightLine = new Rectangle(X - 1000, Y, 1000, 10);
            isChasing = false;

        }


        // Methods:
        /// <summary>
        /// Moves the dog back and forth in a set pattern (faster speed than noraml enemy
        /// and dogs will NOT sleep):
        /// </summary>
        public void MoveDog(Player player)
        {
            SeesPlayer(player);

            if (isChasing)
            {
                Chase(player);
            }

            else if (faceRight)
            {
                steps += 5;

                if (steps <= 200)
                {
                    X += 5;
                    sightLine.X += 5;
                }

                if (steps >= 300)
                {
                    faceRight = false;
                    sightLine = new Rectangle(X - 1000, Y, 1000, 10);
                }
            }

            else if (!faceRight)
            {
                steps -= 5;

                if (steps >= 1)
                {
                    X -= 5;
                    sightLine.X -= 5;
                }

                if (steps <= -100)
                {
                    faceRight = true;
                    sightLine = new Rectangle(X + Width, Y, 1000, 10);
                }
            }
        }

        /// <summary>
        /// Checks wall collision specifically for dogs
        /// </summary>
        /// <param name="walls"></param>
        public void DogWallCollision(List<GameObject> walls)
        {
            foreach (GameObject wall in walls)
            {
                if (Position.Intersects(wall.Position))
                {
                    Rectangle intersectRect = Rectangle.Intersect(position, wall.Position);

                    if (this.X <= wall.X)
                    {
                        this.X -= intersectRect.Width;
                        steps = 200;
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

        public bool SeesPlayer(Player player)
        {
            if (sightLine.Intersects(player.Position))
            {
                isChasing = true;
                return true;
            }

            return false;
        }


        public void Chase(Player player)
        {
            if (isChasing)
            {
                if (SeesPlayer(player) && faceRight && !player.IsHidden)
                {
                    X += 6;
                    sightLine.X += 6;
                }

                else if (SeesPlayer(player) && !faceRight  && !player.IsHidden)
                {
                    X -= 6;
                    sightLine.X -= 6;
                }

                else if (!SeesPlayer(player) || player.IsHidden)
                {
                    if (X == startingPosition.X)
                    {
                        isChasing = false;
                        faceRight = true;
                        steps = 0;
                    }
                    
                    else if (startingPosition.X > X)
                    {
                        faceRight = true;
                        sightLine = new Rectangle(X + Width, Y, 1000, 10);
                        X += 5;
                    }

                    else if (startingPosition.X < X)
                    {
                        faceRight = false;
                        sightLine = new Rectangle(X - 1000, Y, 1000, 10);
                        X -= 5;
                    }
                }
            }  
        }


        /// <summary>
        /// Checks if the dog is touching the player object
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
            if (!isChasing && ((faceRight && (steps > 200 && steps < 300)) || (!faceRight && (steps < 1 && steps > -100))))
            {
                currentFrame = 0;
            }
            if( isChasing && X == startingPosition.X)
            {
                currentFrame = 0;
            }

            if (!faceRight)
            {
                sb.Draw(base.texture, base.position,
                    new Rectangle(62 * currentFrame, 0, 62, 44),
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                sb.Draw(base.texture, base.position,
                    new Rectangle(62 * currentFrame, 0, 62, 44),
                    Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
            }
        }
    }
}
