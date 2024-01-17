using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    abstract class MenuScreen
    {
        //Fields
        private Texture2D[] textureArray; //Array of textures needed to draw menu
        private Texture2D testTexture; //White square for testing or drawing
        private Rectangle[] rectangles; //Positional rectangles to click

        //Constructor
        public MenuScreen(Texture2D testxture, Texture2D[] tArray)
        {
            TextureArray = tArray;
            TestTexture = testxture;
        }

        //Properties
        public Texture2D[] TextureArray { get => textureArray; private set => textureArray = value; }
        public Texture2D TestTexture { get => testTexture; private set => testTexture = value; }
        public Rectangle[] Rectangles { get => rectangles; set => rectangles = value; }

        //Methods
        /// <summary>
        /// Propertly updates the menu
        /// </summary>
        /// <param name="mouState">Mouse state</param>
        /// <param name="prevMouState">Previous mouse state</param>
        /// <param name="kbState">Keyboard state</param>
        /// <param name="prevKbState">Previous keyboard state</param>
        /// <returns>GameState to switch to after updating</returns>
        public abstract GameState Update(MouseState mouState, MouseState prevMouState, KeyboardState kbState, KeyboardState prevKbState);

        /// <summary>
        /// Properly draws the menu
        /// </summary>
        /// <param name="sb">Spritebatch</param>
        public abstract void Draw(SpriteBatch sb);

        /// <summary>
        /// Checks to see if the mouse is in an important area
        /// </summary>
        /// <returns>Returns which area the mouse is in</returns>
        public virtual int rectCollision()
        {
            for (int i = 0; i < Rectangles.Length; i++)
            {
                if (Rectangles[i].Contains(Mouse.GetState().Position))
                { //If the mouse is over a rectangle, return index
                    return i;
                }
            }
            return -1; //If mouse is not over rectangle, return -1
        }
    }
}
