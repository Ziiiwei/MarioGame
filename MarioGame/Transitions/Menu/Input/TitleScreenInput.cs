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
    internal class TitleScreenInput : IController
    {
        private readonly GameMenu menu;
        private Dictionary<PlayerIndex, GamePadState> previousGamePadStates;
        private KeyboardState previousKeyboardState;

        public TitleScreenInput(GameMenu menu)
        {
            this.menu = menu;
            previousGamePadStates = new Dictionary<PlayerIndex, GamePadState>()
            {
                { PlayerIndex.One, GamePad.GetState(PlayerIndex.One) },
                { PlayerIndex.Two, GamePad.GetState(PlayerIndex.Two) },
                { PlayerIndex.Three, GamePad.GetState(PlayerIndex.Three) },
                { PlayerIndex.Four, GamePad.GetState(PlayerIndex.Four) }
            };

            previousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                GamePadState gamePadState = GamePad.GetState(i);
                if (gamePadState != previousGamePadStates[i])
                {
                    menu.SelectionEntered();
                }
            }

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState != previousKeyboardState)
            {
                menu.SelectionEntered();
            }

        }
    }
}
