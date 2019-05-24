using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;

namespace Sprint0
{
    class Gamepad1: IController
    {
        private GamePadState gamePadState;
        private Dictionary<Buttons, ICommand> buttonCommands;

        public Gamepad1(Game game)
        {
            buttonCommands = new Dictionary<Buttons, ICommand>();

            buttonCommands.Add(Buttons.Start, new QuitGame(game));
            buttonCommands.Add(Buttons.A, new Display(game));
            buttonCommands.Add(Buttons.B, new Animate(game));
            buttonCommands.Add(Buttons.X, new Move(game));
            buttonCommands.Add(Buttons.Y, new MoveAndAnimate(game));
        }

        public void Update()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsConnected)
            {
                foreach (Buttons button in buttonCommands.Keys)
                {
                    if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button))
                    {
                        buttonCommands[button].Execute();
                    }
                }
            }
        }
    }
}
