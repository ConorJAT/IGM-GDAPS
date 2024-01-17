// Conor Race
// Feb. 15th, 2022
// IGME.106.07

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace MonoGame_Game
{
    // Enumeration of the core gamestates that dictate the game:
    public enum GameState
    {
        StartScreen,
        InGame,
        GameOver
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Variables regarding any and all textures in use for the game:
        private Texture2D nickWilde;
        private Texture2D pawpsicle;
        private Texture2D chiefBogo;

        // Variables regarding any and all text fonts in use for the game:
        private SpriteFont gothic24;
        private SpriteFont gothicTitle;

        // Variable regarding the game's current GameState:
        private GameState state;

        // Variables regarding any and all in game elements (player, items, enemies, timer, etc):
        private Player nick;
        private Enemy cop1;
        private Enemy cop2;
        private Enemy cop3;
        private Enemy cop4;
        private List<Collectible> items;
        private int lvlCount;
        private double timer;
        private KeyboardState prevKB;

        // Variable regarding the RNG used mainly for collectible generation:
        private Random rng;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // Resizing the window:
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            state = GameState.StartScreen;

            timer = 10.0;
            lvlCount = 0;

            rng = new Random();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading in all textures from files located in Content:
            nickWilde = Content.Load<Texture2D>("nick_wilde");
            pawpsicle = Content.Load<Texture2D>("pawpsicle");
            chiefBogo = Content.Load<Texture2D>("chief_bogo");

            // Loading in all text fonts from files located in Content:
            gothic24 = Content.Load<SpriteFont>("FranklinGothic24");
            gothicTitle = Content.Load<SpriteFont>("FranklinGothicTitle");

            // Instantiation of player and enemy objects, along the list collectibles:
            nick = new Player(nickWilde, 490, 285, 100, 150);
            cop1 = new Enemy(chiefBogo, 300, 0, 100, 200);
            cop2 = new Enemy(chiefBogo, 680, 520, 100, 200);
            cop3 = new Enemy(chiefBogo, 250, 60, 100, 200);
            cop4 = new Enemy(chiefBogo, 730, 460, 100, 200);
            items = new List<Collectible>();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // FSM regarding the variaous logic present in different states:
            switch (state)
            {
                // When the game is on StartScreen...
                case GameState.StartScreen:

                    // Reset the game and switch to InGame when 'Enter' is pressed once:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        ResetGame();
                        state = GameState.InGame;
                    }
                    break;


                // When the game is on InGame...
                case GameState.InGame:
                    
                    // Subtract the appropriate amount of time from the timer:
                    timer -= gameTime.ElapsedGameTime.TotalSeconds;

                    // Move the player and allow the player to wrap around the screen:
                    MovePlayer();
                    ScreenWrap(nick);

                    // Move all enemies and allow them to wrap around the screen:
                    cop1.Y += 3;
                    cop2.Y -= 3;
                    cop3.X -= 3;
                    cop4.X += 3;
                    ScreenWrap(cop1);
                    ScreenWrap(cop2);
                    ScreenWrap(cop3);
                    ScreenWrap(cop4);

                    // Checking for each item to see if the player makes contact with them:
                    for (int i = 0; i < items.Count; i++)
                    {
                        // If the player grabs the object, award the player 10 points and deactivate the item:
                        if (items[i].CheckCollision(nick))
                        {
                            nick.Level += 10;
                            nick.Total += 10;
                            items[i].Activate = false;
                        }
                    }

                    // If the timer runs out, switch game state to GameOver:
                    if (timer <= 0.0)
                    {
                        state = GameState.GameOver;
                    }
                    // If at any point the player touches an enemy while they're on screen, switch gam state to GameOver:
                    else if (lvlCount >= 3)
                    {
                        if (cop1.CheckCollision(nick)) { state = GameState.GameOver; }
                        if (cop2.CheckCollision(nick)) { state = GameState.GameOver; }

                        if (lvlCount >= 7)
                        {
                            if (cop3.CheckCollision(nick)) { state = GameState.GameOver; }
                            if (cop4.CheckCollision(nick)) { state = GameState.GameOver; }
                        }
                    }
                    
                    // If all items have been collected in a level, proceed to the next level:
                    if (CheckItems())
                    {
                        NextLevel();
                    }
                    break;


                // When the game is on GameOver...
                case GameState.GameOver:

                    // Return to start menu and switch to StartScreen when 'Enter' is pressed once:
                    if (SingleKeyPress(Keys.Enter))
                    { 
                        ResetGame();
                        state = GameState.StartScreen;
                    }
                    break;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // FSM regarding the variaous drawing present in different states:
            switch (state)
            {
                // When the game is on StartScreen..
                case GameState.StartScreen:

                    // Draw strings in order to create a menu screen with a title and rules:
                    _spriteBatch.DrawString(gothicTitle, "Pawpsicle Hustle!", new Vector2(60, 60), Color.White);
                    _spriteBatch.DrawString(gothic24, $"Rules: Collect pawpsicles and avoid getting", new Vector2(60, 160), Color.White);
                    _spriteBatch.DrawString(gothic24, $"captued by the cops before time runs out!", new Vector2(60, 200), Color.White);
                    _spriteBatch.DrawString(gothic24, $"(Press \'Enter\' to begin game)", new Vector2(60, 280), Color.White);
                    break;


                // When the game is on InGame...
                case GameState.InGame:

                    // Draw in all items to be collected:
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].Draw(_spriteBatch);
                    }

                    // Draw in the player:
                    nick.Draw(_spriteBatch);

                    // Draw in the enemies accordingly based on level count:
                    if (lvlCount >= 3)
                    {
                        cop1.Draw(_spriteBatch);
                        cop2.Draw(_spriteBatch);

                        if (lvlCount >= 7)
                        {
                            cop3.Draw(_spriteBatch);
                            cop4.Draw(_spriteBatch);
                        }
                    }

                    // Draw strings in order to display player stats (level, level score and time):
                    _spriteBatch.DrawString(gothic24, $"Level {lvlCount}", new Vector2(20, 20), Color.White);
                    _spriteBatch.DrawString(gothic24, $"Level Score: {nick.Level}", new Vector2(20, 60), Color.White);
                    _spriteBatch.DrawString(gothic24, $"Time Left: {String.Format("{0:0.00}", timer)}", new Vector2(20, 100), Color.White);
                    break;


                // When the game is on GameOver...
                case GameState.GameOver:

                    // Draw strings order to notify of player failure, as well as the player's final score and level:
                    _spriteBatch.DrawString(gothicTitle, "Game Over!", new Vector2(60, 60), Color.White);
                    _spriteBatch.DrawString(gothic24, $"Total Score: {nick.Total}", new Vector2(60, 140), Color.White);
                    _spriteBatch.DrawString(gothic24, $"Highest Level: {lvlCount}", new Vector2(60, 180), Color.White);
                    _spriteBatch.DrawString(gothic24, $"(Press \'Enter\' to return to the Start Screen)", new Vector2(60, 600), Color.White);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        /// <summary>
        /// Resets a series of variables to prepare for every new level.
        /// </summary>
        public void NextLevel()
        {
            // Increase the level count by 1:
            lvlCount++;

            // Reset timer accordingly based on the level count:
            timer = 10.0;
            if (lvlCount >= 3)
            {
                timer = 15.0;
                if(lvlCount >= 7)
                {
                    timer = 20.0;
                }
            }

            // Set the level score to 0:
            nick.Level = 0;

            // Reset player position to the center of the map:
            nick.X = 490;
            nick.Y = 285;

            // Create a new list of items for the user to collect:
            items.Clear();
            for (int i = 0; i < 5 + (3 * (lvlCount - 1)); i++)
            {
                items.Add(new Collectible(pawpsicle, rng.Next(0, 1001), rng.Next(0, 661), 60, 60));
            }
        }


        /// <summary>
        /// Resets the game whenever the user moves past the StartScreen state.
        /// </summary>
        public void ResetGame()
        {
            // Reset level count to 0:
            lvlCount = 0;

            // Reset total score to 0:
            nick.Total = 0;

            // Call NextLevel() to prepare the first level:
            NextLevel();
        }


        /// <summary>
        /// Whenever the player or enemies move completely of screen, allow them to
        /// return, coming from the opposite side.
        /// </summary>
        /// <param name="toWrap"> Object which is allowed the 'wrap' motion. </param>
        void ScreenWrap(GameObject toWrap)
        {
            // Moving beyond the left edge and resets at the right:
            if (toWrap.X >= 1080)
            {
                toWrap.X = -toWrap.Position.Width;
            }
            // Moving beyond the right edge and resets at the left:
            else if (toWrap.X <= -toWrap.Position.Width)
            {
                toWrap.X = 1080;
            }

            // Moving beyond the bottom edge and resets at the top:
            if (toWrap.Y >= 720)
            {
                toWrap.Y = -toWrap.Position.Height;
            }
            // Mvoing beyond the top edge andd resets at the bottom:
            else if (toWrap.Y <= -toWrap.Position.Height)
            {
                toWrap.Y = 720;
            }
        }


        /// <summary>
        /// Checks for the presence of a single key press from a designated key:
        /// </summary>
        /// <param name="key"> Desired key to be checked if pressed. </param>
        /// <returns> True, if the key was pressed once. False, otherwise. </returns>
        public bool SingleKeyPress(Keys key)
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(key) && prevKB.IsKeyUp(key))
            {
                prevKB = kb;
                return true;
            }

            prevKB = kb;
            return false;
        }


        /// <summary>
        /// Moves the player aoccrdingly based on which of the 4 keys are pressed:
        /// </summary>
        public void MovePlayer()
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.A)) { nick.X -= 5; }
            if (kb.IsKeyDown(Keys.D)) { nick.X += 5; }
            if (kb.IsKeyDown(Keys.W)) { nick.Y -= 5; }
            if (kb.IsKeyDown(Keys.S)) { nick.Y += 5; }

            prevKB = kb;
        }


        /// <summary>
        /// Checks whether all items have been collected in the level or not:
        /// </summary>
        /// <returns> True if all items have been collected. False, otherwise. </returns>
        public bool CheckItems()
        {   
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Activate)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
