using Gamespace.Controllers;
using Gamespace.Data;
using Gamespace.Views;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Part of the transitions idea was taken from https://stackoverflow.com/questions/37047017/monogame-cut-scene-methods
 */

namespace Gamespace.Transitions
{
    internal class GameMenu
    {
        private enum MenuState {Intro, Title, Count, Arena, Character, Complete };
        private Dictionary<MenuState, Delegate> stateTransitions;
        private MenuState currentState;

        private LevelLoader levelLoader;

        private GameTime gameTime;
        
        private int StartingTime = Numbers.STARTING_TIME;
        private enum InputDirection { Up, Down };

        public int PlayerCount { get; private set; }
        public int ArenaSelected { get; private set; }
        public int Time { get; private set; }
        public Dictionary<PlayerIndex, Type> playerCharacterSelection { get; private set; }

        private Dictionary<Tuple<MenuState, InputDirection>, Delegate> inputAction;
        private IView view;
        private IController input;

   

        public GameMenu()
        {
            SoundManager.Instance.PlayMainBGM();
            currentState = MenuState.Intro;
            view = new IntroScene();
            input = new TitleScreenInput(this);
            PlayerCount = 1;
            ArenaSelected = 0;
            Time = StartingTime;

            stateTransitions = new Dictionary<MenuState, Delegate>()
            {
                {MenuState.Intro, new Action(IntroToTitleTransition) },
                {MenuState.Title, new Action(TitleToCountTransition) },
                {MenuState.Count, new Action(CountToArenaTransition) },
                {MenuState.Arena, new Action(ArenaToCharacterTransition) },
                {MenuState.Character, new Action(SelectionsComplete) },

            };

            inputAction = new Dictionary<Tuple<MenuState, InputDirection>, Delegate>()
            {
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Up),
                    new Action(() => PlayerCount = Math.Max(PlayerCount - 1, 1)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Down),
                    new Action(() => PlayerCount = Math.Min(Numbers.MAX_PLAYERS, PlayerCount + 1)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Up),
                    new Action(() => ArenaSelected = Math.Max(ArenaSelected - 1, 0)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Down),
                    new Action(() => ArenaSelected = Math.Min(ArenaSelected + 1, MarioGame.Instance.ArenaPaths.Count)) },

                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Up), new Action(() => { }) },
                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Down), new Action(() => { }) },
            };
        }

        /* This is to be removed */
        public void Reset()
        {
            MarioGame.Instance.OnMenuSelectionsComplete();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            view.Draw(spriteBatch);
        }

        public void Update(GameTime gt)
        {
            input.Update();
            if (currentState == MenuState.Intro)
            {
                if ((int)gt.TotalGameTime.TotalSeconds == Numbers.INTRO_TIME)
                {
                    IntroToTitleTransition();
                }
            }
        }

        public void SelectionUp(PlayerIndex i)
        {
            
            var key = new Tuple<MenuState, InputDirection>(currentState, InputDirection.Up);
            if (inputAction.ContainsKey(key))
            {
                inputAction[key].DynamicInvoke();
            }
        }

        public void SelectionDown(PlayerIndex i)
        {
            var key = new Tuple<MenuState, InputDirection>(currentState, InputDirection.Down);
            if (inputAction.ContainsKey(key))
            {
                inputAction[key].DynamicInvoke();
            }
        }

        public void SelectionEntered()
        {
            stateTransitions[currentState].DynamicInvoke();
        }

        private void IntroToTitleTransition()
        {
            currentState = MenuState.Title;
            levelLoader = new LevelLoader(World.Instance, "MarioGame/Data/DataFiles/MainMenu.csv");
            view = new ContinueScreen();
            input = new TitleScreenInput(this);


        }

        private void TitleToCountTransition()
        {
            currentState = MenuState.Count;
            view = new PlayerCountSelection(this);
            input = new MenuInputController(this);
        }

        private void CountToArenaTransition()
        {
            currentState = MenuState.Arena;
            view = new ArenaSelection(this);
            SoundManager.Instance.StopMainBGM();
            SoundManager.Instance.PlaySelectBGM();
            
        }

        private void ArenaToCharacterTransition()
        {
            currentState = MenuState.Character;
            view = new PlayerCountSelection(this);
        }

        private void SelectionsComplete()
        {
            MarioGame.Instance.OnMenuSelectionsComplete();
            SoundManager.Instance.StopSelectBGM();
            SoundManager.Instance.PlayArenaBGM(); 
        }
    }
}
