using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Unseen_Group_Game
{
    class PauseMenu : MenuScreen
    {
        //Contructor
        public PauseMenu(Texture2D testxture, Texture2D[] textureArray)
            : base(testxture, textureArray)
        {
            base.Rectangles = new Rectangle[] {
            new Rectangle(0,206,854,189), //Load checkpoint
            new Rectangle(0,396,806,189), //Controls
            new Rectangle(0,595,756,189), //Credits
            new Rectangle(0,780,710,189)}; //Quit to title
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
                sb.Draw(base.TextureArray[4], new Rectangle(0, 0, 1920, 1080), Color.White);
            }
        }

        public override GameState Update(MouseState mouState, MouseState prevMouState, KeyboardState kbState, KeyboardState prevKbState)
        {
            if (mouState.LeftButton == ButtonState.Pressed && prevMouState.LeftButton == ButtonState.Released)
            {
                switch (rectCollision())
                {
                    case 0: //Load checkpoint
                        return GameState.GameOver; //This doesn't actually go to GameOver screen it's just so Game1 knows what to do
                    case 1: //Controls
                        return GameState.ControlMenu;
                    case 2: //Credits
                        return GameState.Credits;
                    case 3: //Quit to title
                        return GameState.TitleMenu;
                }
            }
            if (kbState.IsKeyDown(Keys.Escape) && prevKbState.IsKeyUp(Keys.Escape))
            { //Switch to in game on escape
                return GameState.InGame;
            }
            return GameState.PauseMenu;
        }
        public override int rectCollision()
        {
            return base.rectCollision();
        }
    }
}
