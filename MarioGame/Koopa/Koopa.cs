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
    class Koopa : AbstractGameObject
    {
        private IKoopaState state { get; set; }

        public Koopa(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            state = new KoopaMovingLeftState(this);
   
        }

        public void BeStomped()
        {
            state.BeStomped();
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void IsDead()
        {
            state.IsDead();
        }

        public void IsFlipped()
        {
            state.IsFlipped();
        }

        public void SetState(IKoopaState newState)
        {
            this.state = newState;
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
        }


    }
}
