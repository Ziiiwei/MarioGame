using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sounds;

namespace Gamespace.States
{
    class MarioFireState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.PowerUpState = new MarioSuperState();
            mario.UpdateArt();
        }

        public void PowerUp(IMario mario)
        {
            // Do nothing
        }

        public void Fire(IMario mario)
        {
            mario.State.Fire();
        }
        public void Jump(IMario mario)
        {
            SoundManager.Instance.PlaySoundEffect("SuperMarioJump");
            mario.GameObjectPhysics.Jump();
        }
    }
}
