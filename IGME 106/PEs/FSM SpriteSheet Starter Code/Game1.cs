// Conor Race
// Feb 9th, 2022
// IGME.106.07

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FSM_SpriteSheet_PE
{
	public enum MarioState
    {
		FaceRight,
		FaceLeft,
		MoveRight,
		MoveLeft
    }


	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		// Mario texture stuff
		private Texture2D marioTexture;
		private Vector2 marioPosition;
		int numSpritesInSheet;
		int widthOfSingleSprite;

		// Animation reqs
		int currentFrame;
		double fps;
		double secondsPerFrame;
		double timeCounter;
		MarioState marioState;

		// Previous keyboard state:
		private KeyboardState prevKB;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			marioState = MarioState.FaceRight;

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			marioTexture = Content.Load<Texture2D>("MarioSpriteSheet");
			numSpritesInSheet = 4;
			widthOfSingleSprite = marioTexture.Width / numSpritesInSheet;

			marioPosition = new Vector2(200, 200);

			// Set up animation stuff
			currentFrame = 1;
			fps = 10.0;
			secondsPerFrame = 1.0f / fps;
			timeCounter = 0;
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

            // *** Put code to check and update FINITE STATE MACHINE here
            
			switch (marioState)
            {
				// If Mario is facing right...
                case MarioState.FaceRight:
					KeyboardState kb = Keyboard.GetState();

					// Move him right if D key is touched or held:
					if (kb.IsKeyDown(Keys.D))
                    {
						marioState = MarioState.MoveRight;
                    }

					// Move him left if the A key is touched AND held:
					else if (kb.IsKeyDown(Keys.A) && prevKB.IsKeyDown(Keys.A))
                    {
						marioState = MarioState.MoveLeft;
                    }

					// Face him left is the A key is touched AND after the instant it's released:
					else if (kb.IsKeyDown(Keys.A) && prevKB.IsKeyUp(Keys.A))
                    {
						marioState = MarioState.FaceLeft;
                    }

					// Store previous keyboard state for next loop:
					prevKB = kb;
                    break;


				// If Mario is facing left...
                case MarioState.FaceLeft:
					KeyboardState kb2 = Keyboard.GetState();

					// Move him left if A key is touched or held:
					if (kb2.IsKeyDown(Keys.A))
                    {
						marioState = MarioState.MoveLeft;
                    }

					// Move him right if the D key is touched AND held:
					else if (kb2.IsKeyDown(Keys.D) && prevKB.IsKeyDown(Keys.D))
                    {
						marioState = MarioState.MoveRight;
                    }

					// Face him right is the D key is touched AND after the instant it's released:
					else if (kb2.IsKeyDown(Keys.D) && prevKB.IsKeyUp(Keys.D))
                    {
						marioState = MarioState.FaceRight;
					}

					// Store previous keyboard state for next loop:
					prevKB = kb2;
					break;


				// If Mario is currently moving right...
                case MarioState.MoveRight:
					KeyboardState kb3 = Keyboard.GetState();

					// Move him set amount of distance in +x direction:
					marioPosition.X += 3;

					// Face him right (or stop) him when the D is released after being held:
					if (kb3.IsKeyUp(Keys.D) && prevKB.IsKeyDown(Keys.D))
                    {
						marioState = MarioState.FaceRight;
                    }

					// Move him left if the A key is touched AND held:
					else if (kb3.IsKeyDown(Keys.A) && prevKB.IsKeyDown(Keys.A))
					{
						marioState = MarioState.MoveLeft;
					}

					// Face him left is the A key is touched AND after the instant it's released:
					else if (kb3.IsKeyDown(Keys.A) && prevKB.IsKeyUp(Keys.A))
					{
						marioState = MarioState.FaceLeft;
					}

					// Store previous keyboard state for next loop:
					prevKB = kb3;
					break;


				// If Marios is currently moving left...
                case MarioState.MoveLeft:
					KeyboardState kb4 = Keyboard.GetState();

					// Move him set amount of distance in -x direction:
					marioPosition.X -= 3;

					// Face him left (or stop) him when the A is released after being held:
					if (kb4.IsKeyUp(Keys.A) && prevKB.IsKeyDown(Keys.A))
                    {
						marioState = MarioState.FaceLeft;
                    }

					// Move him right if the D key is touched AND held:
					else if (kb4.IsKeyDown(Keys.D) && prevKB.IsKeyDown(Keys.D))
					{
						marioState = MarioState.MoveRight;
					}

					// Face him right is the D key is touched AND after the instant it's released:
					else if (kb4.IsKeyDown(Keys.D) && prevKB.IsKeyUp(Keys.D))
					{
						marioState = MarioState.FaceRight;
					}

					// Store previous keyboard state for next loop:
					prevKB = kb4;
					break;
            }


            // Update the animation
            UpdateAnimation(gameTime);
			base.Update(gameTime);
        }

        /// <summary>
        /// Updates the animation time
        /// </summary>
        /// <param name="gameTime">Game time information</param>
        private void UpdateAnimation(GameTime gameTime)
		{
			// Add to the time counter (need TOTALSECONDS here)
			timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

			// Has enough time gone by to actually flip frames?
			if (timeCounter >= secondsPerFrame)
			{
				// Update the frame and wrap
				currentFrame++;
				if (currentFrame >= 4) currentFrame = 1;

				// Remove one "frame" worth of time
				timeCounter -= secondsPerFrame;
			}

		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();

            // *** Put code to check FINITE STATE MACHINE
            // *** and properly draw mario here
            switch (marioState)
            {
                case MarioState.FaceRight:
					DrawMarioStanding(SpriteEffects.None);
                    break;

                case MarioState.FaceLeft:
					DrawMarioStanding(SpriteEffects.FlipHorizontally);
                    break;

                case MarioState.MoveRight:
					DrawMarioWalking(SpriteEffects.None);
                    break;

                case MarioState.MoveLeft:
					DrawMarioWalking(SpriteEffects.FlipHorizontally);
                    break;
            }


            // Example call to draw mario walking
            // *** REPLACE or ADJUST this line!
            // DrawMarioStanding(SpriteEffects.None);



			_spriteBatch.End();

			base.Draw(gameTime);
        }

        /// <summary>
        /// Draws mario with a walking animation
        /// </summary>
        /// <param name="flip">Should he be flipped horizontally?</param>
        private void DrawMarioWalking(SpriteEffects flip)
		{
			_spriteBatch.Draw(
				marioTexture,
				marioPosition,
				new Rectangle(widthOfSingleSprite * currentFrame, 0, widthOfSingleSprite, marioTexture.Height),
				Color.White,
				0.0f,
				Vector2.Zero,
				1.0f,
				flip,
				0.0f);
		}

		/// <summary>
		/// Draws mario standing still
		/// </summary>
		/// <param name="flip">Should he be flipped horizontally?</param>
		private void DrawMarioStanding(SpriteEffects flip)
		{
			_spriteBatch.Draw(
				marioTexture,
				marioPosition,
				new Rectangle(0, 0, widthOfSingleSprite, marioTexture.Height),
				Color.White,
				0.0f,
				Vector2.Zero,
				1.0f,
				flip,
				0.0f);
		}
    }
}
