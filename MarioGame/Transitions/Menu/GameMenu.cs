using Gamespace.Controllers;
using Gamespace.Data;
using Gamespace.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Transitions
{
    internal class GameMenu
    {
        private enum MenuState { Title, Count, Arena, Character };
        private Dictionary<MenuState, Delegate> stateTransitions;
        private MenuState currentState;
        private enum InputDirection { Up, Down };

        public int PlayerCount { get; private set; }
        public int ArenaSelected { get; private set; }
        public Dictionary<PlayerIndex, Type> playerCharacterSelection { get; private set; }

        private Dictionary<Tuple<MenuState, InputDirection>, Delegate> inputAction;
        private IView view;
        private IController input;

        public GameMenu()
        {
            currentState = MenuState.Title;
            view = new ContinueScreen();
            input = new TitleScreenInput(this);
            PlayerCount = 0;

            stateTransitions = new Dictionary<MenuState, Delegate>()
            {
                {MenuState.Title, new Action(TitleToCountTransition) },
                {MenuState.Count, new Action(CountToArenaTransition) },
                {MenuState.Arena, new Action(TitleToCountTransition) },
                {MenuState.Character, new Action(TitleToCountTransition) }

            };

            inputAction = new Dictionary<Tuple<MenuState, InputDirection>, Delegate>()
            {
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Up),
                    new Action(() => PlayerCount = Math.Max(PlayerCount - 1, 0)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Count, InputDirection.Down),
                    new Action(() => PlayerCount = Math.Min(Numbers.MAX_PLAYERS, PlayerCount + 1)) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Up), new Action(() => view = null) },
                {new Tuple<MenuState, InputDirection>(MenuState.Arena, InputDirection.Down), new Action(() => view = null) },
                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Up), new Action(() => view = null) },
                {new Tuple<MenuState, InputDirection>(MenuState.Character, InputDirection.Down), new Action(() => view = null) },
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

        public void Update()
        {
            input.Update();
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

        private void TitleToCountTransition()
        {
            currentState = MenuState.Count;
            view = new PlayerCountSelection(this);
            input = new MenuInputController(this);
        }

        private void CountToArenaTransition()
        {
            currentState = MenuState.Arena;
            view = new PlayerCountSelection(this);
        }
    }
}
