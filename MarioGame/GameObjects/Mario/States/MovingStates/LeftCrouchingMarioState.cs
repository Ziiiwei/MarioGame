using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.States
{
    class LeftCrouchingMarioState : MovingMarioState
    {

  
        public LeftCrouchingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }

        public override void Jump()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.State = new RightCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Stand()
        {
            int previous_h = mario.Sprite.Height;
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
            mario.GameObjectPhysics.IncrementMove(Side.Up, Math.Abs(previous_h - mario.Sprite.Height));
         

        }

        public override void Fire()
        {
            mario.Projectiles.Fire(Side.Left);
        }
    }
}
