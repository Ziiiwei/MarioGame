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
        private List<Buttons> previouslyPressed;
        private List<Buttons> pressed;

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
            buttonCommands = new Dictionary<Buttons, ICommand>()
            {
                {Buttons.Start, new PauseGameCommand(player.GameObject) },
                {Buttons.Back, new QuitGame(player.GameObject) },
                {Buttons.DPadUp, new MarioJumpCommand(player.GameObject) },
                {Buttons.LeftThumbstickUp, new MarioJumpCommand(player.GameObject) },
                {Buttons.DPadDown, new MarioCrouchCommand(player.GameObject) },
                {Buttons.LeftThumbstickDown, new MarioCrouchCommand(player.GameObject) },
                {Buttons.DPadLeft, new MarioMoveLeftCommand(player.GameObject) },
                {Buttons.LeftThumbstickLeft, new MarioMoveLeftCommand(player.GameObject) },
                {Buttons.DPadRight, new MarioMoveRightCommand(player.GameObject) },
                {Buttons.LeftThumbstickRight, new MarioMoveRightCommand(player.GameObject) },
                {Buttons.A, new MarioFireCommand(player.GameObject) },
                {Buttons.RightShoulder, new MarioFireCommand(player.GameObject) }
            };
            previouslyPressed = new List<Buttons>();
            pressed = new List<Buttons>();
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
                    if (gamePadState.IsButtonDown(button))
                        pressed.Add(button);

                    /*
                    if (gamePadState.IsButtonDown(button) && !previousState.IsButtonDown(button))
                    {
                        buttonCommands[button].Execute();
                    }
                    */
                }

                foreach (Buttons button in pressed)
                {
                    if (buttonCommands.ContainsKey(button))
                    {
                        if (!nonHoldableCommands.Contains(buttonCommands[button].GetType()) || !previouslyPressed.Contains(button))
                        {
                            buttonCommands[button].Execute();
                        }
                    }
                }

                previouslyPressed = pressed;
                pressed.Clear();
            }
            previousState = gamePadState;
        }
      
    }
}
