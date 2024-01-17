using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class Vent: GameObject
    {
        public Vent ConnectingVent { get; set; }

        public Vent(Texture2D png, int x, int y, int w, int h) : base (png, x, y, w, h)
        {
        }

        public Vent(Texture2D png, Rectangle pos) : base(png, pos)
        {
        }

        public override bool Interact(Player interObject)
        {
            KeyboardState kb = Keyboard.GetState();

            if (Position.Intersects(interObject.Position) && kb.IsKeyDown(Keys.E))
            {
                return true;
            }

            return false;
        }
    }
}
