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

        public Game()
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
            // TODO: Add your initialization logic here
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


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your drawing code here
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
            Texture2D texture = Content.Load<Texture2D>("SonicDead");
            sprite = new MovingNotAnimated1(texture, 1, 1, new Vector2(400, 200));
        }

        public void Animate()
        {
            Texture2D texture = Content.Load<Texture2D>("SonicRoll");
            sprite = new AnimatedNotMoving1(texture, 1, 6, new Vector2(400, 200));
        }

        public void MoveAndAnimate()
        {
            Texture2D texture = Content.Load<Texture2D>("SonicRoll");
            sprite = new MovingAnimated1(texture, 1, 6, new Vector2(400, 200));
        }

        public void Appear()
        {

            Texture2D texture = Content.Load<Texture2D>("SonicDead");
            sprite = new NotMovingNorAnimated1(texture, 1, 1, new Vector2(400, 200));

        }
    }
}
