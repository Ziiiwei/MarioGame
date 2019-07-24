/* Saving original viewport taken from rbwhitaker.wikidot.com/viewport-split-screen  */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Gamespace.Controllers;
using Gamespace.Multiplayer;
using Gamespace.Sounds;
using Gamespace.Data;
using System;
using Gamespace.Transitions;

namespace Gamespace
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
  
    public class MarioGame : Game
    {
        private static readonly MarioGame instance = new MarioGame();
        public const int WINDOW_WIDTH = Numbers.WIDTH;
        // there are currently two cameras, and I think that is another reason for the camera factor here
        public const int WINDOW_HEIGHT = Numbers.HEIGHT;
        // since this is one, I do not believe it is a magic number
        public const float SCALE = 1f;
        private GameTime time;
        public GraphicsDeviceManager graphics { get; }
        public int PlayerCount { get; set; }
        private LevelLoader levelLoader;
        public float Framerate { get; private set; }
        public SpriteFont Font { get; private set; }
        public Dictionary<int, Tuple<string, string>> ArenaPaths { get; private set; }
        public Bezel SplitScreenBezel { get; set; }

        private GameMenu menu;
        private delegate void GameUpdate(GameTime gameTime);
        private delegate void GameDraw();
        private SpriteBatch menuSpriteBatch;
        private GameUpdate gameUpdate;
        private GameDraw gameDraw;
        
        static MarioGame()
        {
        }
        private MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            Framerate = 0;
        }

        public static MarioGame Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            ArenaPaths = new Dictionary<int, Tuple<string, string>>()
            {
                {0, new Tuple<string, string>("Arena One", "MarioGame/Data/DataFiles/level1.csv") },
                {1, new Tuple<string, string>("Arena Two", "MarioGame/Data/DataFiles/level1.csv") },
                {2, new Tuple<string, string>("Arena Three", "MarioGame/Data/DataFiles/level1.csv") }
            };

            PlayerCount = 1;

            menuSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            menu = new GameMenu();

            gameUpdate += UpdateGameMenu;
            gameDraw += DrawGameMenu;

            levelLoader = new LevelLoader(World.Instance, "MarioGame/Data/DataFiles/MenuBackground.csv");

        }

        public void OnMenuSelectionsComplete()
        {
            gameUpdate -= UpdateGameMenu;
            gameDraw -= DrawGameMenu;

            World.Instance.ClearWorld();

            MenuToMatchHandoff handoff = new MenuToMatchHandoff(menu, graphics.GraphicsDevice);

            gameUpdate += UpdateGameWorld;
            gameDraw += DrawGameWorld;
        }

        /// <summary>

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            Font = Content.Load<SpriteFont>("Arial");
            SoundManager.Instance.PlayMainBGM();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gameUpdate.Invoke(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Framerate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;


            gameDraw.Invoke();
        }

        public void Reset()
        {
            World.Instance.ClearWorld();

            IPlayer player1 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_ONE_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player1);

            IPlayer player2 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_TWO_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player2);

            levelLoader = new LevelLoader(World.Instance, "MarioGame/Data/DataFiles/level1.csv");
            SoundManager.Instance.PlayMainBGM();  

        }

        private void UpdateGameWorld(GameTime gameTime)
        {
            World.Instance.UpdatePlayers(gameTime);
            World.Instance.UpdateWorld();
        }

        private void UpdateGameMenu(GameTime gameTime)
        {
            World.Instance.UpdateWorld();
            menu.Update();
        }

        private void DrawGameWorld()
        {
            Viewport viewport = GraphicsDevice.Viewport;
            World.Instance.DrawPlayers();
            GraphicsDevice.Viewport = viewport;
        }

        private void DrawGameMenu()
        {
            menuSpriteBatch.Begin();
            World.Instance.DrawWorld(menuSpriteBatch);
            menu.Draw(menuSpriteBatch);
            menuSpriteBatch.End();
        }
    }
}
