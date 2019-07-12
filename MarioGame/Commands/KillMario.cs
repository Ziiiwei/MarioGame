using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.States;

namespace Gamespace.Commands
{
    internal class KillMario : ICommand
    {
        private IMario mario;

        public KillMario(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            this.mario.Die();
           
        }
    }
}

