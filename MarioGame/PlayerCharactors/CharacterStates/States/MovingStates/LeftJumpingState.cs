using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;


namespace Gamespace.Characters
{
    class LeftJumpingCharacterState : MovingCharacterState
    {
        public LeftJumpingCharacterState(ICharacter character) : base(character)
        {
        }

        public override void Jump()
        {
           ((MarioPhysics)character.GameObjectPhysics).KeepJump();
        }

        public override void MoveLeft()
        {
            character.GameObjectPhysics.Move(Side.Left);
        }
        public override void MoveRight()
        {
            character.State = new RightJumpingCharacterState(character);
            character.UpdateArt();
        }


        public override void Land()
        {
            if (character.GameObjectPhysics.Velocity.X != 0)
            {
                character.State = new LeftWalkingCharacterState(character);
                character.UpdateArt();
            }
            else
            {
                character.State = new LeftStandingCharacterState(character);
                character.UpdateArt();
            }
        }

        public override void Fire()
        {
            character.Projectiles.Fire(Side.Left);
        }

        public override bool Jumpable()
        {
            return false;
        }
    }
}
