// Chris Cascioli
// 2/9/22
// Demo of simple AABB collision detection between two objects

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CollisionDetectionDemo
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Rectangle playerRect;
		private Rectangle obstacleRect;

		private Texture2D rectangleTexture;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// Set up the initial rectangles
			playerRect = new Rectangle(100, 100, 50, 50);
			obstacleRect = new Rectangle(500, 50, 50, 400);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// Load our image
			rectangleTexture = Content.Load<Texture2D>("rectangle");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Move the player
			KeyboardState kb = Keyboard.GetState();

			int speed = 5;
			if (kb.IsKeyDown(Keys.W)) { playerRect.Y -= speed; }
			if (kb.IsKeyDown(Keys.S)) { playerRect.Y += speed; }
			if (kb.IsKeyDown(Keys.A)) { playerRect.X -= speed; }
			if (kb.IsKeyDown(Keys.D)) { playerRect.X += speed; }

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Draw the two objects to the screen
			_spriteBatch.Begin();

			// We'll detect collisions in Draw() this time, even
			// though it is more common to do it in Update() in
			// a more complete game
			Color objColor = Color.White;
			if (playerRect.Intersects(obstacleRect))
			{
				objColor = Color.Red;
			}

			_spriteBatch.Draw(rectangleTexture, playerRect, objColor);
			_spriteBatch.Draw(rectangleTexture, obstacleRect, objColor);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
