using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.Characters
{
    class RightJumpingCharacterState : MovingCharacterState
    {
        public RightJumpingCharacterState(ICharacter character) : base(character)
        {
        }

        public override void Jump()
        {
            ((MarioPhysics)character.GameObjectPhysics).KeepJump();
        }
        public override void MoveLeft()
        {
            character.State = new LeftJumpingCharacterState(character);
            character.UpdateArt();
        }

        public override void MoveRight()
        {
            character.GameObjectPhysics.Move(Side.Right);
        }

        public override void Land()
        {
            if (character.GameObjectPhysics.Velocity.X != 0)
            {
                character.State = new RightWalkingCharacterState(character);
                character.UpdateArt();
            }
            else
            {
                character.State = new RightStandingCharacterState(character);
                character.UpdateArt();
            }
        }

    

        public override void Fire()
        {
            character.Launcher.Fire(Projectiles.ShootAngle.Right);
        }

        public override bool Jumpable()
        {
            return false;
        }
    }
}
