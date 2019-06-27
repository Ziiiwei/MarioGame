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
        Mario mario;
        public MakeMarioStar(IMario mario, CollisionData collisionData)
        {
            this.mario = (Mario) mario;
        }
        public void Execute()
        {
            // Need to change this.
        }
    }
}
