using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;

namespace Sprint0
{
    class Keyboard1 : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;

        public Keyboard1(Game game)
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(game));
            keyCommands.Add(Keys.W, new Display(game));
            keyCommands.Add(Keys.E, new Animate(game));
            keyCommands.Add(Keys.R, new Move(game));
            keyCommands.Add(Keys.T, new MoveAndAnimate(game));
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if(keyCommands.ContainsKey(key))
                {
                    keyCommands[key].Execute();
                }
            }
        }

    }
}
