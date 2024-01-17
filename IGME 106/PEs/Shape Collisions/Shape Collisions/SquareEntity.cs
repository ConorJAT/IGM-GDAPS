// Conor Race
// Feb 11th, 2022
// IGME.106.07

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shape_Collisions
{
    class SquareEntity
    {
        protected Texture2D rect;
        protected Rectangle rectPos;

        /// <summary>
        /// Instantiates a SquareEntity object with an associated texture and
        /// Rectangle object.
        /// </summary>
        /// <param name="image"> Passed in Texture2D object. </param>
        /// <param name="xPos"> X-Position of rectangle. </param>
        /// <param name="yPos"> Y-Position of rectangle. </param>
        /// <param name="width"> Width of rectangle. </param>
        /// <param name="height"> Height of rectangle. </param>
        public SquareEntity(Texture2D image, int xPos, int yPos, int width, int height)
        {
            rect = image;
            rectPos = new Rectangle(xPos, yPos, width, height);
        }

        /// <summary>
        /// Gets / Sets the rectangle's x-position.
        /// </summary>
        public int X { get { return rectPos.X; } set { rectPos.X = value; } }

        /// <summary>
        /// Gets / Sets the rectangle's y-position.
        /// </summary>
        public int Y { get { return rectPos.Y; } set { rectPos.Y = value; } }

        /// <summary>
        /// Gets / Sets the rectangle's width.
        /// </summary>
        public int Width { get { return rectPos.Width; } }

        /// <summary>
        /// Gets / Sets the rectangle's height.
        /// </summary>
        public int Height { get { return rectPos.Height; } }

        /// <summary>
        /// Checks whether or not two SquareEntity objects are intersecting.
        /// </summary>
        /// <param name="other"> Secondary square entity being compared for intersection. </param>
        /// <returns> True, if the two objects intersect. False, if not. </returns>
        public bool Intersects(SquareEntity other)
        {
            if (rectPos.Intersects(new Rectangle(other.X, other.Y, other.Width, other.Height)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the SquareEntity object to the window.
        /// </summary>
        public void Draw(SpriteBatch sb, Color tint)
        {
            sb.Draw(rect, rectPos, tint);
        }
    }
}
