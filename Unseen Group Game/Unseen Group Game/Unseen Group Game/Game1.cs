// Team Ceres:
//    - Conor Race
//    - Esther Loo
//    - Elisa Vilinskis
//    - Samera Vilinskis
//    - Ryan Schaufelberger

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

// Enums for each particular game state:
public enum GameState
{
    TitleMenu,
    ControlMenu,
    Credits,
    InGame,
    PauseMenu,
    GameOver,
    Notebook,
    GameWon,
    Quit
}

// Enums for each particular player state:
public enum PlayerState
{
    Standing,
    Walking,
    Hiding,
    Crouching,
    Crawling,
    Climbing
}

namespace Unseen_Group_Game
{
    public class Game1 : Game
    {
        //Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game's particular state trackers:
        private GameState gState;
        private GameState prevGState;
        private PlayerState pState;

        //all the enemies and their texture
        EnemyManager allEnemies;
        Texture2D enemyTexture;

        //level manager
        private LevelManager levels;

        //player object and texture
        Player playerCharacter;
        Texture2D playerTexture;
        Texture2D crouchTexture;
        Texture2D climbTexture;

        //ladder object texture
        Texture2D ladderTexture;

        //hiding spot texture
        Texture2D hidingSpotTexture;

        //vent texutre
        Texture2D ventTexure;

        //off switch texture
        Texture2D offSwitchTexture;

        //Checkpoint extures
        Texture2D checkpointTexUncollected;
        Texture2D checkpointTexCollected;
          
        //menu textures and objects
        Texture2D whiteRect;
        Texture2D controlScreen;
        Texture2D creditScreen;
        MainMenu mainmenu;
        PauseMenu pausemenu;
        NoteBook notebook;
        GameOverScreen gameoverscreen;
        GameWonScreen gameWonScreen;

        //font
        SpriteFont gameFont;

        //keyboard and mouse states
        private KeyboardState kbState;
        private KeyboardState prevKbState;
        private MouseState mouState;
        private MouseState prevMouState;

        //God mode
        private bool godMode;

        // Animation reqs
        int currentFrame;
        int currentFrame2;
        double fps;
        double secondsPerFrame;
        double timeCounter;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            gState = GameState.TitleMenu;
            pState = PlayerState.Standing;

            //Keep this commented while testing!!!!!!!!!!!!
            _graphics.IsFullScreen = true;

            _graphics.PreferredBackBufferWidth=1920;
            _graphics.PreferredBackBufferHeight=1080;
            _graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load test rectangle
            whiteRect = Content.Load<Texture2D>("WhiteRect");

            //load font
            gameFont = Content.Load<SpriteFont>("GameFont");

            //MENU------------------------------------------------------------------------------------------------------------
            //load main menu textures
            mainmenu = new MainMenu(whiteRect, new Texture2D[]{Content.Load<Texture2D>("mainmenu-newgame"), Content.Load<Texture2D>("mainmenu-continue"), Content.Load<Texture2D>("mainmenu-controls"),
                Content.Load<Texture2D>("mainmenu-credits"), Content.Load<Texture2D>("mainmenu-quit"), Content.Load<Texture2D>("mainmenunone")});

            //load pause menu textures
            pausemenu = new PauseMenu(whiteRect, new Texture2D[] {Content.Load<Texture2D>("pausemenuload"),Content.Load<Texture2D>("pausemenucontrols"),
                Content.Load<Texture2D>("pausemenucredits"), Content.Load<Texture2D>("pausemenuquit"),Content.Load<Texture2D>("pausemenunone")  });
          
            //load notebook textures
            notebook = new NoteBook(whiteRect, new Texture2D[] { Content.Load<Texture2D>("newnotebookpencil"), Content.Load<Texture2D>("newnotebookeraser") });
           
            //load game over screen textures
            gameoverscreen = new GameOverScreen(whiteRect, new Texture2D[] {Content.Load<Texture2D>("gameoverscreencontinue"), Content.Load<Texture2D>("gameoverscreenquit"),
                Content.Load<Texture2D>("gameoverscreen") });

            //load congrats screen textures
            gameWonScreen = new GameWonScreen(whiteRect, new Texture2D[] { Content.Load<Texture2D>("endscreen"), Content.Load<Texture2D>("endscreenexit") });
          
            //load controls screen texture
            controlScreen = Content.Load<Texture2D>("controls");
           
