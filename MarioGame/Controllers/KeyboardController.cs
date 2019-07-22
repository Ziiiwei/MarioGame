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
        private List<Keys> previouslyPressed =  new List<Keys>();



        static KeyboardController()
        {
            nonHoldableCommands = new List<Type>()
            {
                typeof(PauseGameCommand),
                typeof(PlayTestAnimation),
               
              
            };
        }

        public KeyboardController(IPlayer player)
        {
            currentBindings = KeyAssignmentFactory.Instance.GetBindings(player);
            
        }

        public KeyboardController(IPlayer player, bool keyActivation)
        {
            if (keyActivation)
            {
                currentBindings = KeyAssignmentFactory.Instance.GetBindings(player);
            } else
            {
                currentBindings = KeyAssignmentFactory.Instance.GetPausedBinding(player);
            }
         
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressed)
            {
                if (currentBindings.ContainsKey(key))
                {
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
