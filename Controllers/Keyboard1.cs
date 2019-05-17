using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    class Keyboard1 : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;
        public Keyboard1(params (Keys key, ICommand command)[] args)
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            foreach ((Keys key, ICommand command) in args)
            {
                keyCommands.Add(key, command);
            }

        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressed)
            {
                if(keyCommands.ContainsKey(key))
                {
                    // run command
                    keyCommands[key].Execute();

                    
                }
            }
        }

    }
}