            //load credits screen texture
            creditScreen = Content.Load<Texture2D>("credits");

            //PLAYER----------------------------------------------------------------------------------------------------     
            //load player texture
            playerTexture = Content.Load<Texture2D>("spyspritesheet");
            crouchTexture = Content.Load<Texture2D>("crawlspritesheet");
            climbTexture = Content.Load<Texture2D>("climbspritesheet");

            //initialize a player object
            playerCharacter = new Player(playerTexture, 90, 40, 72, 160);

            //ENEMIES---------------------------------------------------------------------------------------------------
            //load guard texture
            enemyTexture = Content.Load<Texture2D>("guardspritesheet");

            //create list of all enemy textures
            List<Texture2D> enemyTextures = new List<Texture2D>();
            enemyTextures.Add(enemyTexture);

            Texture2D dogTexture = Content.Load<Texture2D>("dogspritesheet");
            enemyTextures.Add(dogTexture);

            Texture2D cameraTextureOn = Content.Load<Texture2D>("securitycameraspriteon");
            enemyTextures.Add(cameraTextureOn);

            Texture2D CameraTextureOff = Content.Load<Texture2D>("securitycameraspriteoff");
            enemyTextures.Add(CameraTextureOff);
            Texture2D SpotlightTextureOn = Content.Load<Texture2D>("spotlightOn");
            enemyTextures.Add(SpotlightTextureOn);


            Texture2D SpotlightTextureOff = Content.Load<Texture2D>("spotlightOff");
            enemyTextures.Add(SpotlightTextureOff);


            //initialized an EnemyManager object
            allEnemies = new EnemyManager();

            //LEVEL------------------------------------------------------------------------------------------------------

            //load backgrounds
            List<Texture2D> backgrounds = new List<Texture2D>();
            backgrounds.Add(Content.Load<Texture2D>("bgtile2"));
            backgrounds.Add(Content.Load<Texture2D>("finallevel1"));
            backgrounds.Add(Content.Load<Texture2D>("finallevel2"));
            backgrounds.Add(Content.Load<Texture2D>("finallevel3"));


            //load ladder texture
            ladderTexture = Content.Load<Texture2D>("laddersprite");

            //load hiding spot texture
            hidingSpotTexture = Content.Load<Texture2D>("hspotplant");

            //load vent texture
            ventTexure = Content.Load<Texture2D>("venttexture");

            //load off switch texture
            offSwitchTexture = Content.Load<Texture2D>("buttonsprite");
            Texture2D offSwitchTextureOff = Content.Load<Texture2D>("buttonOff");

            //load checkpoint texture
            checkpointTexCollected = Content.Load<Texture2D>("watercoolerspritecollected");
            checkpointTexUncollected = Content.Load<Texture2D>("watercoolersprite");

            //load platform texture
            Texture2D platformtex = Content.Load<Texture2D>("platform");

            //create list to store textures for the level manager in
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(whiteRect);
            textures.Add(ladderTexture);
            textures.Add(checkpointTexCollected);
            textures.Add(checkpointTexUncollected);
            textures.Add(hidingSpotTexture);
            textures.Add(ventTexure);
            textures.Add(platformtex);
            textures.Add(offSwitchTexture);
            textures.Add(offSwitchTextureOff);

            //initialize a level manager
            levels = new LevelManager(textures, enemyTextures, backgrounds);

            //load the levels

            //load first level first
            levels.LoadLevel("Content/firstlevel.level");

            levels.LoadLevel("Content/level2.level");
            levels.LoadLevel("Content/level3.level");
            levels.LoadLevel("Content/level4.level");
            //levels.LoadLevel("Content/level5.level");
            levels.LoadLevel("Content/level6.level");
            levels.LoadLevel("Content/level7.level");
            levels.LoadLevel("Content/level8.level");
            levels.LoadLevel("Content/level9.level");

            //load last level last
            levels.LoadLevel("Content/finallevel.level");

            levels.CurrentLevel = levels.AllLevels[levels.CurrentLevelIndex];

            //thingy the enemies
            allEnemies.ChangeEnemies(levels.CurrentLevel.Enemies, levels.CurrentLevel.DogEnemies, levels.CurrentLevel.CameraEnemies, levels.CurrentLevel.Spotlights);

