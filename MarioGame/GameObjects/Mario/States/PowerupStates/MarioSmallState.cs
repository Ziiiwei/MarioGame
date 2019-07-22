using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sounds;

namespace Gamespace.States
{
    class MarioSmallState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.State = new MarioDeadState(mario);
            mario.UpdateArt();
        }

        public void PowerUp(IMario mario)
        {
            mario.PowerUpState = new MarioSuperState();
            mario.UpdateArt();
        }

        public void Fire(IMario mario)
        {

        }

        public void Jump(IMario mario)
        {
            SoundManager.Instance.PlaySoundEffect("SmallMarioJump");
         
        }
    }
}
