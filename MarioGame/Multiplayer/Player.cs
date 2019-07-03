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
        public ICamera Cam { get; }
        public SpriteBatch Screen { get; }
        private static int playerCounter = 0;
        private int playerID;

        public Player(IMario gameObject, ICamera cam, SpriteBatch screen)
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
            Cam.Update(GameObject.PositionOnScreen);
        }

        public void DrawPlayersScreen()
        {
            Screen.Begin(SpriteSortMode.BackToFront, transformMatrix: Cam.Transform * Matrix.CreateScale(1), samplerState: SamplerState.PointClamp);
            World.Instance.DrawWorld(Screen);
            //spriteBatch.DrawString(font, "FPS " + frameRate, new Vector2(0, 0), Color.Red);
            Screen.End();
        }
    }
}
