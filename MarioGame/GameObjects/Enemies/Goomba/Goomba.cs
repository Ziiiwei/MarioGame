using System;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sounds;
using Gamespace.States;
using Gamespace.Sprites;
using Gamespace.Data;

namespace Gamespace.Goombas
{
    internal class Goomba : AbstractGameStatefulObject<IEnemyState>, IEnemy
    {
        private int stompTimer = 0;
        //this int is readOnly, so the number 20 is only used here. (Magic Number?)
        private readonly int stompTimerBound = Numbers.STOMP_TIMER_BOUND;

        public Goomba (Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new LeftMovingGoombaState(this);
            SetSprite();
            GameObjectPhysics.MoveMaxSpeed(Side.Left);
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

            SoundManager.Instance.PlaySoundEffect("Stomp");
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

            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.Position;
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

        public void Die()
        {
            World.Instance.RemoveFromWorld(this);
        }
    }
}
