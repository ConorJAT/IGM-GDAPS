using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
                                       amicusTexture.Width/2, amicusTexture.Height/2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
