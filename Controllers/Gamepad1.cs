using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    class Gamepad1: IController
    {
        private GamePadState gamePadState;
        private Dictionary<Buttons, ICommand> buttonCommands;

        public Gamepad1(params (Buttons button, ICommand command)[] args)
        {
            buttonCommands = new Dictionary<Buttons, ICommand>();

            foreach ((Buttons button, ICommand command) in args)
            {
                buttonCommands.Add(button, command);
            }
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
                        // do something
                        buttonCommands[button].Execute();
                    }
                }
            }
        }
    }
}