            //load the player's save file
            StreamReader input = new StreamReader("Content/playersave.txt");
            try
            {
                playerCharacter.LastCheckpointLevel = int.Parse(input.ReadLine());
                playerCharacter.LastSave = new Point(int.Parse(input.ReadLine()), int.Parse(input.ReadLine()));
            }
            catch
            {
                playerCharacter.LastCheckpointLevel = 0;
                playerCharacter.LastSave = new Point(90, 880);
            }
            finally
            {
                input.Close();
            }


            // Set up animation stuff
            currentFrame = 1;
            currentFrame2 = 1;
            fps = 10.0;
            secondsPerFrame = 1.0f / fps;
            timeCounter = 0;

            // Set up god mode
            godMode = false;
        }


        protected override void Update(GameTime gameTime)
        {

            // Finite state machine skeleton for each game state (deals with game logic):
            mouState = Mouse.GetState();
            kbState = Keyboard.GetState();

            //Godmode toggle
            if (SingleKeyPress(Keys.G))
            {
                godMode = !godMode;
            }

            switch (gState) //gameState switch statement
            {
                case GameState.TitleMenu: //title menu state
                    //state transitions
                    gState = mainmenu.Update(mouState, prevMouState, kbState, prevKbState);  

                    //make a new game
                    if (gState == GameState.InGame)
                    {
                        allEnemies.ResetPosition();
                        levels.CurrentLevel = levels.AllLevels[0];
                        levels.CurrentLevelIndex = 0;
                        allEnemies.ChangeEnemies(levels.CurrentLevel.Enemies, levels.CurrentLevel.DogEnemies, levels.CurrentLevel.CameraEnemies, levels.CurrentLevel.Spotlights);
                        playerCharacter.Position = new Rectangle(90, 880, 72, 160);
                        playerCharacter.LastCheckpointLevel = 0;
                        playerCharacter.LastSave = new Point(playerCharacter.Position.X, playerCharacter.Position.Y);
                        pState = PlayerState.Standing;
                        levels.CurrentBackgroundIndex = 0;
                        levels.ResetLevels();
                    }
                    //clicked continue
                    else if (gState == GameState.GameOver)
                    {
                        ResetFromCheckpoint();
                        gState = GameState.InGame;
                    }

                    if (gState != GameState.TitleMenu)
                    {
                        prevGState = GameState.TitleMenu;
                    }
                    break;

                case GameState.ControlMenu: //control menu state
                    //state transitions
                    if (SingleKeyPress(Keys.Escape))
                    {
                        if (prevGState == GameState.TitleMenu)
                        {
                            gState = GameState.TitleMenu;
                        }
                        else
                        {
                            gState = GameState.PauseMenu;
                        }
                        prevGState = GameState.ControlMenu;
                    }
                    break;

                case GameState.Credits: //credits screen state
                    //state transitions
                    if (SingleKeyPress(Keys.Escape))
                    {
                        if (prevGState == GameState.TitleMenu)
                        {
                            gState = GameState.TitleMenu;
                        }
                        else
                        {
                            gState = GameState.PauseMenu;
                        }
                        prevGState = GameState.ControlMenu;
                    }
                    break;

                case GameState.InGame:


                    // Finite state machine skeleton for each player state (deals with game logic):
                    // Note: These states should only be dealt with in "InGame" state.
                    switch (pState)
                    {
                        case PlayerState.Standing: //standing state

                            // Change Player's sprite to "Standing" sprite:
                            playerCharacter.Texture = playerTexture;


                            // Standing -> Walking:
                            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.D))
                            {
                                pState = PlayerState.Walking;
                                prevKbState = kbState;
                            }

                            // Standing -> Crouching:
                            if (SingleKeyPress(Keys.S))
                            {
                                pState = PlayerState.Crouching;
                                playerCharacter.Position = new Rectangle(playerCharacter.X, playerCharacter.Y + 80, 160, 80);
                                prevKbState = kbState;
                            }

                            if (levels.FinalLevel)
                            {
                                //if there's still stuff in the safe advance it
                                if (SingleKeyPress(Keys.E) && levels.CurrentBackgroundIndex < 3
                                    && playerCharacter.Position.Intersects(new Rectangle(750, 720, 480, 160)))
                                {
                                    levels.CurrentBackgroundIndex++;
                                }
                                //if theres nothing left and they press anything else end the game
                                else if (levels.CurrentBackgroundIndex >= 3 && kbState.GetPressedKeys().Length > 0)
                                {
                                    gState = GameState.GameWon;
                                }
                            }

                            // Standing -> Climbing:
                            if (SingleKeyPress(Keys.E))
                            {

                                if (SingleKeyPress(Keys.E))
                                {

                                    /*for (int i = 0; i < levels.CurrentLevel.Ladders.Count; i++)
                                    {
                                        Ladder ladder = levels.CurrentLevel.Ladders[i];
                                        Ladder nextLadder = null;
                                        //tiles are loaded in top->bottom so the ladder on top is -1
                                        if (i > 0)
                                        {
                                            nextLadder = levels.CurrentLevel.Ladders[i - 1];
                                        }
                                        if (ladder.Interact(playerCharacter))
                                        {
                                            pState = PlayerState.Climbing;
                                        }

                                        //if the player is above the top ladder tile in a ladder
                                        else if (nextLadder != null)
                                        {
                                            if ((nextLadder.X != ladder.X || nextLadder.Y != ladder.Y + nextLadder.Height) &&
                                                playerCharacter.Y + playerCharacter.Height == ladder.Y)
                                            {
                                                pState = PlayerState.Climbing;
                                                playerCharacter.Y += playerCharacter.Height;
                                                break;
                                            }
                                        }
                                    }*/

                                    foreach (Ladder ladder in levels.CurrentLevel.Ladders)
                                    {
                                        if (ladder.Interact(playerCharacter))
                                        {
                                            pState = PlayerState.Climbing;
                                        }
                                    }
                                }
                            }

                            // Standing -> Hiding:
                            //if (levels.CurrentLevel.HidingSpots.Interact(playerCharacter))
                            //pState = PlayerState.Hiding;
                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (HidingSpot hs in levels.CurrentLevel.HidingSpots)
                                {
                                    if (hs.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Hiding;
                                        playerCharacter.IsHidden = true;
                                    }
                                }
                            }



