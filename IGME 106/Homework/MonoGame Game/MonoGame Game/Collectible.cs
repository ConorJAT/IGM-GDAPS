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
    class Collectible : GameObject
    {
        protected bool isActive;

        /// <summary>
        /// Child class constructor that extends from the GameObject class. Particularly,
        /// this class covers an individual collectibe object.
        /// </summary>
        /// <param name="png"> 2D Texture of collectible. </param>
        /// <param name="x"> X-Position of the collectible. </param>
        /// <param name="y"> Y-Position of the collectible. </param>
        /// <param name="w"> Width of collectible's rectangle. </param>
        /// <param name="h"> Height of the collectible's rectangle. </param>
        public Collectible(Texture2D png, int x, int y, int w, int h)
               : base(png, x, y, w, h)
        {
            isActive = true;
        }

        /// <summary>
        /// Property; Allows for the get / set of the collectible's active state.
        /// </summary>
        public bool Activate { get { return isActive; } set { isActive = value; } }

        /// <summary>
        /// Custom draw statement for the invidual collectible. Calls base method from parent.
        /// (Will only draw if the collectible is active).
        /// </summary>
        /// <param name="sb"> Passed in SpriteBatch object. </param>
        public override void Draw(SpriteBatch sb)
        {
            if (isActive)
            {
                base.Draw(sb);
            }
        }

        /// <summary>
        /// Checks for collisions with other objects, specifically that with Player objects.
        /// (Player can only collide with collectibles that are active).
        /// </summary>
        /// <param name="check"> GameObject to be checked for collisions. </param>
        /// <returns> True, if there was a collision. False, otherwise. </returns>
        public bool CheckCollision(GameObject check)
        {
            if (this.position.Intersects(check.Position))
            {
                if (isActive)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
