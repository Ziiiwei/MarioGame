using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Gamespace.Controllers;
using Microsoft.Xna.Framework.Media;
using Gamespace.Multiplayer;

namespace Gamespace
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
  
    public class MarioGame : Game
    {
        private static readonly MarioGame instance = new MarioGame();
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 480 * 2;
        public const float SCALE = 1f;
        private GameTime time;

        private Song song;

        private GraphicsDeviceManager graphics;
        private List<IController> controllers;

        // Make LevelLoader a singleton.
        private LevelLoader levelLoader;

        private float frameRate = 0; //help the animation and detaction rate
        private SpriteFont font; //used to print the framerate

        static MarioGame()
        {
        }
        private MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();
          
            controllers = new List<IController>();
            Content.RootDirectory = "Content";
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

            IPlayer player1 = new Player(new Mario(new Vector2(200, 200)),
                new MultiplayerCamera(0), new SpriteBatch(GraphicsDevice));
            World.Instance.AddPlayer(player1);

            IPlayer player2 = new Player(new Mario(new Vector2(300, 200)),
                new MultiplayerCamera(1), new SpriteBatch(GraphicsDevice));
            World.Instance.AddPlayer(player2);

            levelLoader = new LevelLoader(World.Instance);
            
        }
                /// <summary>

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            /*
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial");
            */
            song = Content.Load<Song>("Super Mario Bros");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.1f;
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
            /*
            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            //camera.Follow(World.Instance.Mario.Sprite);
            spriteBatch.Begin(SpriteSortMode.BackToFront, transformMatrix: camera.Transform * Matrix.CreateScale(SCALE), samplerState: SamplerState.PointClamp);
            World.Instance.DrawWorld(spriteBatch);
            spriteBatch.DrawString(font, "FPS "+frameRate, new Vector2(0, 0), Color.Red);
            spriteBatch.End();
            */
            World.Instance.DrawPlayers();
            base.Draw(gameTime);
        }

        public void SwitchMapping(string bindings)
        {
            foreach (IController controller in controllers)
                controller.SwitchMapping(bindings);
        }

        public void Reset()
        {
            World.Instance.ClearWorld();

            Initialize();


        }
    }
}
