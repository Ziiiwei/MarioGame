using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class MarioDeadState : MovingMarioState
    {
        public MarioDeadState(IMario mario) : base(mario)
        {
            mario.UpdateArt();
        }


    }
}

