using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;

namespace Gamespace.Koopas
{
    class Koopa : AbstractGameStatefulObject<IEnemyState>, IEnemy
    {
        public Koopa(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new KoopaMovingLeftState(this);
            SetSprite();
            GameObjectPhysics.MoveMaxSpeed(Side.Left);

        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void SlideLeft()
        {
            State.SlideLeft();
        }

        public void SlideRight()
        {
            State.SlideRight();
        }

        public void TakeDamage()
        {
            State.TakeDamage();
        }

        protected override void SurrogateUpdate()
        {
            Sprite.Update();

            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.Position;
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            ChangeDirection();
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            ChangeDirection();
        }

        public void Die()
        {
            World.Instance.RemoveFromWorld(this);
        }
    }
}
