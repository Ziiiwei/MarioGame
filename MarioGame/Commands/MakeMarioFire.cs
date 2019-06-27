using Gamespace;
using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MakeMarioFire : ICommand
    {
        private IMario mario;
        public MakeMarioFire(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.PowerUpState = new MarioFireState();
            mario.UpdateArt();
        }
    }
}
