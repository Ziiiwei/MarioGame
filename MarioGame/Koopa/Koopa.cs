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
    class Koopa : AbstractGameStatefulObject<IKoopaState>, IEnemy
    {
        public Koopa(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new KoopaMovingLeftState(this);
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

        public void IsFlipped()
        {
            State.IsFlipped();
        }

        public void SetState(IKoopaState newState)
        {
            this.State = newState;
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }


    }
}
