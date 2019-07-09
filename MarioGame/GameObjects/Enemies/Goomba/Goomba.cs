using System;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.States;
using Gamespace.Sprites;

namespace Gamespace.Goombas
{
    internal class Goomba : AbstractGameStatefulObject<IEnemyState>, IEnemy
    {
        private int stompTimer = 0;
        private readonly int stompTimerBound = 20;

        public Goomba (Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new LeftMovingGoombaState(this);
            SetSprite();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

        public void TakeDamage()
        {

            SoundFactory.Instance.PlaySoundEffect("Stomp");
            State.TakeDamage();
            UpdateArt();
        }

        protected override void SurrogateUpdate()
        {
            if (State.GetType() == typeof(StompedGoombaState))
            {
                if (stompTimer == stompTimerBound)
                {
                    World.Instance.RemoveFromWorld(this);
                    return;
                }
                else
                {
                    stompTimer++;
                }
            }
            Sprite.Update();

            // This can be reworked by adding this CONSTANT ACCEL functionality into Physics.
            if (State.GetType() == typeof(LeftMovingGoombaState))
            {
                GameObjectPhysics.Move(Side.Left);
            }
            else if (State.GetType() == typeof(RightMovingGoombaState))
            {
                GameObjectPhysics.Move(Side.Right);
            }
            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.GetPosition();
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

        public void SlideLeft()
        {
            // Do nothing
        }

        public void SlideRight()
        {
            // Do nothing
        }
    }
}
