// Conor Race
// Feb. 15th, 2022
// IGME.106.07

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Game
{
    class GameObject
    {
        protected Texture2D image;
        protected Rectangle position;

        /// <summary>
        /// Constructor for all subsequent child classes in this program. Creates a game
        /// object with a 2D Texture and a rectangle.
        /// </summary>
        /// <param name="png"> 2D Texture of object. </param>
        /// <param name="x"> X-Position of the object. </param>
        /// <param name="y"> Y-Position of the object. </param>
        /// <param name="width"> Width of object's rectangle. </param>
        /// <param name="height"> Height of the object's rectangle. </param>
        public GameObject(Texture2D png, int x, int y, int width, int height)
        {
            image = png;
            position = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Property; Allows for the get / set of the object's X-Position.
        /// </summary>
        public int X { get { return position.X; } set { position.X = value; } }
        
        /// <summary>
        /// Property; Allows for the get / set of the object's Y-Position.
        /// </summary>
        public int Y { get { return position.Y; } set { position.Y = value; } }

        /// <summary>
        /// Property; Allows for the get ONLY of the object's Rectangle (for width and height).
        /// </summary>
        public Rectangle Position { get { return position; } }

        /// <summary>
        /// Custom draw statement for the invidual object.
        /// </summary>
        /// <param name="sb"> Passed in SpriteBatch object. </param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(image, position, Color.White);
        }
    }
}
