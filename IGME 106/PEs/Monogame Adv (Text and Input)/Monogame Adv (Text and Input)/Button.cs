using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Adv__Text_and_Input_
{
    class Button
    {
        private Texture2D defButton;
        private Texture2D hoverButton;
        private Rectangle position;

        /// <summary>
        /// Constructor for button class.
        /// </summary>
        /// <param name="bttn1"> Texture for button in rest position. </param>
        /// <param name="bttn2"> Texture for button in hover position. </param>
        /// <param name="location"> Location and sizing of textures, when drawn. </param>
        public Button(Texture2D bttn1, Texture2D bttn2, Rectangle location)
        {
            defButton = bttn1;
            hoverButton = bttn2;
            position = location;
        }

        /// <summary>
        /// Draws a differing texture based on the mouse's position with the button (rectangle).
        /// </summary>
        /// <param name="sb"> SpriteBatch from Game1. </param>
        public void Draw(SpriteBatch sb)
        {
            MouseState ms = Mouse.GetState();

            if ((ms.X > position.X && ms.X < (position.X + position.Width)) &&
                (ms.Y > position.Y && ms.Y < (position.Y + position.Height)))
            {
                sb.Draw(hoverButton, position, Color.White);
            }
            else
            {
                sb.Draw(defButton, position, Color.White);
            }
        }
    }
}