                            break;


                        case PlayerState.Walking: //walking state

                            // Change Player's sprite to "Standing" sprite:
                            playerCharacter.Texture = playerTexture;

                            //move player character
                            playerCharacter.MovePlayer(10);

                            // Walking -> Standing:
                            if ((prevKbState.IsKeyDown(Keys.A) || prevKbState.IsKeyDown(Keys.D)) &&
                                (kbState.IsKeyUp(Keys.A) && kbState.IsKeyUp(Keys.D)))
                            {
                                pState = PlayerState.Standing;
                                prevKbState = kbState;
                            }

                            //walking -> climbing
                            if (SingleKeyPress(Keys.E))
                            {

                                /*for (int i = 0; i < levels.CurrentLevel.Ladders.Count; i++)
                                {
                                    Ladder ladder = levels.CurrentLevel.Ladders[i];
                                    Ladder nextLadder = null;
                                    //tiles are loaded in top->bottom so the ladder on top is -1
                                    if (i > 0)
                                    {
                                        nextLadder = levels.CurrentLevel.Ladders[i - 1];
                                    }
                                    if (ladder.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Climbing;
                                    }

                                    //if the player is above the top ladder tile in a ladder
                                    else if (nextLadder != null)
                                    {
                                        if ((nextLadder.X != ladder.X || nextLadder.Y != ladder.Y + nextLadder.Height) &&
                                            playerCharacter.Y + playerCharacter.Height == ladder.Y)
                                        {
                                            pState = PlayerState.Climbing;
                                            playerCharacter.Y += playerCharacter.Height;
                                            break;
                                        }
                                    }
                                }*/

                                foreach (Ladder ladder in levels.CurrentLevel.Ladders)
                                {
                                    if (ladder.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Climbing;
                                    }
                                }
                            }

                            break;


                        case PlayerState.Hiding:

