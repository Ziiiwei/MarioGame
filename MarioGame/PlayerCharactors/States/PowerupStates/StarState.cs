using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sounds;

namespace Gamespace.States
{
    class StarCharacterState : ICharacterPowerUpState
    {
        public void PowerDown(ICharacter character)
        {
            // do nothing
        }

        public void PowerUp(ICharacter character)
        {
            // Do nothing
        }

        public void Fire(ICharacter character)
        {

        }
        public void Jump(ICharacter character)
        {
            SoundManager.Instance.PlaySoundEffect("SuperCharacterJump");
        }
    }
}
