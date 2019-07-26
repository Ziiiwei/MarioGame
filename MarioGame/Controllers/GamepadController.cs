using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Gamespace.Multiplayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Gamespace.Controllers
{
    class GamepadController: IController
    {
        private GamePadState gamePadState;
        private GamePadState previousState;
        private Dictionary<Buttons, ICommand> buttonCommands;
        private static readonly List<Type> nonHoldableCommands;
        private readonly IPlayer player;

        static GamepadController()
        {
            nonHoldableCommands = new List<Type>()
            {
                typeof(PauseGameCommand),
                typeof(PlayTestAnimation),
            };
        }

        public GamepadController(IPlayer player)
        {
            this.player = player;
            buttonCommands = new Dictionary<Buttons, ICommand>()
            {
                {Buttons.Start, new PauseGameCommand(player.GameObject) },
                {Buttons.Back, new QuitGame(player.GameObject) },
                {Buttons.DPadUp, new MarioJumpCommand(player.GameObject) },
                {Buttons.DPadDown, new MarioCrouchCommand(player.GameObject) },
                {Buttons.DPadLeft, new MarioMoveLeftCommand(player.GameObject) },
                {Buttons.DPadRight, new MarioMoveRightCommand(player.GameObject) },
                {Buttons.A, new MarioFireCommand(player.GameObject) }
            };
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
            gamePadState = GamePad.GetState((PlayerIndex)player.PlayerID + 1);

            if (gamePadState.IsConnected)
            {
                foreach (Buttons button in buttonCommands.Keys)
                {
                    if (gamePadState.IsButtonDown(button))
                    {
                        buttonCommands[button].Execute();
                    }
                }
            }

        }
      
    }
}
