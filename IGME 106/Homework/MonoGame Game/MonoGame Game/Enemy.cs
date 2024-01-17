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
    class Enemy : GameObject
    {
        /// <summary>
        /// Child class constructor that extends from the GameObject class. Particularly,
        /// this class covers the individual enemy objects.
        /// </summary>
        /// <param name="png"> 2D Texture of enemy. </param>
        /// <param name="x"> X-Position of the enemy. </param>
        /// <param name="y"> Y-Position of the enemy. </param>
        /// <param name="w"> Width of enemy's rectangle. </param>
        /// <param name="h"> Height of the enemy's rectangle. </param>
        public Enemy(Texture2D png, int x, int y, int w, int h)
               : base(png, x, y, w, h) { }

        /// <summary>
        /// Checks for collisions with other objects, specifically that with Player objects.
        /// </summary>
        /// <param name="check"> GameObject to be checked for collisions. </param>
        /// <returns> True, if there was a collision. False, otherwise. </returns>
        public bool CheckCollision(GameObject check)
        {
            if (this.position.Intersects(check.Position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Custom draw statement for the invidual enemy. Calls base method from parent.
        /// </summary>
        /// <param name="sb"> Passed in SpriteBatch object. </param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
