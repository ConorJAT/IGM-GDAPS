using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameDemo
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		// Fields to hold info about our image
		private Texture2D marioTexture;
		private Rectangle marioRect;
		private Rectangle mouseMarioRect;

		private Color marioTint;
		private Random rng;
		private KeyboardState prevKB;

		// Font-related variables
		private SpriteFont fontTahoma32;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = false;
		}

		protected override void Initialize()
		{
			// Resizing the window
			_graphics.PreferredBackBufferWidth = 1024;
			_graphics.PreferredBackBufferHeight = 768;
			_graphics.ApplyChanges();

			marioRect = new Rectangle(100, 100, 300, 300);
			mouseMarioRect = new Rectangle(20, 20, 300, 300);
			marioTint = Color.White;
			rng = new Random();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// Here we can load assets one at a time
			marioTexture = this.Content.Load<Texture2D>("mario");
			fontTahoma32 = this.Content.Load<SpriteFont>("Tahoma32");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Move mario during Update
			//marioRect.X += 10;
			//if (marioRect.X >= _graphics.PreferredBackBufferWidth)
			//	marioRect.X = -marioRect.Width;

			// Instead, use the keyboard to drive mario
			KeyboardState kb = Keyboard.GetState();

			// Check any and all keys we care about
			int speed = 12;
			if (kb.IsKeyDown(Keys.D)) { marioRect.X += speed; }
			if (kb.IsKeyDown(Keys.A)) { marioRect.X -= speed; }
			if (kb.IsKeyDown(Keys.S)) { marioRect.Y += speed; }
			if (kb.IsKeyDown(Keys.W)) { marioRect.Y -= speed; }

			// If the space bar is pressed, we need to change the tint
			if (kb.IsKeyDown(Keys.Space) && prevKB.IsKeyUp(Keys.Space))
			{
				marioTint.R = (byte)rng.Next(0, 256);
				marioTint.G = (byte)rng.Next(0, 256);
				marioTint.B = (byte)rng.Next(0, 256);
			}


			// Check the mouse state and move mario accordingly
			MouseState ms = Mouse.GetState();
			mouseMarioRect.X = ms.X;
			mouseMarioRect.Y = ms.Y;
			if (ms.LeftButton == ButtonState.Pressed)
			{
				mouseMarioRect.Width += 3;
			}
			if (ms.RightButton == ButtonState.Pressed)
			{
				mouseMarioRect.Width -= 3;
			}

			// End of update/frame stuff
			prevKB = kb;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// If we want to draw something to the screen,
			// we need to use a "spriteBatch" object

			// Step 1: Begin() the batch
			_spriteBatch.Begin();

			// Step 2: Draw() any and all assets here
			_spriteBatch.Draw(
				marioTexture, // The texture to draw
				mouseMarioRect, // Where to draw it
				marioTint); // The color tint to apply

			// Drawing again
			_spriteBatch.Draw(
				marioTexture,
				marioRect,
				Color.White);

			// Draw some text
			_spriteBatch.DrawString(
				fontTahoma32,
				"This is a string from my code, yo!",
				new Vector2(10, 10),
				Color.White);

			_spriteBatch.DrawString(
				fontTahoma32,
				$"Mario is at {marioRect.X}, {marioRect.Y}",
				new Vector2(10, 60),
				Color.White);

			// Step 3: End() the batch
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
