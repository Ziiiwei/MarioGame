using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sounds;

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

        public void Fire(IMario mario)
        {

        }
        public void Jump(IMario mario)
        {
            SoundManager.Instance.PlaySoundEffect("SuperMarioJump");
        }
    }
}
