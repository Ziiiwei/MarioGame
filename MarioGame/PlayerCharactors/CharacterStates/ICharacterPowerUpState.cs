using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public interface ICharacterPowerUpState
    {
        void PowerUp(ICharacter character);
        void PowerDown(ICharacter character);
        void Fire(ICharacter character);
        void Jump(ICharacter character);
    }
}
