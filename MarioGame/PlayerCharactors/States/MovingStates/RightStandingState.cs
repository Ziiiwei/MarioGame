using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class RightStandingCharacterState : MovingCharacterState
    {
        public RightStandingCharacterState(ICharacter character) : base(character)
        {
        }

        public override void Crouch()
        {
            int previous_h = character.Sprite.Height;
            character.State = new RightCrouchingCharacterState(character);
            character.UpdateArt();
            character.GameObjectPhysics.IncrementMove(Side.Down, Math.Abs(character.Sprite.Height - previous_h));
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
            character.State = new LeftStandingCharacterState(character);
            character.UpdateArt();

        }

        public override void MoveRight()
        {
            character.State = new RightWalkingCharacterState(character);
            character.GameObjectPhysics.Move(Side.Right);
            character.UpdateArt();

        }

        public override void Fire()
        {
            character.Projectiles.Fire(Side.Right);
        }

        public override void ClimbUp()
        {
            character.State = new RightClimbingCharacterState(character);
            character.GameObjectPhysics.Climb(Side.Up);
            character.UpdateArt();
        }

    }
}
