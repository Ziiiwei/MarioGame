using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AbstractGameStatefulObject<T> : AbstractGameObject
    {

        public T State { get; set; }
        public AbstractGameStatefulObject(Vector2 positionOnScreen) : base()
        {
            this.PositionOnScreen = positionOnScreen;
            GameObjectPhysics = new Physics(this, PositionOnScreen);
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

    }
}
