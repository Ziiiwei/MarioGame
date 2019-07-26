/* Referenced: https://stackoverflow.com/questions/4232795/how-to-iterate-over-each-active-gamepad-in-xna */
using Gamespace.Controllers;
using Gamespace.Transitions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class MenuInputController : IController
    {

        private readonly Dictionary<Keys, Delegate> keyBinds;
        private readonly Dictionary<Buttons, Delegate> buttonBinds;
        private readonly GameMenu menu;
        private KeyboardState previousKeyboardState;
        private List<GamePadState> previousGamePadStates;


        public MenuInputController(GameMenu menu)
        {
            this.menu = menu;

            /* Keyboard is always considered player 1 */

            keyBinds = new Dictionary<Keys, Delegate>()
            {
                {Keys.W, new Action<PlayerIndex>((i) => menu.SelectionUp(i)) },
                {Keys.S, new Action<PlayerIndex>((i) => menu.SelectionDown(i)) },
                {Keys.R, new Action<PlayerIndex>((i) => menu.Reset()) },
                {Keys.Enter, new Action<PlayerIndex>((i) => menu.SelectionEntered()) }
            };

            buttonBinds = new Dictionary<Buttons, Delegate>()
            {
                {Buttons.DPadUp, new Action<PlayerIndex>((i) => menu.SelectionUp(i)) },
                {Buttons.LeftThumbstickUp, new Action<PlayerIndex>((i) => menu.SelectionUp(i)) },
                {Buttons.DPadDown, new Action<PlayerIndex>((i) => menu.SelectionDown(i)) },
                {Buttons.LeftThumbstickDown, new Action<PlayerIndex>((i) => menu.SelectionDown(i)) },
                {Buttons.Start, new Action<PlayerIndex>((i) => menu.SelectionEntered()) },
                {Buttons.B, new Action<PlayerIndex>((i) => menu.Reset()) },
                {Buttons.A, new Action<PlayerIndex>((i) => menu.SelectionEntered()) }
            };

            previousKeyboardState = Keyboard.GetState();
            previousGamePadStates = new List<GamePadState>();
            previousGamePadStates.Add(new GamePadState());
            previousGamePadStates.Add(new GamePadState());
            previousGamePadStates.Add(new GamePadState());
            previousGamePadStates.Add(new GamePadState());
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (keyBinds.ContainsKey(key) && !previousKeyboardState.IsKeyDown(key))
                {
                    keyBinds[key].DynamicInvoke(0);
                }
            }

            previousKeyboardState = keyboardState;
            int playerNum = 0;
            for (PlayerIndex i = PlayerIndex.One; i < PlayerIndex.Four; i++)
            {
                GamePadState gamePadState = GamePad.GetState(i);

                foreach (Buttons button in buttonBinds.Keys)
                {

                    if (gamePadState.IsButtonDown(button) && !previousGamePadStates[playerNum].IsButtonDown(button))
                    {
                        buttonBinds[button].DynamicInvoke(i + 1);
                    }
                }
                previousGamePadStates[playerNum] = gamePadState;
                playerNum++;
            }
        }
    }
}
