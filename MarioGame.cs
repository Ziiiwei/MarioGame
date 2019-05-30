using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MarioGame : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch TheSpriteBatch { get; private set; }
        private List<IController> controllers;
        public World TheWorld { get; set; }
    
        // Make LevelLoader a singleton.
        private LevelLoader levelLoader;

        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            controllers = new List<IController>();
            Content.RootDirectory = "Content";
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
            SpriteFactory.Instance.SetGameInstance(this);
            TheWorld = new World(this);
            levelLoader = new LevelLoader(TheWorld);
            controllers.Add(new Keyboard1(this, TheWorld));

            controllers.Add(new Gamepad1(this));
            
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            TheSpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach( IController c in controllers)
            {
                c.Update();
            }

            TheWorld.UpdateWorld();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Azure);
            TheSpriteBatch.Begin();
            TheWorld.DrawWorld();
            TheSpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
