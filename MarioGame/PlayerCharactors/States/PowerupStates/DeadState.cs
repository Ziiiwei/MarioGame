using Gamespace.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class DeadState : MovingCharacterState
    {
        public DeadState(ICharacter character) : base(character)
        {
            character.UpdateArt();
            character.Die();
        }


    }
}

