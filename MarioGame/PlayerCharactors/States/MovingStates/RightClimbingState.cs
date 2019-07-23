using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Characters
{
    class RightClimbingCharacterState : MovingCharacterState
    {
        public RightClimbingCharacterState(ICharacter character) : base(character)
        {
            this.character = character;
        }

        public override void ClimbUp()
        {
            character.GameObjectPhysics.Climb(Side.Up);
        }

        public override void ClimbDown()
        {
            character.GameObjectPhysics.Climb(Side.Down);
        }

        public override void MoveLeft()
        {
            character.GameObjectPhysics.Move(Side.Left);
            character.State = new LeftJumpingCharacterState(character);
            character.UpdateArt();
        }

        public override void Land()
        {
            character.State = new RightStandingCharacterState(character);
            character.UpdateArt();
        }
    }
}
