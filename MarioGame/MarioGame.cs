using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Gamespace.Controllers;

namespace Gamespace
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

   
    public class MarioGame : Game
    {
        private static readonly MarioGame instance = new MarioGame();
        public const int WINDOW_WIDTH = 1600;
        public const int WINDOW_HEIGHT = 960;
        public const float SCALE = 1f;

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private List<IController> controllers;

        private Camera camera;

        // Get screen height and width for camera
        public static int ScreenHeight;

        public static int ScreenWidth;

    
        // Make LevelLoader a singleton.
        private LevelLoader levelLoader;

        private float frameRate = 0; //help the animation and detaction rate
        private SpriteFont font; //used to pirnt the framerate

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
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            levelLoader = new LevelLoader(World.Instance);
            camera = new Camera();
            controllers.Add(new KeyboardController(this));
            controllers.Add(new GamepadController(this));
            
        }
                /// <summary>

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial");
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
            foreach( IController controller in controllers)
            {
                controller.Update();
            }
            World.Instance.UpdateWorld();
            camera.Update(World.Instance.Mario.GetCenter());
            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            //camera.Follow(World.Instance.Mario.Sprite);
            spriteBatch.Begin(SpriteSortMode.Immediate, transformMatrix: camera.Transform * Matrix.CreateScale(1.0f));
            World.Instance.DrawWorld(spriteBatch);
            spriteBatch.DrawString(font, "FPS "+frameRate, new Vector2(0, 0), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            World.Instance.ClearWorld();
            controllers = new List<IController>();
            // TODO : This needs to go away.
            Initialize();


        }
    }
}
