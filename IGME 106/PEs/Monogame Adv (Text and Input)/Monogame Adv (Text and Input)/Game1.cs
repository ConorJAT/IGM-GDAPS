// Conor Race
// Feb. 2nd, 2022
// IGME.106.07

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Adv__Text_and_Input_;

namespace Monogame_Basics
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        // Amicus texture (image) itself:
        private Texture2D amicusTexture;

        // Amicus' position via vector:
        private Vector2 amicusPosition;

        // Amicus rectangle for smaller size:
        private Rectangle amicusRect;

        // Move factor for bounce:
        int moveFactor;

        // SpriteFont for drawing strings:
        private SpriteFont TNR24;

        // Cassius sprite for button rest position:
        private Texture2D cassius;

        // Cassius sprite for button hover position:
        private Texture2D cassiusSprised;

        // Button object:
        Button cassiusButton;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            // Sets Amicus's starting position:
            amicusPosition = new Vector2(175, 398);

            // Sets the move factor to +1:
            moveFactor = 1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading in the actual Amicus file:
            amicusTexture = Content.Load<Texture2D>("Amicus");

            // Forming the Amicus rectangle, half the image's original size:
            amicusRect = new Rectangle((600 - (amicusTexture.Width / 2)) / 2, (600 - (amicusTexture.Height / 2)) / 2,
                                       amicusTexture.Width / 2, amicusTexture.Height / 2);

            // Loading in the actual SpriteFont itself:
            TNR24 = Content.Load<SpriteFont>("TimesNewRoman24");

            // Loading in both Cassius files:
            cassius = Content.Load<Texture2D>("cassius");
            cassiusSprised = Content.Load<Texture2D>("cassius-surprised");

            // Creation of new button object:
            cassiusButton = new Button(cassius, cassiusSprised, new Rectangle(400, 20, 230, 250));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ProcessInput();

            // Amicus moving via move factor:
            amicusPosition.X += moveFactor;

            // Move factor becomes negative should Amicus reach
            // the right end of the screen:
            if (amicusPosition.X == 612 - amicusTexture.Width)
            {
                moveFactor = -1;
            }
            // Move factor becomes positive again should Amicus
            // reach the left end of the screen:
            else if (amicusPosition.X == 0 - 22)
            {
                moveFactor = 1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(110, 78, 81));

            _spriteBatch.Begin();

            _spriteBatch.Draw(amicusTexture, amicusPosition, Color.White);
            _spriteBatch.Draw(amicusTexture, amicusRect, Color.White);

            _spriteBatch.DrawString(TNR24, "\"Welcome to Adastra!\" - Amicus", new Vector2(20, 20), Color.White);
            _spriteBatch.DrawString(TNR24, $"(Amicus' Position: {amicusRect.X}, {amicusRect.Y})", new Vector2(20, 80), Color.White);

            cassiusButton.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Tracks keyboard input to allow movement of the central mini-Amicus.
        /// </summary>
        protected void ProcessInput()
        {
            KeyboardState kb = Keyboard.GetState();

            // A key = Moves Amicus left (-x)
            if (kb.IsKeyDown(Keys.A))
            {
                amicusRect.X -= 5;
            }
            // D key = Moves Amicus right (+x)
            if (kb.IsKeyDown(Keys.D))
            {
                amicusRect.X += 5;
            }
            // W key = Moves Amicus up (-y)
            if (kb.IsKeyDown(Keys.W))
            {
                amicusRect.Y -= 5;
            }
            // S key = Moves Amicus down (+y)
            if (kb.IsKeyDown(Keys.S))
            {
                amicusRect.Y += 5;
            }
        }
    }
}