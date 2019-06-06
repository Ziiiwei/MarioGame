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
        private List<Keys> previouslyPressed;

        public KeyboardController(MarioGame game, World world)
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            keyCommands.Add(Keys.Q, new QuitGame(game));
            keyCommands.Add(Keys.W, new MarioJumpCommand(world.Mario));
            keyCommands.Add(Keys.S, new MarioCrouchCommand(world.Mario));
            keyCommands.Add(Keys.A, new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add(Keys.D, new MarioMoveRightCommand(world.Mario));
            keyCommands.Add(Keys.Up, new MarioJumpCommand(world.Mario));
            keyCommands.Add(Keys.Down, new MarioCrouchCommand(world.Mario));
            keyCommands.Add(Keys.Left, new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add(Keys.Right, new MarioMoveRightCommand(world.Mario));
            keyCommands.Add(Keys.Y, new MakeMarioSmall(world.Mario));
            keyCommands.Add(Keys.U, new MakeMarioBig(world.Mario));
            keyCommands.Add(Keys.I, new MakeMarioFire(world.Mario));
            keyCommands.Add(Keys.Z, new HitBlock(world.QuestionBlock));
            keyCommands.Add(Keys.X, new HitBlock(world.BrickBlock));
            keyCommands.Add(Keys.C, new HitBlock(world.HiddenBlock)); 
            keyCommands.Add(Keys.R, new Reset(game));


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
