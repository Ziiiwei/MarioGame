using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class LeftStandingCharacterState : MovingCharacterState
    {
        public LeftStandingCharacterState(ICharacter character) : base(character)
        {
        }

        public override void Crouch()
        {
            int previous_h = character.Sprite.Height;
            character.State = new LeftCrouchingCharacterState(character);
            character.UpdateArt();
            character.GameObjectPhysics.IncrementMove(Side.Down,Math.Abs(character.Sprite.Height - previous_h));
        }

        public override void Jump()
        {
            character.State = new LeftJumpingCharacterState(character);
            character.GameObjectPhysics.Jump();
            character.PowerUpState.Jump(character);
            character.UpdateArt();
        }

        public override void MoveLeft()
        {
            character.State = new LeftWalkingCharacterState(character);
            character.GameObjectPhysics.Move(Side.Left);
            character.UpdateArt();
        }

        public override void MoveRight()
        {
            character.State = new RightStandingCharacterState(character);
            character.UpdateArt();
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
