using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class GameOverScreen : MenuScreen
    {

        //Constructor
        public GameOverScreen(Texture2D testxture, Texture2D[] textureArray) : base(testxture, textureArray)
        {
            base.Rectangles = new Rectangle[]
            {
                new Rectangle(0, 640, 1920, 140), //continue
                new Rectangle(0, 777, 1920, 140) //quit
            };

        }

        //Methods
        public override void Draw(SpriteBatch sb)
        {
            bool drawn = false;
            if(rectCollision() >= 0) //draws rectangles if colliding
            {
                sb.Draw(base.TextureArray[rectCollision()], new Rectangle(0, 0, 1920, 1080), Color.White);
                drawn = true;
            }
            if(!drawn) //draws default
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
                    case 0: //Continue
                        return GameState.InGame;
                    case 1: //Quit
                        return GameState.TitleMenu;
                }
            }
            return GameState.GameOver;
        }

        public override int rectCollision()
        {
            return base.rectCollision();
        }
    }
}
