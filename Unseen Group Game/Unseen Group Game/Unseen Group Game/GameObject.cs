using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Unseen_Group_Game
{
    class GameObject
    {
        // Fields:
        protected Texture2D texture;
        protected Rectangle position;

        // Constructor:
        public GameObject(Texture2D png, int x, int y, int w, int h)
        {
            texture = png;
            position = new Rectangle(x, y, w, h);
        }

        //constructor which takes rectangle:
        public GameObject(Texture2D png, Rectangle pos)
        {
            texture = png;
            position = pos;
        }


        // Properties:
        public int X { get { return position.X; } set { position.X = value; } }


        public int Y { get { return position.Y; } set { position.Y = value; } }


        public int Width { get { return position.Width; } }


        public int Height { get { return position.Height; } set { position.Height = value; } }


        public Rectangle Position { get { return new Rectangle(X, Y, Width, Height); } set{ position = value; } }

        public Texture2D Texture { get { return texture; } set { texture = value; } }


        // Methods:
        /// <summary>
        /// Checks if the object is intersecting the player
        /// </summary>
        /// <param name="interObject"></param>
        /// <returns></returns>
        public virtual bool Interact(Player interObject)
        {
            if (position.Intersects(interObject.Position))
            {
                return true;
            }
            return false;
        }

        //draws the object
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

    }
}
