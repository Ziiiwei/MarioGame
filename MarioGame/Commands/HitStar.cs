using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.States;

namespace Gamespace.Commands
{
    class HitStar : ICommand
    {
        IMario mario;
        Rectangle collisionArea;

        public HitStar(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }

        public void Execute()
        {
            mario.PowerUpState = new StarMarioState();
            mario.UpdateArt();
        }
    }
}
