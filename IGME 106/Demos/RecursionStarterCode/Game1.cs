using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RecursionStarterCode
{
	public enum RecursiveType
    {
		FractalTree,
		LineStar,
		CheckerBoard
    }

	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private RecursiveType state;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}


		protected override void Initialize()
		{
			_graphics.PreferredBackBufferWidth = 1280;
			_graphics.PreferredBackBufferHeight = 720;
			_graphics.ApplyChanges();

			// PART #1 - Palindromes:

			// Word: RaceCar
			if (IsPalindrome("RaceCar".ToLower(), 0, "RaceCar".Length - 1))
			{
				System.Diagnostics.Debug.WriteLine("\"RaceCar\" IS a palindrome!");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("\"RaceCar\" IS NOT a palindrome!");
			}

			// Word: banana
			if (IsPalindrome("banana", 0, "banana".Length - 1))
			{
				System.Diagnostics.Debug.WriteLine("\"banana\" IS a palindrome!");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("\"banana\" IS NOT a palindrome!");
			}

			// Word: Adastra
			if (IsPalindrome("Adastra".ToLower(), 0, "Adastra".Length - 1))
			{
				System.Diagnostics.Debug.WriteLine("\"Adastra\" IS a palindrome!");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("\"Adastra\" IS NOT a palindrome!");
			}

			state = RecursiveType.FractalTree;
			base.Initialize();
		}


		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState kb = Keyboard.GetState();

            switch (state)
            {
                case RecursiveType.FractalTree:
					if (kb.IsKeyDown(Keys.D2))
                    {
						state = RecursiveType.LineStar;
                    }
					if (kb.IsKeyDown(Keys.D3))
                    {
						state = RecursiveType.CheckerBoard;
                    }
                    break;

                case RecursiveType.LineStar:
					if (kb.IsKeyDown(Keys.D1))
					{
						state = RecursiveType.FractalTree;
					}
					if (kb.IsKeyDown(Keys.D3))
					{
						state = RecursiveType.CheckerBoard;
					}
					break;

				case RecursiveType.CheckerBoard:
					if (kb.IsKeyDown(Keys.D1))
					{
						state = RecursiveType.FractalTree;
					}
					if (kb.IsKeyDown(Keys.D2))
					{
						state = RecursiveType.LineStar;
					}
					break;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Begin a shape batch
			ShapeBatch.Begin(GraphicsDevice);

			// TODO: Call your recursive fractal method here
            switch (state)
            {
				// PART #2 - Recursive Tree:
                case RecursiveType.FractalTree:
					RecursiveTree(new Vector2(640, 600), 100, (float)Math.PI / 2);
					break;

				// PART #3 - Custom Fractals:
                case RecursiveType.LineStar:
					LineStar(new Vector2(640, 360), 300, (float)Math.PI / 2);
                    break;

				case RecursiveType.CheckerBoard:
					CheckerBoard(390, 110, 500);
					break;
            }

            // Draws several example shapes
            // Note: COMMENT OUT the following line
            //       once you start your exercise
            // DrawExampleShapes(gameTime);

            // End the shape batch
            ShapeBatch.End();


			base.Draw(gameTime);
        }


        /// <summary>
        /// Draws several example shapes to showcase ShapeBatch capabilities
        /// </summary>
        /// <param name="gt">Game time information</param>
        public void DrawExampleShapes(GameTime gt)
		{
			// Sample values for "animation"
			float rotation = (float)gt.TotalGameTime.TotalSeconds;
			float sinWave = MathF.Sin(rotation) + 2.0f;

			// Lines
			ShapeBatch.Line(new Vector2(50, 50), new Vector2(150, 70), Color.White);
			ShapeBatch.Line(new Vector2(50, 150), new Vector2(150, 220), 8.0f, Color.Green, Color.Yellow);
			ShapeBatch.Line(new Vector2(100, 250), 75.0f, rotation, Color.DarkKhaki);
			ShapeBatch.Line(new Vector2(100, 350), 75.0f, rotation + MathF.PI / 2.0f, 10.0f, Color.CadetBlue);

			// Boxes
			ShapeBatch.Box(200, 50, 50, 50, Color.IndianRed, Color.IndianRed, Color.BlueViolet, Color.BlueViolet);
			ShapeBatch.Box(new Rectangle(220, 150, 50, 60), Color.RosyBrown);

			// Outline boxes
			ShapeBatch.BoxOutline(200, 250, 50, 50, Color.Gainsboro);
			ShapeBatch.BoxOutline(new Rectangle(220, 350, 75, 60), Color.Red, Color.Green, Color.Blue, Color.White);

			// Circles
			ShapeBatch.Circle(new Vector2(350, 75), sinWave * 20.0f, Color.Black, Color.Aquamarine);
			ShapeBatch.Circle(new Vector2(350, 225), sinWave * 10.0f + 20.0f, 8, Color.AliceBlue);
			ShapeBatch.Circle(new Vector2(350, 375), sinWave * 5.0f + 20.0f, 5, -rotation, Color.LightGoldenrodYellow);

			// Outline circles
			ShapeBatch.CircleOutline(new Vector2(425, 125), 25.0f, Color.Aquamarine);
			ShapeBatch.CircleOutline(new Vector2(425, 275), 30.0f, 8, Color.AliceBlue);
			ShapeBatch.CircleOutline(new Vector2(425, 425), 35.0f, 5, rotation, Color.LightGoldenrodYellow);

			// Triangles
			ShapeBatch.Triangle(new Vector2(550, 75), 100, Color.Orange, Color.OrangeRed, Color.Yellow);
			ShapeBatch.Triangle(new Vector2(550, 250), 75, rotation, Color.Red, Color.ForestGreen, Color.Blue);
			ShapeBatch.Triangle(new Vector2(550, 475), new Vector2(475, 420), new Vector2(675, 350), Color.CornflowerBlue, Color.DarkBlue, Color.LightBlue);

			// Outline triangles
			ShapeBatch.TriangleOutline(new Vector2(650, 150), 60, Color.Orange);
			ShapeBatch.TriangleOutline(new Vector2(650, 275), 60, rotation / -2.0f, Color.Red, Color.ForestGreen, Color.Blue);
			ShapeBatch.TriangleOutline(new Vector2(650, 450), new Vector2(550, 360), new Vector2(750, 400), Color.CornflowerBlue);
		}


		public bool IsPalindrome(string word, int startIndex, int endIndex)
		{
			// Base Cases:
			if (word[startIndex] != word[endIndex])
			{
				return false;
			}
			else if (startIndex >= endIndex)
			{
				return true;
			}

			startIndex++;
			endIndex--;

			// Recursive Case:
			return IsPalindrome(word, startIndex, endIndex);
		}


		public void RecursiveTree(Vector2 startPoint, float length, float angle)
		{
			// Base Case:
			if (length < 10)
			{
				return;
			}

			startPoint = ShapeBatch.Line(startPoint, length, angle, Color.White);
			length *= (float)0.8;

			// Recursive Cases:
			RecursiveTree(startPoint, length, angle += (float)Math.PI / 6);
			RecursiveTree(startPoint, length, angle -= (float)Math.PI / 3);
		}


		public void LineStar(Vector2 startPoint, float length, float angle)
		{
			ShapeBatch.Line(startPoint, length, angle, Color.Blue);
			angle += (float)Math.PI / 24;
			if (length > 175)
			{
				length -= 25;
			}
			else
			{
				length = 300;
			}

			// Base Case:
			if (angle >= (float)5 * Math.PI / 2)
			{
				return;
			}

			// Recursive Case:
			LineStar(startPoint, length, angle);
		}


		public void CheckerBoard(float xCoord, float yCoord, float length)
        {
			// Base Case:
			if (length <= 10)
            {
				return;
            }

			float tempLength = length / 3;

			// Center Square:
			ShapeBatch.Box(xCoord + tempLength, yCoord + tempLength, tempLength, tempLength, Color.White);

			// Black Squares:
			ShapeBatch.Box(xCoord + tempLength, yCoord, tempLength, tempLength, Color.Black);
			ShapeBatch.Box(xCoord, yCoord + tempLength, tempLength, tempLength, Color.Black);
			ShapeBatch.Box(xCoord + 2 * tempLength, yCoord + tempLength, tempLength, tempLength, Color.Black);
			ShapeBatch.Box(xCoord + tempLength, yCoord + 2 * tempLength, tempLength, tempLength, Color.Black);

			// Corner Squares:
			ShapeBatch.Box(xCoord, yCoord, tempLength, tempLength, Color.White);
			ShapeBatch.Box(xCoord + 2 * tempLength, yCoord, tempLength, tempLength, Color.White);
			ShapeBatch.Box(xCoord, yCoord + 2 * tempLength, tempLength, tempLength, Color.White);
			ShapeBatch.Box(xCoord + 2 * tempLength, yCoord + 2 * tempLength, tempLength, tempLength, Color.White);

			// Recursive Cases:
			CheckerBoard(xCoord + tempLength, yCoord + tempLength, tempLength);
			CheckerBoard(xCoord + 2 * tempLength, yCoord + 2 * tempLength, tempLength);
			CheckerBoard(xCoord + 2 * tempLength, yCoord, tempLength);
			CheckerBoard(xCoord, yCoord + 2 * tempLength, tempLength);
			CheckerBoard(xCoord, yCoord, tempLength);
		}
    }
}
