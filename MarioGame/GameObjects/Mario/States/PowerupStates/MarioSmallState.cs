using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SoundFactory.Instance.PlaySoundEffect("SmallMarioJump");
            mario.GameObjectPhysics.MoveMaxSpeed(Side.Up);
        }
    }
}
