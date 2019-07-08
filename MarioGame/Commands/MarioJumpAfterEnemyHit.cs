using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioJumpAfterEnemyHit : ICommand
    {
        private IMario mario;

        public MarioJumpAfterEnemyHit(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Bounce();
        }
    }
}
