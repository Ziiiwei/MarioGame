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
   
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void TakeDamage()
        {
            State.TakeDamage();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }


    }
}
