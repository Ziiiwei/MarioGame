using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Sprint2.Commands;

namespace Sprint2
{
    class Keyboard2 : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;
        private List<Keys> previouslyPressed;

        public Keyboard2(MarioGame game, Goomba goomba)
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(game));

            keyCommands.Add(Keys.A, new GoombaChangeDirection(goomba));
            keyCommands.Add(Keys.D, new GoombaChangeDirection(goomba));
            keyCommands.Add(Keys.S, new GoombaGetStomped(goomba));
     

            previouslyPressed = new List<Keys>();
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if(keyCommands.ContainsKey(key) && !previouslyPressed.Contains(key))
                {
                    keyCommands[key].Execute();
                }
            }
            previouslyPressed.Clear();
            foreach(Keys key in pressed)
            {
                previouslyPressed.Add(key);
            }
        }

    }
    //test commit
}
