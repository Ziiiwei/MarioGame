using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.States;

namespace Gamespace.Commands
{
    class MakeMarioStar : ICommand
    {
        private IMario mario;
        public MakeMarioStar(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario = new StarMario(mario,mario.PositionOnScreen);
        }
    }
}
