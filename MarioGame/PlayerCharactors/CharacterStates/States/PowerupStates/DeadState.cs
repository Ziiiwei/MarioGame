using Gamespace.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class DeadState : MarioDeadState
    {
        public DeadState(IMario mario) : base(mario)
        {
             mario.UpdateArt();
             mario.Die();
        }


    }
}

