using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class LeftWalkingCharacterState : MovingCharacterState
    {
        public LeftWalkingCharacterState(ICharacter character) : base(character)
        {
        }

        public override void Jump()
        {
            character.PowerUpState.Jump(character);
            character.State = new LeftJumpingCharacterState(character);
            character.GameObjectPhysics.Jump();
            character.UpdateArt();
        }

        public override void MoveRight()
        {
            character.State = new LeftStandingCharacterState(character);
            character.UpdateArt();
        }

        public override void MoveLeft()
        {
            character.GameObjectPhysics.Move(Side.Left);
        }

        public override void FrictionStop()
        {
            if (character.GameObjectPhysics.Velocity.X == 0)
            {
                character.State = new LeftStandingCharacterState(character);
                character.UpdateArt();
            }
        }

        public override void Fire()
        {
            character.Projectiles.Fire(Side.Left);
        }

        public override void ClimbUp()
        {
            character.State = new LeftClimbingCharacterState(character);
            character.GameObjectPhysics.Climb(Side.Up);
            character.UpdateArt();
        }
    }
}
