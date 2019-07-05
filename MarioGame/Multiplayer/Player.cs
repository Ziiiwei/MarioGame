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
        public int PlayerID { get; }
        public SpriteFont font;

        public Player(IMario gameObject, ICamera cam, SpriteBatch screen, SpriteFont spriteFont)
        {
            GameObject = gameObject;
            PlayerID = playerCounter;
            playerCounter++;
            Cam = cam;
            Controller = new KeyboardController(this);
            Screen = screen;
            font = spriteFont;
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
            Screen.DrawString(font, "Score " + GameObject.score.ToString("D6"),new Vector2(Cam.Position().X + (MarioGame.WINDOW_WIDTH / 2),
                0), Color.GhostWhite);
            Screen.End();
        }
    }
}
