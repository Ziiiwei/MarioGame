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
        public const int WINDOW_HEIGHT = Numbers.HEIGHT * Numbers.CAMERA_FACTOR;
        // since this is one, I do not believe it is a magic number
        public const float SCALE = 1f;
        private GameTime time;


        public GraphicsDeviceManager graphics { get; }

        public int PlayerCount { get; private set; }

        // Make LevelLoader a singleton.
        private LevelLoader levelLoader;

        public float Framerate { get; private set; }
        public SpriteFont Font { get; private set; }

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
            //TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); 
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

            PlayerCount = Numbers.PLAYERS_IN_GAME;

            IPlayer player1 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_ONE_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player1);

            IPlayer player2 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_TWO_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player2);

            levelLoader = new LevelLoader(World.Instance);
            
        }
                /// <summary>

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            Font = Content.Load<SpriteFont>("Pixel");
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
            World.Instance.UpdatePlayers(gameTime);
            World.Instance.UpdateWorld();
            base.Update(gameTime);
            time = gameTime;
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Framerate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            World.Instance.DrawPlayers();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            World.Instance.ClearWorld();

            IPlayer player1 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_ONE_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player1);

            IPlayer player2 = new Player(typeof(Mario), new SpriteBatch(GraphicsDevice), new Vector2(Numbers.PLAYER_TWO_X, Numbers.STARTING_Y));
            World.Instance.AddPlayer(player2);

            levelLoader = new LevelLoader(World.Instance);
            SoundManager.Instance.PlayMainBGM();  

        }
    }
}
