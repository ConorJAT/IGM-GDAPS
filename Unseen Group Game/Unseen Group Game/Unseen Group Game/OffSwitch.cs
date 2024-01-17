using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class OffSwitch : GameObject
    {
        public Texture2D OnTexture { get; set; }
        public Texture2D OffTexture { get; set; }

        //constructor
        public OffSwitch(Texture2D onTexture, Texture2D offTexture, int x, int y, int w, int h) : base(onTexture, x, y, w, h)
        {
            OnTexture = onTexture;
            OffTexture = offTexture;
        }

        //constructor that takes a rectangle
        public OffSwitch(Texture2D onTexture, Texture2D offTexture, Rectangle pos) : base(onTexture, pos)
        {
            OnTexture = onTexture;
            OffTexture = offTexture;
        }

        public override bool Interact(Player interObject)
        {
            KeyboardState kb = Keyboard.GetState();

            if (Position.Intersects(interObject.Position) && (kb.IsKeyDown(Keys.E)))
            {
                return true;
            }

            return false;
        }

        public void ResetTexture()
        {
            texture = OnTexture;
        }

    }
}
