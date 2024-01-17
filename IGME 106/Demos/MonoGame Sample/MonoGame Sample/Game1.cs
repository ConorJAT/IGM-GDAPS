using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Sample
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Fields to hold info about image:
        private Texture2D sonicTexture;
        private Rectangle sonicRect;
        private Rectangle mouseSonicRect;

        private Color sonicTint;

        Random rng;

        // Font-related variables:
        private SpriteFont fontTahoma32;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Resizing the Window:
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();

            sonicRect = new Rectangle(100, 100, 400, 400);
            mouseSonicRect = new Rectangle(20, 20, 300, 300);

            sonicTint = Color.White;

            rng = new Random();

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // Here, we can load assets one at a time:
            sonicTexture = this.Content.Load<Texture2D>("Sonic PNG");
            fontTahoma32 = this.Content.Load<SpriteFont>("Tahoma32");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*sonicRect.X += 10;
            if (sonicRect.X >= _graphics.PreferredBackBufferWidth)
                sonicRect.X = -sonicRect.Width; */


            // Use keyboard to move Sonic:
            KeyboardState kb = Keyboard.GetState();
            KeyboardState prevKB = Keyboard.GetState();

            // Check any and all keys we care about:
            if (kb.IsKeyDown(Keys.D)) { sonicRect.X += 5; }

            if (kb.IsKeyDown(Keys.A)) { sonicRect.X -= 5; }

            if (kb.IsKeyDown(Keys.W)) { sonicRect.Y -= 5; }

            if (kb.IsKeyDown(Keys.S)) { sonicRect.Y += 5; }

            // Check any and all mouse states we care about:
            MouseState ms = Mouse.GetState();
            mouseSonicRect.X = ms.X;
            mouseSonicRect.Y = ms.Y;
            if (ms.LeftButton == ButtonState.Pressed)
            {
                mouseSonicRect.Width += 3;
            }
            if (ms.RightButton == ButtonState.Pressed)
            {
                mouseSonicRect.Width -= 3;
            }

            // If space is pressed, changes the tint color:
            if (kb.IsKeyDown(Keys.Space) && prevKB.IsKeyUp(Keys.Space))
            {
                sonicTint.R = (byte)rng.Next(0, 256);
                sonicTint.G = (byte)rng.Next(0, 256);
                sonicTint.B = (byte)rng.Next(0, 256);
            }

            
            // TODO: Add your update logic here

            base.Update(gameTime);

            prevKB = kb;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            // TODO: Add your drawing code here
            // If we want to draw something to screen,
            // we use a "spriteBatch" object:

            // Step 1: Begin() that batch
            _spriteBatch.Begin();

            // Step 2: Draw() any and all assets here
            _spriteBatch.Draw(
                sonicTexture,                        // Texture to draw
                sonicRect,                           // Where to draw it
                Color.White);                        // Color tint to apply

            _spriteBatch.Draw(
               sonicTexture,                 
               mouseSonicRect,                        
               sonicTint);                        

            _spriteBatch.DrawString(
                fontTahoma32,
                "Gotta go fast!",
                new Vector2(20, 20),
                Color.White);

            _spriteBatch.DrawString(
                fontTahoma32,
                $"Sonic is at {sonicRect.X}, {sonicRect.Y}",
                new Vector2(20, 500),
                Color.White);

            // Measures the length of a string should it be drawn to the screen.
            fontTahoma32.MeasureString("ABC");

            // Step 3: End() the batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
