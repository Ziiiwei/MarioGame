using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.States;

namespace Gamespace.Characters
{
    class LeftClimbingCharacterState : MovingCharacterState
    {
        public LeftClimbingCharacterState(ICharacter character) :base(character)
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

        public override void MoveRight()
        {
            character.GameObjectPhysics.Move(Side.Right);
            character.State = new RightJumpingCharacterState(character);
            character.UpdateArt();
        }

        public override void Land()
        {
            character.State = new LeftStandingCharacterState(character);
            character.UpdateArt();
        }
    }
}
