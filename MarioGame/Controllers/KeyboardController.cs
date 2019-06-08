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

        public KeyboardController(MarioGame game)
        {
            // we are going to data drive this, users can customize controls in games.
            keyCommands = new Dictionary<String, ICommand>();
            keyCommands.Add("Q_Click", new QuitGame(game));

            keyCommands.Add("W_Release", new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add("W_Click", new MarioJumpCommand(World.Instance.Mario));
            keyCommands.Add("W_Hold", new MarioJumpCommand(World.Instance.Mario));

            keyCommands.Add("S_Hold", new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add("S_Release", new MarioJumpCommand(World.Instance.Mario));
            keyCommands.Add("S_Click", new MarioCrouchCommand(World.Instance.Mario));

            keyCommands.Add("A_Click", new MarioMoveLeftCommand(World.Instance.Mario));
            keyCommands.Add("A_Hold", new MarioMoveLeftCommand(World.Instance.Mario));
            keyCommands.Add("A_Release", new MarioMoveRightCommand(World.Instance.Mario));

            keyCommands.Add("D_Click", new MarioMoveRightCommand(World.Instance.Mario));
            keyCommands.Add("D_Hold", new MarioMoveRightCommand(World.Instance.Mario));
            keyCommands.Add("D_Release", new MarioMoveLeftCommand(World.Instance.Mario));

            keyCommands.Add("Up_Release", new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add("Up_Click", new MarioJumpCommand(World.Instance.Mario));
            keyCommands.Add("Up_Hold", new MarioJumpCommand(World.Instance.Mario));

            keyCommands.Add("Down_Click", new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add("Down_Hold", new MarioCrouchCommand(World.Instance.Mario));
            keyCommands.Add("Down_Release", new MarioJumpCommand(World.Instance.Mario));

            keyCommands.Add("Left_Click", new MarioMoveLeftCommand(World.Instance.Mario));
            keyCommands.Add("Left_Hold", new MarioMoveLeftCommand(World.Instance.Mario));
            keyCommands.Add("Left_Release", new MarioMoveRightCommand(World.Instance.Mario));

            keyCommands.Add("Right_Click", new MarioMoveRightCommand(World.Instance.Mario));
            keyCommands.Add("Right_Hold", new MarioMoveRightCommand(World.Instance.Mario));
            keyCommands.Add("Right_Release", new MarioMoveLeftCommand(World.Instance.Mario));

            keyCommands.Add("Y_Click", new MakeMarioSmall(World.Instance.Mario));
            keyCommands.Add("U_Click", new MakeMarioBig(World.Instance.Mario));
            keyCommands.Add("I_Click", new MakeMarioFire(World.Instance.Mario));
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
