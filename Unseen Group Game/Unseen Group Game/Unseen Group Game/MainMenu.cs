using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class MainMenu : MenuScreen
    {

        //Constructor
        public MainMenu(Texture2D testxture, Texture2D[] textureArray)
            : base(testxture, textureArray)
        {
            base.Rectangles = new Rectangle[] {
                new Rectangle(0, 184, 680, 152), //New game
                new Rectangle(0, 345, 642, 152),  //Continue
                new Rectangle(0,501,585,152), //How to play
                new Rectangle(0,688,536,152), //Credits
                new Rectangle(0,874,499,152)}; //Quit
        }

        //Methods
        public override void Draw(SpriteBatch sb)
        {
            Boolean drawn = false;
            if (rectCollision() >= 0)
            { //If mouse is over a rectangle, draw appropriately
                sb.Draw(base.TextureArray[rectCollision()], new Rectangle(0, 0, 1920, 1080), Color.White);
                drawn = true;
            }
            if (!drawn)
            { //If mouse isn't over any rectangles, draw default
                sb.Draw(base.TextureArray[5], new Rectangle(0, 0, 1920, 1080), Color.White);
            }
        }

        public override GameState Update(MouseState mouState, MouseState prevMouState, KeyboardState kbState, KeyboardState prevKbState)
        {
            if (mouState.LeftButton == ButtonState.Pressed && prevMouState.LeftButton == ButtonState.Released)
            {
                switch (rectCollision())
                {
                    case 0: //New Game
                        return GameState.InGame;
                    case 1: //Continue Game
                        return GameState.GameOver;
                    case 2: //How to Play
                        return GameState.ControlMenu;
                    case 3: //Credits
                        return GameState.Credits;
                    case 4: //Quit
                        return GameState.Quit;
                }
            }
            return GameState.TitleMenu;
        }

        public override int rectCollision()
        {
            return base.rectCollision();
        }
    }
}
