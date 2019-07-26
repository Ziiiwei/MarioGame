﻿using Gamespace.Controllers;
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
        private enum MenuState {Intro, Title, Count, Arena, Character, Complete, Credit};
        private Dictionary<MenuState, Delegate> stateTransitions;
        private MenuState currentState;

        private LevelLoader levelLoader;
        
        private int StartingTime = Numbers.STARTING_TIME;
        private enum InputDirection { Up, Down };

        public int PlayerCount { get; private set; }
        public int ArenaSelected { get; private set; }
        public int Time { get; private set; }

        public Dictionary<PlayerIndex, Type> playerCharacterSelection { get; private set; }
        public List<Type> PlayableCharacters { get; }

        private Dictionary<Tuple<MenuState, InputDirection>, Delegate> inputAction;
        private IView view;
        private IController input;

        private Dictionary<MenuState, Delegate> goBack;



        public GameMenu()
        {
            SoundManager.Instance.PlayMainBGM();
            currentState = MenuState.Intro;
            view = new IntroScene();
            input = new TitleScreenInput(this);
            PlayerCount = 1;
            ArenaSelected = 0;
            Time = StartingTime;

            PlayableCharacters = new List<Type>()
            {
                typeof(Scout),
                typeof(Soldier),
                typeof(Tank),
                typeof(Thief),
            };

            stateTransitions = new Dictionary<MenuState, Delegate>()
            {
                {MenuState.Intro, new Action(IntroToCreditTransition) },
                {MenuState.Credit, new Action(CreditToTitleTransition) },
                {MenuState.Title, new Action(TitleToCountTransition) },
                {MenuState.Count, new Action(CountToArenaTransition) },
                {MenuState.Arena, new Action(ArenaToCharacterTransition) },
                {MenuState.Character, new Action(SelectionsComplete) },

            };

            goBack = new Dictionary<MenuState, Delegate>()
            {
                {MenuState.Arena, new Action(()=> { currentState = MenuState.Count; view = new PlayerCountSelection(this); }) },
                {MenuState.Character, new Action(()=> { currentState = MenuState.Arena; view = new ArenaSelection(this); }) }
            };

            inputAction = new Dictionary<Tuple<MenuState, InputDirection>, Delegate>()
            {
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Up),
                    new Action<PlayerIndex>((i) => PlayerCount = Math.Max(PlayerCount - 1, 1)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Down),
                    new Action<PlayerIndex>((i) => PlayerCount = Math.Min(Numbers.MAX_PLAYERS, PlayerCount + 1)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Up),
                    new Action<PlayerIndex>((i) => ArenaSelected = Math.Max(ArenaSelected - 1, 0)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Down),
                    new Action<PlayerIndex>((i) => ArenaSelected = Math.Min(ArenaSelected + 1, MarioGame.Instance.ArenaPaths.Count)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Up), new Action<PlayerIndex>((i) => { HandlePlayerCharacterSwitch(i, Side.Up); }) },
                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Down), new Action<PlayerIndex>((i) => { HandlePlayerCharacterSwitch(i, Side.Down); }) },
            };

            playerCharacterSelection = new Dictionary<PlayerIndex, Type>()
            {
                {PlayerIndex.One, PlayableCharacters[0] },
                {PlayerIndex.Two, PlayableCharacters[0] },
                {PlayerIndex.Three, PlayableCharacters[0] },
                {PlayerIndex.Four, PlayableCharacters[0] }
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
                if ((int)gt.TotalGameTime.TotalSeconds == Numbers.INTRO_CREDIT)
                {
                    IntroToCreditTransition();
                }
            }
            else if (currentState == MenuState.Credit)
            {
                if ((int)gt.TotalGameTime.TotalSeconds == Numbers.TITLE_TIME)
                {
                    CreditToTitleTransition();
                }
            
            } 
        }

        public void SelectionUp(PlayerIndex i)
        {
            
            var key = new Tuple<MenuState, InputDirection>(currentState, InputDirection.Up);
            if (inputAction.ContainsKey(key))
            {
                inputAction[key].DynamicInvoke(i);
            }
            SoundManager.Instance.PlaySoundEffect("BumpBlock");
        }

        public void SelectionDown(PlayerIndex i)
        {
            var key = new Tuple<MenuState, InputDirection>(currentState, InputDirection.Down);
            if (inputAction.ContainsKey(key))
            {
                inputAction[key].DynamicInvoke(i);
            }
            SoundManager.Instance.PlaySoundEffect("BumpBlock");
        }

        public void SelectionEntered()
        {
            stateTransitions[currentState].DynamicInvoke();
        }

        public void Back()
        {
            if (goBack.ContainsKey(currentState))
            {
                goBack[currentState].DynamicInvoke();
            }
        }

        private void IntroToCreditTransition()
        {
            currentState = MenuState.Credit;
            view = new CreditScene();



        }
        private void CreditToTitleTransition()
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
            SoundManager.Instance.StopMainBGM();
            SoundManager.Instance.PlaySelectBGM();
        }

        private void CountToArenaTransition()
        {
            currentState = MenuState.Arena;
            view = new ArenaSelection(this);
            
        }

        private void ArenaToCharacterTransition()
        {
            currentState = MenuState.Character;
            view = new CharacterSelection(this);
        }

        private void SelectionsComplete()
        {
            MarioGame.Instance.OnMenuSelectionsComplete();
            SoundManager.Instance.StopSelectBGM();
            SoundManager.Instance.PlaySoundEffect("OutOfTime");
        }

        private void HandlePlayerCharacterSwitch(PlayerIndex i, Side side)
        {
            Type current = playerCharacterSelection[i];
            int previousIndex = PlayableCharacters.IndexOf(current);

            if (side == Side.Up)
            {
                playerCharacterSelection[i] = PlayableCharacters[Math.Max(0,  previousIndex - 1)];
            }
            else
            {
                playerCharacterSelection[i] = PlayableCharacters[Math.Min(previousIndex + 1, PlayableCharacters.Count)];
            }
        }
    }
}
