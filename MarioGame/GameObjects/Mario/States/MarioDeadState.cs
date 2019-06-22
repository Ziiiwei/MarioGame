using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class MarioDeadState :IMarioState
    {
        private IMario mario;

        public MarioDeadState(IMario mario)
        {
            this.mario = mario;
            mario.UpdateArt();
            MarioGame.Instance.SwitchMapping();
        }

        public void Crouch()
        {
            
        }

        public void Jump()
        {
            
        }

        public void MoveLeft()
        {
            
        }

        public void MoveRight()
        {
            
        }
    }
}

