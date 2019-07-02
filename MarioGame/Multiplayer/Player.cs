using Gamespace.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Multiplayer
{
    internal class Player : IPlayer
    {
        public IMario GameObject { get; }
        public IController Controller { get; }
        /* Need to make an interface for camera */
        public ICamera Cam { get; }
        public SpriteBatch Screen { get; }
        private static int playerCounter = 0;
        private int playerID;

        public Player(IMario gameObject, Camera cam, SpriteBatch screen)
        {
            GameObject = gameObject;
            Controller = new KeyboardController(this);
            Cam = cam;
            playerID = playerCounter;
            playerCounter++;
            Screen = screen;
        }

        public void Update()
        {
            Controller.Update();
            GameObject.Update();
            Cam.Update(GameObject);
        }

        public void DrawPlayersScreen()
        {
            Screen.Begin(SpriteSortMode.BackToFront, transformMatrix: Cam.Transform * Matrix.CreateScale(1), samplerState: SamplerState.PointClamp);
            World.Instance.DrawWorld(Screen);
            //spriteBatch.DrawString(font, "FPS " + frameRate, new Vector2(0, 0), Color.Red);
            Vector2 offsets = new Vector2(MarioGame.WINDOW_WIDTH * playerID, MarioGame.WINDOW_HEIGHT * playerID);
            GameObject.Draw(Screen);
            Screen.End();
        }
    }
}
