using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.States;

namespace Gamespace.Characters
{
    class LeftJumpingCharacterState : LeftJumpingMarioState
    {
        public LeftJumpingCharacterState(IMario mario) : base(mario)
        {
        }
    }
}
