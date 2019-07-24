using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Microsoft.Xna.Framework;

namespace Gamespace.Characters
{
    class RightCrouchingCharacterState : MovingCharacterState
    {


        public RightCrouchingCharacterState(ICharacter character) : base(character)
        {
            this.character = character;
        }
        public override void Jump()
        {
            character.State = new RightStandingCharacterState(character);
            character.UpdateArt();
        }

        public override void MoveLeft()
        {
            character.State = new LeftCrouchingCharacterState(character);
            character.UpdateArt();
        }

        public override void Fire()
        {
            character.Launcher.Fire(Projectiles.ShootAngle.Right);
        }

        public override void Stand()
        {
            int previous_h = character.Sprite.Height;
            character.State = new RightStandingCharacterState(character);
            character.UpdateArt();
            character.GameObjectPhysics.IncrementMove(Side.Up, Math.Abs(previous_h - character.Sprite.Height));
          
        }

    }
}
