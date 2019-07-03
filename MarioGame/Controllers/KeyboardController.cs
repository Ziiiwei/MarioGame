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


        public KeyboardController(IPlayer player)
        {
            currentBindings = KeyAssignmentFactory.Instance.GetBindings(player);
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
