using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class RightWalkingCharacterState : MovingCharacterState
    {
        public RightWalkingCharacterState(ICharacter character) : base(character)
        {
            this.character = character;
        }
        public override void Jump()
        {
            character.State = new RightJumpingCharacterState(character);
            character.GameObjectPhysics.Jump();
            character.PowerUpState.Jump(character);
            character.UpdateArt();
        }
        public override void MoveLeft()
        {
            character.State = new RightStandingCharacterState(character);
            character.GameObjectPhysics.Stop(Side.Left);
            character.UpdateArt();
        }

        public override void MoveRight()
        {
            character.GameObjectPhysics.Move(Side.Right);
        }

        public override void FrictionStop()
        {
            if (character.GameObjectPhysics.Velocity.X == 0)
            {
                character.State = new RightStandingCharacterState(character);
                character.UpdateArt();
            }
        }

        public override void Fire()
        {
            character.Projectiles.Fire(Side.Right);
        }
    }
}
