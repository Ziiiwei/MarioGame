using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.States;



namespace Gamespace.Commands
{
    class HitFlower : ICommand
    {

        private IMario mario;
        private CollisionData collisionData;

        public HitFlower(IMario mario, CollisionData collisionData)
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
