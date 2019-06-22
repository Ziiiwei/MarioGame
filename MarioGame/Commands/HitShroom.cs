using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.States; 

namespace Gamespace.Commands
{
    class HitShroom : ICommand
    {
        IMario mario;
        CollisionData collisionData;

        public HitShroom(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            mario.PowerUpState.PowerUp(mario);
        }
    }
}
