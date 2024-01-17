// Conor Race
// IGME.106.07
// Feb 23rd, 2022

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace GravityAndCollisionPE
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D playerTexture;
		private Texture2D obstacleTexture;

		private float playerSpeedX;
		private Vector2 playerVelocity;
		private Vector2 jumpVelocity;
		private Vector2 playerPosition;
		private Vector2 gravity;

		private List<Rectangle> obstacleRects;
		private KeyboardState prevKB;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}


		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// </summary>
		protected override void Initialize()
		{
			playerPosition = new Vector2(400, 100);
			playerVelocity = Vector2.Zero;
			jumpVelocity = new Vector2(0, -15.0f);
			gravity = new Vector2(0, 0.5f);

			playerSpeedX = 5.0f;

			obstacleRects = new List<Rectangle>();

			base.Initialize();
		}


		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			playerTexture = Content.Load<Texture2D>("mario");
			obstacleTexture = Content.Load<Texture2D>("pixel");

			// Create a simple map out of crates
			int bottom = _graphics.PreferredBackBufferHeight;
			int right = _graphics.PreferredBackBufferWidth;
			int obstacleSize = 50;

			// Make a floor, walls and a platform
			obstacleRects.Add(new Rectangle(0, bottom - obstacleSize, right, obstacleSize));
			obstacleRects.Add(new Rectangle(0, 0, obstacleSize, bottom));
			obstacleRects.Add(new Rectangle(right - obstacleSize, 0, obstacleSize, bottom));
			obstacleRects.Add(new Rectangle(200, 250, 400, obstacleSize));
		}


		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, etc.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Handle input, apply gravity and then deal with collisions
			ProcessInput();
			ApplyGravity();
			ResolveCollisions();

			// Save the old state at the end of the frame
			prevKB = Keyboard.GetState();
			base.Update(gameTime);
		}

		/// <summary>
		/// Handles movement for sidescrolling game with gravity
		/// </summary>
		private void ProcessInput()
		{
			KeyboardState kb = Keyboard.GetState();

			if (kb.IsKeyDown(Keys.A)) { playerPosition.X -= playerSpeedX; }
			if (kb.IsKeyDown(Keys.D)) { playerPosition.X += playerSpeedX; }
			if (SingleKeyPress(Keys.Space)) { playerVelocity = jumpVelocity; }
		}

		/// <summary>
		/// Applies gravity to the player
		/// </summary>
		private void ApplyGravity()
		{
			playerVelocity.Y += gravity.Y;
			playerPosition.Y += playerVelocity.Y;
		}

		/// <summary>
		/// Handles player collisions with obstacles
		/// </summary>
		private void ResolveCollisions()
		{
			Rectangle playerRect = GetPlayerRect();

			for (int i = 0; i < obstacleRects.Count; i++)
            {
				Rectangle obsRect = obstacleRects[i];

				if (playerRect.Intersects(obsRect))
                {
					Rectangle inter = Rectangle.Intersect(playerRect, obsRect);

					if (inter.Width <= inter.Height)
                    {
						if (playerRect.X > obsRect.X)
                        {
							playerRect.X += inter.Width;
                        }

                        else
                        {
							playerRect.X -= inter.Width;
                        }

						playerPosition.X = playerRect.X;
                    }

					else if (inter.Width > inter.Height)
                    {
						if (playerRect.Y > obsRect.Y)
                        {
							playerRect.Y += inter.Height;
							playerVelocity.Y = 0;
                        }

                        else
                        {
							playerRect.Y -= inter.Height;
							playerVelocity.Y = 0;

                        }

						playerPosition.Y = playerRect.Y;
                    }
                }
            }
		}

		/// <summary>
		/// Determines if a key was initially pressed this frame
		/// </summary>
		/// <param name="key">The key to check</param>
		/// <returns>True if this is the first frame the key is pressed, false otherwise</returns>
		private bool SingleKeyPress(Keys key)
		{
			return Keyboard.GetState().IsKeyDown(key) && prevKB.IsKeyUp(key);
		}


		/// <summary>
		/// Gets a rectangle for the player based on the player's
		/// current position (a vector of float values)
		/// </summary>
		/// <returns>A rectangle representing the bounds of the player</returns>
		private Rectangle GetPlayerRect()
		{
			return new Rectangle(
				(int)playerPosition.X,
				(int)playerPosition.Y,
				playerTexture.Width,
				playerTexture.Height);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();

			// Draw the player using a rectangle make from their position
			_spriteBatch.Draw(playerTexture, GetPlayerRect(), Color.White);

			// Draw each obstactle
			foreach (Rectangle rect in obstacleRects)
			{
				_spriteBatch.Draw(obstacleTexture, rect, Color.SeaGreen);
			}

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
