using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    internal class EnemyHitsMario : ICommand
    {
        private IMario mario;
        private CollisionData collisionData;
        
        public EnemyHitsMario(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            mario.PowerDown();
        }

    }
}
