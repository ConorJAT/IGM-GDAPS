// Conor Race
// Feb 11th, 2022
// IGME.106.07

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Shape_Collisions
{
    // Enum for FSM and detecting what intersections user is checking:
    public enum CollisionState
    {
        Intersect,
        Circle
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Variables for textures:
        private Texture2D mySquare;
        private Texture2D myCircle;
        
        // Variables regarding rectangle collisions:
        private SquareEntity player;
        private List<SquareEntity> randomSquares;

        // Variables regarding circle collisions:
        private CircleEntity cPlayer;
        private List<CircleEntity> randomCircles;
        
        // Misc. variables for project function:
        private Random rng;
        private CollisionState state;

        // Variable for SpriteFont:
        private SpriteFont TNR24;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            randomSquares = new List<SquareEntity>();
            randomCircles = new List<CircleEntity>();
            rng = new Random();
            state = CollisionState.Intersect;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mySquare = Content.Load<Texture2D>("square");
            myCircle = Content.Load<Texture2D>("circle2");

            // Creates a randomized list of rectangle SquareEntities:
            player = new SquareEntity(mySquare, 50, 50, 50, 50);
            for (int i = 0; i < 10; i++)
            {
                randomSquares.Add(new SquareEntity(mySquare, rng.Next(0, _graphics.PreferredBackBufferWidth),
                                                   rng.Next(0, _graphics.PreferredBackBufferHeight),
                                                   rng.Next(5, 51), rng.Next(5, 51)));
            }

            // Creates a randomized list of circular CircleEntities:
            cPlayer = new CircleEntity(myCircle, 50, 50, 25);
            for (int i = 0; i < 10; i++)
            {
                randomCircles.Add(new CircleEntity(myCircle, rng.Next(0, _graphics.PreferredBackBufferWidth),
                                                   rng.Next(0, _graphics.PreferredBackBufferHeight),
                                                   rng.Next(5, 51)));
            }

            TNR24 = Content.Load<SpriteFont>("TimesNewRoman24");
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();

            // Switch statement used to detect state presence and state swaps:
            switch (state)
            {
                case CollisionState.Intersect: 
                    if (kb.IsKeyDown(Keys.A)) { player.X -= 5; }
                    if (kb.IsKeyDown(Keys.D)) { player.X += 5; }
                    if (kb.IsKeyDown(Keys.W)) { player.Y -= 5; }
                    if (kb.IsKeyDown(Keys.S)) { player.Y += 5; }
                    
                    if (kb.IsKeyDown(Keys.D2))
                    {
                        state = CollisionState.Circle;
                    }
                    break;


                case CollisionState.Circle:
                    if (kb.IsKeyDown(Keys.A)) { cPlayer.X -= 5; }
                    if (kb.IsKeyDown(Keys.D)) { cPlayer.X += 5; }
                    if (kb.IsKeyDown(Keys.W)) { cPlayer.Y -= 5; }
                    if (kb.IsKeyDown(Keys.S)) { cPlayer.Y += 5; }

                    if (kb.IsKeyDown(Keys.D1))
                    {
                        state = CollisionState.Intersect;
                    }
                    break;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            Color pColor = Color.CornflowerBlue;
            Color obsColor;

            // Draws objects to screen ONLY associated to Intersect enum:
            if (state == CollisionState.Intersect)
            {
                
                for (int i = 0; i < randomSquares.Count; i++)
                {
                    obsColor = Color.White;
                    if (player.Intersects(randomSquares[i]))
                    {
                        obsColor = Color.Red;
                        pColor = Color.Red;
                    }

                    randomSquares[i].Draw(_spriteBatch, obsColor);
                }

                player.Draw(_spriteBatch, pColor);
                _spriteBatch.DrawString(TNR24, "Intersects", new Vector2(60, 660), Color.CornflowerBlue);
            }

            // Draws objects to screen ONLY associated to Circle enum:
            else
            {
                obsColor = Color.CornflowerBlue;
                for (int i = 0; i < randomCircles.Count; i++)
                {
                    obsColor = Color.White;
                    if (cPlayer.Intersects(randomCircles[i]))
                    {
                        obsColor = Color.Red;
                        pColor = Color.Red;
                    }

                    randomCircles[i].Draw(_spriteBatch, obsColor);
                }

                cPlayer.Draw(_spriteBatch, pColor);
                _spriteBatch.DrawString(TNR24, "Circle-Circle", new Vector2(60, 660), Color.CornflowerBlue);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
