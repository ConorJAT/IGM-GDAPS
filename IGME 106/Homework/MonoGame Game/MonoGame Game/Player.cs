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
    class Player : GameObject
    {
        protected int lvlScore;
        protected int ttlScore;

        /// <summary>
        /// Child class constructor that extends from the GameObject class. Particularly,
        /// this class covers the individual player object.
        /// </summary>
        /// <param name="png"> 2D Texture of player. </param>
        /// <param name="x"> X-Position of the player. </param>
        /// <param name="y"> Y-Position of the player. </param>
        /// <param name="w"> Width of player's rectangle. </param>
        /// <param name="h"> Height of the player's rectangle. </param>
        public Player(Texture2D png, int x, int y, int w, int h)
               : base(png, x, y, w, h)
        {
            lvlScore = 0;
            ttlScore = 0;
        }

        /// <summary>
        /// Property; Allows for the get / set of the player's individual level score.
        /// </summary>
        public int Level { get { return lvlScore; } set { lvlScore = value; } }

        /// <summary>
        /// Property; Allows for the get / set of the player's total score.
        /// </summary>
        public int Total { get { return ttlScore; } set { ttlScore = value; } }

        /// <summary>
        /// Custom draw statement for the invidual player. Calls base method from parent.
        /// </summary>
        /// <param name="sb"> Passed in SpriteBatch object. </param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
