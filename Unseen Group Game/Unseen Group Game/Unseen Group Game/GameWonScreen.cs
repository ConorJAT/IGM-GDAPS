using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class GameWonScreen : MenuScreen
    {
        Texture2D textr;
        public GameWonScreen(Texture2D texture, Texture2D[] textures) : base (texture, textures)
        {
            textr = texture;
            base.Rectangles = new Rectangle[]
            {
                new Rectangle(500, 775, 875, 138)
            };
        }

        //Methods
        public override void Draw(SpriteBatch sb)
        {
            bool drawn = false;
            if (rectCollision() >= 0) //draws rectangles if colliding
            {
                sb.Draw(base.TextureArray[rectCollision() + 1], new Rectangle(0, 0, 1920, 1080), Color.White);
                drawn = true;
            }
            if (!drawn) //draws default
            {
                sb.Draw(base.TextureArray[0], new Rectangle(0, 0, 1920, 1080), Color.White);
            }
        }

        public override GameState Update(MouseState mouState, MouseState prevMouState, KeyboardState kbState, KeyboardState prevKbState)
        {
            if (mouState.LeftButton == ButtonState.Pressed && prevMouState.LeftButton == ButtonState.Released)
            {
                switch (rectCollision())
                {
                    case 0: //Exit to title
                        return GameState.TitleMenu;
                }
            }
            return GameState.GameWon;
        }

        public override int rectCollision()
        {
            return base.rectCollision();
        }
    }
}
