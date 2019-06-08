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
        IMario mario;
        Rectangle collisionArea;

        public HitFlower(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }
        
        public void Execute()
        {
            mario.PowerUpState = new MarioFireState();
            mario.UpdateArt();
        }
    }
}
