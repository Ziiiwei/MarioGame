using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;
using Gamespace.States;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class LeftStandingCharacterState : LeftStandingMarioState
    {
        public LeftStandingCharacterState(IMario mario) : base(mario)
        {
        }

    }
}
