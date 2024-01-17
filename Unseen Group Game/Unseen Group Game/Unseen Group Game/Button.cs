using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class Button
    {
        // Fields:
        protected Texture2D texture;
        protected Rectangle position;

        // Constructor:
        public Button(Texture2D png, int x, int y, int w, int h)
        {
            texture = png;
            position = new Rectangle(x, y, w, h);
        }


        //Methods:
        public bool ClickButton(MouseState ms)
        {
            if ((ms.X >= position.X && ms.X <= position.Width) &&
                (ms.Y >= position.Y && ms.Y <= position.Height) &&
                ms.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }


        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }
    }
}
