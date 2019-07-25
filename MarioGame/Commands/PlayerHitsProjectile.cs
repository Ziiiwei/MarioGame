using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    internal class PlayerHitsProjectile : ICommand
    {
        private IMario mario;

        public PlayerHitsProjectile(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.Die();
        }
    }
}
