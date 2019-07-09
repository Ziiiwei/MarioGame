using Gamespace.Projectiles;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    internal class Fireball : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        private static readonly Dictionary<Side, Type> initialOrientation;
        private int bounceCounter = 0;
        private int bounceBound = 10;

        static Fireball()
        {
            initialOrientation = new Dictionary<Side, Type>()
            {
                {Side.Left, typeof(LeftMovingProjectile) },
                {Side.Right, typeof(RightMovingProjectile) }
            };
        }

        public Fireball(Vector2 positionOnScreen, Side side) : base(positionOnScreen)
        {
            State = (IProjectileState) Activator.CreateInstance(initialOrientation[side], this);
            SoundManager.Instance.PlaySoundEffect("Fireball");
            SetSprite();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
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
                positionOnScreen = GameObjectPhysics.GetPosition();
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
            State.ChangeDirection();
            bounceCounter++;
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            State.ChangeDirection();
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
    }
}
