using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Gamespace.Commands;
using Gamespace.Blocks;

namespace Gamespace.Controllers
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;
        private Dictionary<Keys, ICommand> lockedKeyCommands;
        private Dictionary<Keys, ICommand> currentBindings;
        private Dictionary<string, Dictionary<Keys, ICommand>> bindingsSelector;

        public KeyboardController(MarioGame game)
        {
            lockedKeyCommands = new Dictionary<Keys, ICommand>();
            lockedKeyCommands.Add(Keys.Q, new QuitGame(MarioGame.Instance));
            lockedKeyCommands.Add(Keys.R, new Reset(MarioGame.Instance));

            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(game));
            keyCommands.Add(Keys.W, new MarioJumpCommand(World.Instance.Mario));
            keyCommands.Add(Keys.S, new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add(Keys.A, new MarioMoveLeftCommand(World.Instance.Mario));
            keyCommands.Add(Keys.D, new MarioMoveRightCommand(World.Instance.Mario));
            keyCommands.Add(Keys.R, new Reset(game));

            currentBindings = keyCommands;

            bindingsSelector = new Dictionary<string, Dictionary<Keys, ICommand>>()
            {
                {"alive", keyCommands },
                {"dead", lockedKeyCommands }
            };

        }

        public bool CommandOverRide(string comand)
        {
            return false;
        }


        public void SwitchMapping(string bindings)
        {
            currentBindings = bindingsSelector[bindings];
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressed)
            {

                if (currentBindings.ContainsKey(key))
                {
                    currentBindings[key].Execute();
                }
            }

        }
    }
}
