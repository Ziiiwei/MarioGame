using Gamespace;
using Gamespace.Commands;
using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Commands
{
    class MakeMarioDead : ICommand
    {
        IMario mario;
        public MakeMarioDead(IMario mario, Rectangle r)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State = new MarioDeadState();
            mario.UpdateArt();
        }
    }
}
