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
    class Keyboard1 : IController
    {
        private Dictionary<String, ICommand> keyCommands;
        private Keys[] previouslyPressed;
        private List<String> commandToExcute;

        public Keyboard1(MarioGame game, World world)
        {
            keyCommands = new Dictionary<String, ICommand>();
            keyCommands.Add("Q", new QuitGame(game));
            keyCommands.Add("W_Release", new MarioJumpCommand(world.Mario));
            keyCommands.Add("W_Hold", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("S_Click", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("A_Click", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("D_Click", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("UP_Click", new MarioJumpCommand(world.Mario));
            keyCommands.Add("Down_Click", new MarioCrouchCommand(world.Mario));
            keyCommands.Add("Left_Click", new MarioMoveLeftCommand(world.Mario));
            keyCommands.Add("Right_Click", new MarioMoveRightCommand(world.Mario));
            keyCommands.Add("Y_Click", new MakeMarioSmall(world.Mario));
            keyCommands.Add("U_Click", new MakeMarioBig(world.Mario));
            keyCommands.Add("I_Click", new MakeMarioFire(world.Mario));
            keyCommands.Add("Z_Click", new HitBlock(world.Block1));
            keyCommands.Add("X_Click", new HitBlock(world.Block2));
            keyCommands.Add("C_Click", new HitBlock(world.Block3)); 
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
