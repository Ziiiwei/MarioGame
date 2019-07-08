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
        private readonly Dictionary<Keys, ICommand> currentBindings;
        private static readonly List<Type> nonHoldableCommands;
        private List<Keys> previouslyPressed;

        static KeyboardController()
        {
            nonHoldableCommands = new List<Type>()
            {
                typeof(PauseGameCommand)
            };
        }

        public KeyboardController(IPlayer player)
        {
            currentBindings = KeyAssignmentFactory.Instance.GetBindings(player);
            previouslyPressed = new List<Keys>();
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressed)
            {
                if (currentBindings.ContainsKey(key))
                {
                    if (pressed.Contains(Keys.P))
                    {
                        int i = 1;
                    }

                    if (!nonHoldableCommands.Contains(currentBindings[key].GetType()) || !previouslyPressed.Contains(key))
                    {
                        currentBindings[key].Execute();
                    }
                }
            }
            previouslyPressed.Clear();
            foreach (Keys key in pressed)
            {
                previouslyPressed.Add(key);
            }
        }
    }
}
