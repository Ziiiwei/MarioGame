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
        protected int StompTimer { get; set; }
        protected int StompTimerBound { get; }

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
            State = new StompedGoombaState(this);
        }
    }
}
