using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Gamespace.Commands;
using Gamespace.Blocks;
using Gamespace.Multiplayer;

namespace Gamespace.Controllers
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;
        private Dictionary<Keys, ICommand> lockedKeyCommands;
        private Dictionary<Keys, ICommand> currentBindings;
        private Dictionary<string, Dictionary<Keys, ICommand>> bindingsSelector;
        private IMario gameObject;

        public KeyboardController(IPlayer player)
        {
            /* exposes a weakness, FIX */
            gameObject = (IMario) player.GameObject;
            lockedKeyCommands = new Dictionary<Keys, ICommand>();
            lockedKeyCommands.Add(Keys.Q, new QuitGame(MarioGame.Instance));
            lockedKeyCommands.Add(Keys.R, new Reset(MarioGame.Instance));

            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(MarioGame.Instance));
            keyCommands.Add(Keys.W, new MarioJumpCommand(gameObject));
            keyCommands.Add(Keys.S, new MarioCrouchCommand(gameObject));
            keyCommands.Add(Keys.A, new MarioMoveLeftCommand(gameObject));
            keyCommands.Add(Keys.D, new MarioMoveRightCommand(gameObject));
            keyCommands.Add(Keys.Space, new MarioFireCommand(gameObject));
            keyCommands.Add(Keys.R, new Reset(MarioGame.Instance));

            currentBindings = keyCommands;

            bindingsSelector = new Dictionary<string, Dictionary<Keys, ICommand>>()
            {
                {"alive", keyCommands },
                {"dead", lockedKeyCommands }
            };

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
