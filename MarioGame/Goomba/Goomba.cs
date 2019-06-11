using System;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.States;
using Gamespace.Sprites;

namespace Gamespace.Goombas
{
    public class Goomba : AbstractGameStatefulObject<IGoombaState>, IEnemy
    {
        protected int StompTimer { get; set; }
        protected int StompTimerBound { get; }

        public Goomba (Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new LeftMovingGoombaState(this);
            SetSprite();
        }

        public void BeStomped()
        {
            State.BeStomped();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void IsDead()
        {
            State.IsDead();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

    }
}
