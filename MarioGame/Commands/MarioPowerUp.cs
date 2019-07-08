using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioPowerUp : ICommand
    {
        private IMario mario;

        public MarioPowerUp(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.PowerUp();
        }
    }
}
