using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;

namespace Sprint0
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<IController> controllers;
        ISprite sprite;
        List<Texture2D> textures;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            controllers = new List<IController>();
            Content.RootDirectory = "Content";
            textures = new List<Texture2D>();
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
            controllers.Add(new Keyboard1(this));
            controllers.Add(new Gamepad1(this));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textures.Add(Content.Load<Texture2D>("SonicDead"));
            textures.Add(Content.Load<Texture2D>("SonicRoll"));



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

            // Need to create null sprite.
            if (sprite != null)
            {
                sprite.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Azure);

            spriteBatch.Begin();
            if (sprite != null)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Move()
        {
            sprite = new MovingNotAnimated1(textures[0], 1, 1, new Vector2(400, 200));
        }

        public void Animate()
        {
            sprite = new AnimatedNotMoving1(textures[1], 1, 6, new Vector2(400, 200));
        }

        public void MoveAndAnimate()
        {
            sprite = new MovingAnimated1(textures[1], 1, 6, new Vector2(400, 200));
        }

        public void Appear()
        {
            sprite = new NotMovingNorAnimated1(textures[0], 1, 1, new Vector2(400, 200));
        }
    }
}