                            //transition out of hiding
                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (HidingSpot hs in levels.CurrentLevel.HidingSpots)
                                {
                                    if (hs.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Standing;
                                        playerCharacter.IsHidden = false;
                                    }
                                }
                            }

                            break;


                        case PlayerState.Crouching: // Crouching State and Transitions:

                            // * Change character sprite here to "crouching"! *
                            playerCharacter.Texture = crouchTexture;


                            // Crouching -> Standing:
                            if (SingleKeyPress(Keys.W))
                            {
                                pState = PlayerState.Standing;
                                playerCharacter.Position = new Rectangle(playerCharacter.Position.X, playerCharacter.Position.Y - 80, 80, 160);
                                prevKbState = kbState;
                            }

                            // Crouching -> Crawling:
                            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.D))
                            {
                                pState = PlayerState.Crawling;
                                prevKbState = kbState;
                            }

                            // Crouching -> Hiding:
                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (HidingSpot hs in levels.CurrentLevel.HidingSpots)
                                {
                                    if (hs.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Hiding;
                                        playerCharacter.IsHidden = true;
                                    }
                                }
                            }

                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (Vent vent in levels.CurrentLevel.Vents)
                                {
                                    if (vent.Interact(playerCharacter))
                                    {
                                        playerCharacter.X = vent.ConnectingVent.Position.X;
                                        playerCharacter.Y = vent.ConnectingVent.Position.Y;
                                        break;
                                    }
                                }
                            }

                            break;


                        case PlayerState.Crawling: // Crawling State and Transitions:

                            // * Change character sprite here to "crouching"! *

                            // Move player at a slower rate than before:
                            playerCharacter.MovePlayer(5);

                            // Crawling -> Crouching:
                            if ((prevKbState.IsKeyDown(Keys.A) || prevKbState.IsKeyDown(Keys.D)) &&
                                (kbState.IsKeyUp(Keys.A) && kbState.IsKeyUp(Keys.D)))
                            {
                                pState = PlayerState.Crouching;
                                prevKbState = kbState;
                            }

                            // Crawling -> Walking:
                            if (SingleKeyPress(Keys.W))
                            {
                                pState = PlayerState.Walking;
                                playerCharacter.Position = new Rectangle(playerCharacter.Position.X, playerCharacter.Position.Y - 80, 80, 160);
                                prevKbState = kbState;
                            }

                            // Crawling -> Hiding:
                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (HidingSpot hs in levels.CurrentLevel.HidingSpots)
                                {
                                    if (hs.Interact(playerCharacter))
                                    {
                                        pState = PlayerState.Hiding;
                                        playerCharacter.IsHidden = true;
                                    }
                                }
                            }

                            if (SingleKeyPress(Keys.E))
                            {
                                foreach (Vent vent in levels.CurrentLevel.Vents)
                                {
                                    if (vent.Interact(playerCharacter))
                                    {
                                        playerCharacter.X = vent.ConnectingVent.Position.X;
                                        playerCharacter.Y = vent.ConnectingVent.Position.Y;
                                        break;
                                    }
                                }
                            }

                            break;


                        case PlayerState.Climbing: //climbing state
                            playerCharacter.Texture = climbTexture;

                            //moves player on ladder

                            foreach (Ladder ladder in levels.CurrentLevel.Ladders)
                            {
                                ladder.MoveOnLadder(playerCharacter);

                                //state transition to standing
                                //if (playerCharacter.Y >= ladder.Y || playerCharacter.Y + playerCharacter.Height <= ladder.Y + ladder.Height)
                                //{
                                if (SingleKeyPress(Keys.E) && !ladder.Interact(playerCharacter))
                                {
                                    pState = PlayerState.Standing;
                                }
                                //}
                            }



                            break;
                    }


                        //updates cameras when button is pushed
                    if (SingleKeyPress(Keys.E))
                    {
                        foreach(OffSwitch offSwitch in levels.CurrentLevel.OffSwitches)
                        {
                            if(offSwitch.Interact(playerCharacter))
                            {
                                levels.CurrentLevel.SwitchPressed = true;

                                offSwitch.Texture = offSwitch.OffTexture;

                                foreach(CameraEnemy c in allEnemies.allCameras)
                                {
                                    c.Texture = c.OffTexture;
                                }
                                foreach(CameraEnemy sl in allEnemies.allSpotlights)
                                {
                                    sl.Texture = sl.OffTexture;
                                }
                            }
                        }
                    }


                    //game over detection
                    if (allEnemies.UpdateState(playerCharacter, levels.CurrentLevel.Walls, levels.CurrentLevel.SwitchPressed) && !playerCharacter.IsHidden && !godMode)
                    {
                        gState = GameState.GameOver;
                    }

                    //level change check
                    if ((playerCharacter.X + playerCharacter.Width) <=0 || playerCharacter.Position.X >= _graphics.PreferredBackBufferWidth)
                    {
                        ChangeLevels();
                    }

                    //updates other game objects
                    levels.UpdateLevel(playerCharacter);
                    allEnemies.UpdateState(playerCharacter, levels.CurrentLevel.Walls, levels.CurrentLevel.SwitchPressed);

                    //state transition to pause menu
                    if (SingleKeyPress(Keys.Escape))
                    {
                        gState = GameState.PauseMenu;
                        prevGState = GameState.InGame;
                    }

                    //state tranition to notebook
                    if (SingleKeyPress(Keys.Q))
                    {
                        gState = GameState.Notebook;
                        prevGState = GameState.InGame;
                    }

                    break;

                case GameState.PauseMenu: //pause menu state
                    //state transitions
                    gState = pausemenu.Update(mouState, prevMouState, kbState, prevKbState);

                    if (gState == GameState.GameOver)
                    {
                        ResetFromCheckpoint();
                        gState = GameState.InGame;
                    }
                    if (gState != GameState.PauseMenu)
                    {
                        prevGState = GameState.PauseMenu;
                    }
                    break;
                    
                case GameState.GameOver: //game over state             
                    //gets state transition from the game over screen object
                    gState = gameoverscreen.Update(mouState, prevMouState, kbState, prevKbState);

                    ResetFromCheckpoint();
                    break;

                case GameState.GameWon:
                    gState = gameWonScreen.Update(mouState, prevMouState, kbState, prevKbState);
                    break;

                case GameState.Notebook: //notebook state
                    //state transitions
                    gState = notebook.Update(mouState, prevMouState, kbState, prevKbState);
                    if (gState != GameState.Notebook)
                    {
                        prevGState = GameState.Notebook;
                    }
                    break;

                case GameState.Quit:
                    StreamWriter output = new StreamWriter("Content/playersave.txt");
                    try
                    {
                        output.WriteLine(playerCharacter.LastCheckpointLevel);
                        output.WriteLine(playerCharacter.LastSave.X);
                        output.WriteLine(playerCharacter.LastSave.Y);
                        output.Close();
                        Exit();
                    }
                    catch
                    {
                        output.Close();
                        Exit();
                    }
                    break;

            }

            //saves keyboard and mouse states
            prevKbState = kbState;
            prevMouState = mouState;
            UpdateAnimation(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            _spriteBatch.Begin();

            // Finite state machine skeleton for each game state (deals with UI drawing):
            switch (gState)
            {
                case GameState.TitleMenu: //draws main menu
                    mainmenu.Draw(_spriteBatch);
                    break;

                case GameState.ControlMenu: //draws controls screen
                    _spriteBatch.Draw(controlScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
                    break;

                case GameState.Credits: //draws credits screen
                    _spriteBatch.Draw(creditScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
                    break;

                case GameState.InGame: //Draws the game
                case GameState.PauseMenu: //Will draw pause screen over game if it's paused
                case GameState.Notebook: //draws notebook                 

                    levels.DrawLevel(_spriteBatch);

                    if (levels.FirstLevel)
                    {
                        DrawTutorialText(_spriteBatch);
                    }

                    allEnemies.UpdateDrawing(_spriteBatch, currentFrame, currentFrame2);                  

                    // Finite state machine skeleton for each player state (deals with player drawing):
                    // Note: These states should only be dealt with in "InGame" state.                
                    switch (pState)
                    {
                        case PlayerState.Standing: 
                            playerCharacter.Draw(_spriteBatch, 0, false);
                            break;

                        case PlayerState.Walking:
                            playerCharacter.Draw(_spriteBatch, currentFrame, false);
                            break;

                        case PlayerState.Hiding:
                            //don't draw the player here- they are hidden
                            break;

                        case PlayerState.Crouching:
                            playerCharacter.Draw(_spriteBatch, 0, true);
                            //add later
                            break;

                        case PlayerState.Crawling:
                            playerCharacter.Draw(_spriteBatch, currentFrame, true);
                            //add later
                            break;

                        case PlayerState.Climbing:
                            playerCharacter.Draw(_spriteBatch, currentFrame, false);
                            break;
                    }
                    if (gState == GameState.PauseMenu) //Draws pause screen
                    {
                        pausemenu.Draw(_spriteBatch);
                    }
                    if(gState == GameState.Notebook)
                    {
                        notebook.Draw(_spriteBatch);
                    }
                    break;
                case GameState.GameOver: //draws game over screen
                    gameoverscreen.Draw(_spriteBatch);
                    break;

                case GameState.GameWon:
                    gameWonScreen.Draw(_spriteBatch);
                    break;
            }

            base.Draw(gameTime);

            _spriteBatch.End();
        }

        bool SingleKeyPress(Keys key)
        {
            KeyboardState kb = Keyboard.GetState();
            if (prevKbState.IsKeyUp(key) && kb.IsKeyDown(key))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Changes the current level the player is in
        /// </summary>
        public void ChangeLevels()
        {
            //walked off the left side
            if ((playerCharacter.Position.X + playerCharacter.Width) <= 0)
            {
                //if there exists a level to the left side
                if (levels.CurrentLevelIndex > 0)
                {
                    //go backwards a level
                    levels.CurrentLevelIndex -= 1;

                    //move them to the right of the screen
                    playerCharacter.X = 1920;
                }
            }
            //walked off the right side of the screen
            else
            {
                //if there exists a level on the right
                if (levels.CurrentLevelIndex <= levels.AllLevels.Count - 1)
                {
                    //go forward a level
                    levels.CurrentLevelIndex += 1;

                    //move them to the left of the screen
                    playerCharacter.X = 0;
                }
            }

            //change the current level
            levels.CurrentLevel = levels.AllLevels[levels.CurrentLevelIndex];
            //and the background
            if (levels.FinalLevel)
            {
                levels.CurrentBackgroundIndex = 1;
            }
            else
            {
                levels.CurrentBackgroundIndex = 0;
            }

            //update enemies
            allEnemies.ChangeEnemies(levels.CurrentLevel.Enemies, levels.CurrentLevel.DogEnemies, levels.CurrentLevel.CameraEnemies, levels.CurrentLevel.Spotlights);
            levels.CurrentLevel.SwitchPressed = false;
        }

        //resets the game
        private void ResetFromCheckpoint()
        {
            allEnemies.ResetPosition();
            levels.CurrentLevel = levels.AllLevels[playerCharacter.LastCheckpointLevel];
            levels.CurrentLevelIndex = playerCharacter.LastCheckpointLevel;
            allEnemies.ChangeEnemies(levels.CurrentLevel.Enemies, levels.CurrentLevel.DogEnemies, levels.CurrentLevel.CameraEnemies, levels.CurrentLevel.Spotlights);
            playerCharacter.Position = new Rectangle(playerCharacter.Position.X, playerCharacter.Position.Y - 80, 80, 160);
            playerCharacter.X = playerCharacter.LastSave.X;
            playerCharacter.Y = playerCharacter.LastSave.Y;
            pState = PlayerState.Standing;

            if (levels.FinalLevel)
            {
                levels.CurrentBackgroundIndex = 1;
            }
            else
            {
                levels.CurrentBackgroundIndex = 0;
            }
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            // Add to the time counter (need TOTALSECONDS here)
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            // Has enough time gone by to actually flip frames?
            if (timeCounter >= secondsPerFrame)
            {
                // Update the frame and wrap
                currentFrame++;
                currentFrame2++;
                if (currentFrame >= 3) currentFrame = 1;
                if (currentFrame2 >= 5) currentFrame2 = 1;

                // Remove one "frame" worth of time
                timeCounter -= secondsPerFrame;
            }
        }

        private void DrawTutorialText(SpriteBatch sb)
        {
            sb.DrawString(gameFont, "Good job breaking into E.N.D.N.U's base!", new Vector2(150, 700), Color.White);
            sb.DrawString(gameFont, "To save the world, find their secret plans", new Vector2(150, 750), Color.White);
            sb.DrawString(gameFont, "Whatever you do, don't get caught!", new Vector2(150, 800), Color.White);
            sb.DrawString(gameFont, "Press ESC to open the pause menu", new Vector2(150, 850), Color.White);
            sb.DrawString(gameFont, "Press Q to open the notebook", new Vector2(150, 900), Color.White);
            sb.DrawString(gameFont, "^\n^\n^\nE", new Vector2(1230, 800), Color.White);
            sb.DrawString(gameFont, "<<< E", new Vector2(720, 550), Color.White);
            sb.DrawString(gameFont, "S+E\n V\n V\n V", new Vector2(95, 410), Color.White);
            sb.DrawString(gameFont, "W\n^\n^", new Vector2(110, 120), Color.White);
            sb.DrawString(gameFont, "E >>>", new Vector2(225, 180), Color.White);
            sb.DrawString(gameFont, " Save progress\nat  checkpoints!", new Vector2(1360, 210), Color.White);
        }
    }
}
