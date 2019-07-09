using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class StarMarioState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            // do nothing
        }

        public void PowerUp(IMario mario)
        {
            // Do nothing
        }
        public void Jump(IMario mario)
        {
            SoundFactory.Instance.PlaySoundEffect("SuperMarioJump");
            mario.GameObjectPhysics.MoveMaxSpeed(Side.Up);
        }
    }
}
