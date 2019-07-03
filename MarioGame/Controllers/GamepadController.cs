using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Gamespace.Controllers
{
    class GamepadController: IController
    {
        private GamePadState gamePadState;
        private GamePadState previousState;
        private Dictionary<Buttons, ICommand> buttonCommands;

        public GamepadController(MarioGame game)
        {

        }

        public bool CommandOverRide(string comand)
        {
            return false;
        }


        public void SwitchMapping(string bindings)
        {
            // Need to implement
        }

        public void Update()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsConnected)
            {
                foreach (Buttons button in buttonCommands.Keys)
                {
                    if (gamePadState.IsButtonDown(button) && !previousState.IsButtonDown(button))
                    {
                        buttonCommands[button].Execute();
                    }
                }
            }
            previousState = gamePadState;
        }
      
    }
}
