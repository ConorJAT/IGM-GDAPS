using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class Ladder : GameObject
    {
        //fields------------------------------------------------------------------------------------------------
        private bool climbUp;
        private int moveFactor;
        private bool wasInteracting;
        private bool isInteracting;


        //properties
        public bool ClimbUp { get { return climbUp; } }
        public bool IsInteracting { get { return isInteracting; } }


        //constructor-------------------------------------------------------------------------------------------
        public Ladder(Texture2D png, int x, int y, int w, int h, int moveFactor)
             : base(png, x, y, w, h)
        {
            this.moveFactor = moveFactor;
            isInteracting = false;
            wasInteracting = false;
            climbUp = true;
        }

        //constructor which takes a rectangle
        public Ladder(Texture2D png, Rectangle pos, int moveFactor)
             : base(png, pos)
        {
            this.moveFactor = moveFactor;
        }


        //methods----------------------------------------------------------------------------------------------

        public override bool Interact(Player interObject)
        {
            KeyboardState kb = Keyboard.GetState();

            //if (((Position.Intersects(interObject.Position) || (interObject.Y + interObject.Position.Height == Position.Y)) && kb.IsKeyDown(Keys.E)))
            if (((Position.Intersects(interObject.Position) || ((interObject.Y + interObject.Position.Height <= Position.Y) && ((interObject.X < Position.X + Position.Width) && (interObject.X >= Position.X))))))
            {
                isInteracting = true;
            }

            if (((interObject.Y + interObject.Position.Height) >= (Position.Y - 10))
                  && isInteracting && ((interObject.X < Position.X + Position.Width) && (interObject.X >= Position.X)))
            {
                if (((interObject.Y + interObject.Height) < (Position.Y + Position.Height)))
                {
                    if (((interObject.Y + interObject.Height) == (Position.Y + Position.Height - 2)) && !climbUp)
                    {
                        //the player is no longer interacting with the ladder
                        isInteracting = false;
                        //but they were interacting with the ladder
                        wasInteracting = true;
                    }
                    else
                    {
                        //they are currently interacting with the ladder
                        isInteracting = true;
                        //they were also interacting with the ladder at some point
                        wasInteracting = true;
                    }
                }


            }
            else
            {
                isInteracting = false;
            }


            if (isInteracting)
            {
                return true;
            }
            else
            {
                //if the player was once on the ladder but not anymore...
                if (wasInteracting)
                {
                    MakePlayerTouchTheGround(interObject);
                }

                return false;
            }

        }

        /// <summary>
        /// makes the player properly touch the ground after climbing up or down a ladder
        /// </summary>
        /// <param name="interObject"></param>
        public void MakePlayerTouchTheGround(Player interObject)
        {
            if (wasInteracting && (!Position.Intersects(interObject.Position)) && climbUp) // if they climbed up the ladder...
            {
                interObject.Y = Position.Y - interObject.Height + 1;
            }
            else if (wasInteracting && (!climbUp) && (!isInteracting)) // if they climbed down the ladder...
            {
                interObject.Y = (Position.Y + Position.Height) - interObject.Position.Height - 5;
            }

            wasInteracting = false;
        }

        /// <summary>
        /// Moves the player on the ladder
        /// </summary>
        /// <param name="interObject"></param>
        public void MoveOnLadder(Player interObject)
        {
            if (Interact(interObject))
            {
                //moves the player in the Y direction depending on what keys are pressed
                KeyboardState kb = Keyboard.GetState();
                if (kb.IsKeyDown(Keys.W))
                {
                    climbUp = true;
                    interObject.Y -= moveFactor;
                }
                if (kb.IsKeyDown(Keys.S))
                {
                    climbUp = false;
                    interObject.Y += moveFactor;
                }
            }

        }

    }
}