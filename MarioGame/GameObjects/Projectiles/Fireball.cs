using Gamespace.Projectiles;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace.Projectiles
{
    internal class Fireball : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        private static readonly Dictionary<ShootAngle, Type> initialOrientation;
        private int bounceCounter = 0;
        private int bounceBound = Numbers.BOUNCE_BOUND;

        public ShootAngle Angle { get ; set; }

        static Fireball()
        {
            initialOrientation = new Dictionary<ShootAngle, Type>()
            {
                {ShootAngle.Left, typeof(LeftMovingProjectile) },
                {ShootAngle.Right, typeof(RightMovingProjectile) },
                {ShootAngle.LeftUp, typeof(LeftUpMovingProjectile) },
                {ShootAngle.RightUp, typeof(RightUpMovingProjectile) },
                {ShootAngle.Up,typeof(UpMovingProjectile) }

            };
        }

        public Fireball(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen)
        {
            State = (IProjectileState) Activator.CreateInstance(initialOrientation[angle], this);
            SoundManager.Instance.PlaySoundEffect("Fireball");
            SetSprite();
        }

        public void ChangeDirection(ShootAngle angle)
        {
            State.ChangeDirection(angle);
        }

        public void Move(Side side)
        {
            GameObjectPhysics.MoveMaxSpeed(side);
        }

        protected override void SetSprite()
        {
            Sprite =  SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        protected override void SurrogateUpdate()
        {
            if (bounceCounter < bounceBound)
            {
                base.SurrogateUpdate();
                GameObjectPhysics.Update();
                positionOnScreen = GameObjectPhysics.Position;
            }
            else
            {
                Remove();
            }
        }

        public void Remove()
        {
            Sprite = SpriteFactory.Instance.GetSprite("Fireball_out", "", "");
            World.Instance.RemoveFromWorld(this);
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            State.ChangeDirection(ShootAngle.Right);
            bounceCounter++;
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            State.ChangeDirection(ShootAngle.Left);
            bounceCounter++;
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
            bounceCounter++;
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            GameObjectPhysics.MoveMaxSpeed(Side.Down);
            bounceCounter++;
        }

        public void Shoot(ShootAngle angle)
        {
            
        }
    }
}
