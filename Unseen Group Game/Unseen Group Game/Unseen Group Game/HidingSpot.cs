using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class HidingSpot : GameObject
    {

        public HidingSpot(Texture2D texture, int x, int y, int w, int h) : base(texture, x, y, w, h)
        {

        }
        //constructor that takes rectangle
        public HidingSpot(Texture2D texture, Rectangle pos) : base(texture, pos)
        {
            
        }

        public override bool Interact(Player interObject)
        {
            KeyboardState kb = Keyboard.GetState();

            if(Position.Intersects(interObject.Position) && (kb.IsKeyDown(Keys.E)))
            {
                return true;
            }

            return false;
        }
    }
}
