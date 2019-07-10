using Gamespace.Controllers;
using Gamespace.Views;
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
        public IMario GameObject { get; private set; }
        public IController Controller { get; }
        public ICamera Cam { get; private set; }
        private IView view;
        private Scoreboard scoreboard;
        public SpriteBatch Screen { get; }
        private static int playerCounter = 0;
        private int playerID;
        public int PlayerID { get => playerID % MarioGame.Instance.PlayerCount; }
        private Vector2 resetPoint;
        public int Lives { get; set; }
        private DiscreteTimer viewTimer;
        private bool timerIsArmed = false;

        public Player(IMario gameObject, ICamera cam, SpriteBatch screen)
        {
            GameObject = gameObject;
            GameObject.SetPlayer(this);
            resetPoint = gameObject.PositionOnScreen;
            playerID = playerCounter;
            playerCounter++;
            Lives = 3;
            ShowLives();
            scoreboard = new Scoreboard(Lives);

            Cam = cam;
            Controller = new KeyboardController(this);
            Screen = screen;
            
        }

        public void Update(GameTime gameTime)
        {

            Controller.Update();
            scoreboard.Update(gameTime);
            Cam.Update(GameObject.PositionOnScreen);

            //subject to change later on
            if (GameObject.PositionOnScreen.X < Cam.CameraPosition.X)
                GameObject.CollideLeft(new Rectangle((int)Cam.CameraPosition.X - 1,0,1,MarioGame.WINDOW_HEIGHT));


            if (timerIsArmed)
            {
                viewTimer.Tick();
            }
        }

        public void DrawPlayersScreen()
        {
            Screen.Begin(SpriteSortMode.BackToFront, transformMatrix: Cam.Transform * Matrix.CreateScale(1), samplerState: SamplerState.PointClamp);
            view.Draw(Screen);
            Vector2 fpsCounterPosition = new Vector2(Cam.CameraPosition.X + 50, Cam.CameraPosition.Y + 50);
            Screen.DrawString(MarioGame.Instance.Font, "FPS " + MarioGame.Instance.Framerate, fpsCounterPosition, Color.Red);
            Screen.End();
        }

        public void Release()
        {
            Screen.Dispose();
        }

        public void ShowLives()
        {
            timerIsArmed = true;
            view = new LivesView(Lives);

            viewTimer = new DiscreteTimer(100, new Action(() =>
            {
                view = new PlayableView(scoreboard, Cam);
                timerIsArmed = false;
            }));
        }

        public void UpScore(int score)
        {
            scoreboard.Score += score;
        }

        public void Die()
        {
            scoreboard.Lives--;
        }

        public void Collect()
        {
            scoreboard.Coins++;
        }
    }
}
