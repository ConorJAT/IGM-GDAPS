// Conor Race
// GDAPS II - Midterm Exam Practical
// Feb. 21st, 2022

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Coin_Gen
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D coin;
        private SpriteFont TNR24;

        private List<Coin> myCoins;
        private MouseState prevMS;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading in of coin texture:
            coin = Content.Load<Texture2D>("coin");

            // Loading in of font sprite:
            TNR24 = Content.Load<SpriteFont>("TNR24");

            // Declaration for list to hold coin objects:
            myCoins = new List<Coin>();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Used to keep track of mouse states:
            MouseState ms = Mouse.GetState();
            
            // When adding coins:
            if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton == ButtonState.Released)
            {
                // If there are already 10 coins on screen, delete oldest and add new one:
                if (myCoins.Count == 10)
                {
                    myCoins.RemoveAt(0);
                    myCoins.Add(new Coin(coin, Mouse.GetState().X - 40, Mouse.GetState().Y - 48, 80, 96));
                }
                // Else, just add a coin to the screen:
                else
                {
                    myCoins.Add(new Coin(coin, Mouse.GetState().X - 40, Mouse.GetState().Y - 48, 80, 96));
                }
            }

            // Wehn deleting coins:
            for (int i = 0; i < myCoins.Count; i++)
            {
                if(myCoins[i].MouseOver() && ms.RightButton == ButtonState.Pressed && prevMS.RightButton == ButtonState.Released)
                {
                    myCoins.RemoveAt(i);
                    i--;
                }
            }

            // Keeping track of previous mouse state:
            prevMS = ms;
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();

            // Draw all coins to the screen:
            for (int i = 0; i < myCoins.Count; i++)
            {
                myCoins[i].Draw(_spriteBatch);
            }

            // Draw the rules and coin count to screen:
            _spriteBatch.DrawString(TNR24, "Click anywhere to add a coin!", new Vector2(20, 20), Color.White);
            _spriteBatch.DrawString(TNR24, "Right click a coin to remove it!", new Vector2(20, 60), Color.White);
            _spriteBatch.DrawString(TNR24, "Total Coins: " + myCoins.Count, new Vector2(20, 100), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
