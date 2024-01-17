using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DynamicTreeStarter
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		// The three trees
		private Tree treeRed;
		private Tree treeGreen;
		private Tree treeBlue;

		private int countGreen;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			countGreen = 0;

			// Create the three trees
			treeRed = new Tree(_spriteBatch, Color.Red);
			treeGreen = new Tree(_spriteBatch, Color.Green);
			treeBlue = new Tree(_spriteBatch, Color.DodgerBlue);

			Random rng = new Random();

			treeBlue.Add(100);

			/*for (int i = 0; i < 100; i++)
            {
				treeRed.Add(rng.Next(0, 1001));
				treeBlue.Add(rng.Next(100, 120));
				treeGreen.Add(i);
            }*/
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// *** After you have the rest of the assignment working: ******
			//  What happens if you insert a new piece of 
			//  data into the trees each frame?

			Random rng = new Random();

			treeRed.Add(rng.Next(0, 1001));
			treeBlue.Add(rng.Next(100, 120));
			treeGreen.Add(countGreen);
			countGreen++;


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Draw the trees
			treeRed.Draw(new Vector2(200, 400));
			treeGreen.Draw(new Vector2(400, 400));
			treeBlue.Draw(new Vector2(600, 400));

			base.Draw(gameTime);
		}
	}
}
