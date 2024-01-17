using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Recursive_Fun
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
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

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            RecursiveTree(new Vector2(960, 880), 160, (float)Math.PI / 12);

            _spriteBatch.End();

            base.Draw(gameTime);
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
            if (length < 50)
            {
                return;
            }

            _spriteBatch.Draw(ShapeBatch.Line);

        }
    }
}
