using Gamespace.Controllers;
using Gamespace.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace.Multiplayer
{
  
    internal class Player : IPlayer
    {
        public IMario GameObject { get; private set; }
        public IController Controller { get; private set; }
        public ICamera Cam { get; private set; }
        private IView view;
        private Scoreboard scoreboard;
        public SpriteBatch Screen { get; }
        private static int playerCounter = 0;
        private int playerID;
        public int PlayerID { get => playerID % MarioGame.Instance.PlayerCount; }
        private Vector2 spawnPoint;
        public int Lives { get; set; }
        private DiscreteTimer viewTimer;
        private bool timerIsArmed = false;
        private IController disabledController;
        private Action controllerUpdate;
        public Player(Type character, SpriteBatch screen, Vector2 spawnPoint)
        {
            Lives = Numbers.LIVES_STOCK;
            scoreboard = new Scoreboard(Lives);
            GameObject = (IMario) Activator.CreateInstance(character, spawnPoint, scoreboard);
            playerID = playerCounter;
            playerCounter++;
            ShowLives();
            this.spawnPoint = spawnPoint;
            Cam = new MultiplayerCamera(PlayerID, new Vector2(Numbers.CAMERA_START_X, 0));
            Controller = new KeyboardController(this);
            disabledController = new KeyboardController(this, false);
            controllerUpdate = ()=> Controller.Update();
            Screen = screen;
        }

        public void Update(GameTime gameTime)
        {
            controllerUpdate.Invoke();
            scoreboard.Update(gameTime);
            Lives = scoreboard.Lives;
            Cam.Update(GameObject.PositionOnScreen);

            //subject to change later on
            if (GameObject.PositionOnScreen.X < Cam.CameraPosition.X)
                GameObject.CollideLeft(new Rectangle((int)Cam.CameraPosition.X - 1,0,1,MarioGame.WINDOW_HEIGHT));

            if (timerIsArmed)
            {
                viewTimer.Tick();
            }

            if (Lives == 0)
            {
                view = new DeadView();
            }
        }

        public void DrawPlayersScreen()
        {
            Screen.Begin(SpriteSortMode.BackToFront, transformMatrix: Cam.Transform * Matrix.CreateScale(1), samplerState: SamplerState.PointClamp);
            view.Draw(Screen);
            Vector2 fpsCounterPosition = new Vector2(Cam.CameraPosition.X + Numbers.COUNTER_OFFSET, Cam.CameraPosition.Y + Numbers.COUNTER_OFFSET);
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

            viewTimer = new DiscreteTimer(Numbers.DISCREET_TIMER_START, new Action(() =>
            {
                view = new PlayableView(scoreboard, Cam);
                timerIsArmed = false;
            }));
        }

        public void Respawn()
        {
            GameObject = (IMario)Activator.CreateInstance(GameObject.GetType(), spawnPoint, scoreboard);
            ShowLives();
            Cam = new MultiplayerCamera(PlayerID, new Vector2(Numbers.CAMERA_START_X, 0));
            Controller = new KeyboardController(this);
        }

        public void DisableGameControl()
        {
            controllerUpdate = () => disabledController.Update();
        }

        public void ResumeControl()
        {
            controllerUpdate = () => Controller.Update();
        }
    }
}
