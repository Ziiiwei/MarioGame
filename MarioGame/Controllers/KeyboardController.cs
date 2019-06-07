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
        private Dictionary<String, ICommand> keyCommands;
        private Keys[] previouslyPressed;
        private List<String> commandToExcute;

        public KeyboardController(MarioGame game, World world)
        {
            // we are going to data drive this, users can customize controls in games.
            keyCommands = new Dictionary<String, ICommand>();
            keyCommands.Add("Q_Click", new QuitGame(game));

            keyCommands.Add("W_Release", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("W_Click", new MarioJumpCommand(world.Mario));
            keyCommands.Add("W_Hold", new MarioJumpCommand(world.Mario));

            keyCommands.Add("S_Hold", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("S_Release", new MarioJumpCommand(world.Mario));
            keyCommands.Add("S_Click", new MarioCrouchCommand(world.Mario));

            keyCommands.Add("A_Click", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("A_Hold", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("A_Release", new MarioMoveRightCommand(world.Mario));

            keyCommands.Add("D_Click", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("D_Hold", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("D_Release", new MarioMoveLeftCommand(world.Mario));

            keyCommands.Add("Up_Release", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("Up_Click", new MarioJumpCommand(world.Mario));
            keyCommands.Add("Up_Hold", new MarioJumpCommand(world.Mario));

            keyCommands.Add("Down_Click", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("Down_Hold", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("Down_Release", new MarioJumpCommand(world.Mario));

            keyCommands.Add("Left_Click", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("Left_Hold", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("Left_Release", new MarioMoveRightCommand(world.Mario));

            keyCommands.Add("Right_Click", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("Right_Hold", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("Right_Release", new MarioMoveLeftCommand(world.Mario));

            keyCommands.Add("Y_Click", new MakeMarioSmall(world.Mario));
            keyCommands.Add("U_Click", new MakeMarioBig(world.Mario));
            keyCommands.Add("I_Click", new MakeMarioFire(world.Mario));
            keyCommands.Add("R_Click", new Reset(game));
 

            commandToExcute = new List<String>();
            previouslyPressed = new Keys[0];
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if (previouslyPressed.Contains(key))
                {
                    commandToExcute.Add(key.ToString() + "_Hold");
                } else
                {
                    commandToExcute.Add(key.ToString() + "_Click");
                }

            }


            foreach (Keys key in previouslyPressed)
            {
                if (!pressed.Contains(key))
                {
                    commandToExcute.Add(key.ToString() + "_Release");
                }
            }
            

            foreach(String s in commandToExcute)
            {
                if (keyCommands.ContainsKey(s))
                {
                    keyCommands[s].Execute();
                }
            }

            commandToExcute.Clear();
            previouslyPressed = pressed;

            
        }

    }
}
