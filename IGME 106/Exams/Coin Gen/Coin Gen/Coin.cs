// Conor Race
// GDAPS II - Midterm Exam Practical
// Feb. 21st, 2022

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coin_Gen
{
    class Coin
    {
        Texture2D coin;
        Rectangle position;

        /// <summary>
        /// Get / set coin's position in x-direction.
        /// </summary>
        public int X { get { return position.X; } set { position.X = value; } }

        /// <summary>
        /// Get / set coin's position in y-direction.
        /// </summary>
        public int Y { get { return position.Y; } set { position.Y = value; } }

        /// <summary>
        /// Generates a new coin object.
        /// </summary>
        /// <param name="png"> Sprite used for coin when drawing. </param>
        /// <param name="x"> X-Position of coin. </param>
        /// <param name="y"> Y-Position of coin. </param>
        /// <param name="w"> Width of the coin. </param>
        /// <param name="h"> Height of the coin. </param>
        public Coin(Texture2D png, int x, int y, int w, int h)
        {
            coin = png;
            position = new Rectangle(x, y, w, h);
        }

        /// <summary>
        /// Constantly checks is the mouse is hovering over a coin.
        /// </summary>
        /// <returns> True is the mouse is over a coin. False, otherwise. </returns>
        public bool MouseOver()
        {
            if ((Mouse.GetState().X >= X && Mouse.GetState().X <= X + position.Width) &&
                (Mouse.GetState().Y >= Y && Mouse.GetState().Y <= Y + position.Height))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the coin to the screen. Tinted red if the mouse is hovering over it.
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            if (MouseOver())
            {
                sb.Draw(coin, position, Color.Red);
            }
            else
            {
                sb.Draw(coin, position, Color.White);
            }
        }
    }
}
