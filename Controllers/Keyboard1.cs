using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Sprint2.Commands;

namespace Sprint2
{
    class Keyboard1 : IController
    {
        private Dictionary<Keys, ICommand> keyCommands;
        private List<Keys> previouslyPressed;

        public Keyboard1(MarioGame game, World world)
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(game));
            keyCommands.Add(Keys.W, new MarioJumpCommand(world.Mario));
            keyCommands.Add(Keys.S, new MarioCrouchCommand(world.Mario));
            keyCommands.Add(Keys.A, new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add(Keys.D, new MarioMoveRightCommand(world.Mario));
            keyCommands.Add(Keys.Y, new MakeMarioSmall(world.Mario));
            keyCommands.Add(Keys.U, new MakeMarioBig(world.Mario));
            keyCommands.Add(Keys.I, new MakeMarioFire(world.Mario));


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
}
