using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Multiplayer;

namespace Gamespace.Commands
{
    class MarioAddLife: ICommand
    {

        private IMario mario;

        public MarioAddLife(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.scoreboard.AddLife();
        }
    }
}
