using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.Characters
{
    class LeftCrouchingCharacterState : MovingCharacterState
    {

  
        public LeftCrouchingCharacterState(ICharacter character) : base(character)
        {
            this.character = character;
        }

        public override void Jump()
        {
            character.State = new LeftStandingCharacterState(character);
            character.UpdateArt();
        }

        public override void MoveRight()
        {
            character.State = new RightCrouchingCharacterState(character);
            character.UpdateArt();
        }

        public override void Stand()
        {
            int previous_h = character.Sprite.Height;
            character.State = new LeftStandingCharacterState(character);
            character.UpdateArt();
            character.GameObjectPhysics.IncrementMove(Side.Up, Math.Abs(previous_h - character.Sprite.Height));
         

        }

        public override void Fire()
        {
            character.Launcher.Fire(Projectiles.ShootAngle.Left);
        }
    }
}
