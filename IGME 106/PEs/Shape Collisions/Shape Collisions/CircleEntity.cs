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
    class CircleEntity
    {
        protected Texture2D circle;
        protected Vector2 center;
        protected int radius;

        /// <summary>
        /// Instantiates a new CircleEntity object with an associated Vector2
        /// object and texture.
        /// </summary>
        /// <param name="image"> Passed in Texture2D object. </param>
        /// <param name="xCent"> X-Position of circle's center. </param>
        /// <param name="yCent"> Y-Position of circle's center. </param>
        /// <param name="rad"> Radius of the circle. </param>
        public CircleEntity(Texture2D image, int xCent, int yCent, int rad)
        {
            circle = image;
            center = new Vector2(xCent, yCent);
            radius = rad;
        }

        /// <summary>
        /// Gets / Sets the circle's x-position.
        /// </summary>
        public int X { get { return (int)center.X; } set { center.X = value; } }

        /// <summary>
        /// Gets / Sets the circle's y-position.
        /// </summary>
        public int Y { get { return (int)center.Y; } set { center.Y = value; } }

        /// <summary>
        /// Gets / Sets the circle's radius.
        /// </summary>
        public int Radius { get { return radius; } set { radius = value; } }

        /// <summary>
        /// Checks whether or not two CircleEntity objects are intersecting.
        /// </summary>
        /// <param name="other"> Secondary circle entity being compared for intersection. </param>
        /// <returns> True, if the two objects intersect. False, if not. </returns>
        public bool Intersects(CircleEntity other)
        {
            if (Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) < Math.Pow(radius + other.Radius, 2))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the CircleEntity object to the window.
        /// </summary>
        public void Draw (SpriteBatch sb, Color tint)
        {
            sb.Draw(circle, new Rectangle(X-radius, Y-radius, 2*radius, 2*radius), tint);
        }
    }
}
