using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;
using Sprint2.GoombaState;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Goomba : IGameObject
    {
        public ISprite Sprite { get; set; }
        private IGoombaState state;
        private Vector2 positionOnScreen;

        public Goomba (Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.CreateGoomba();
            state = new RightMovingGoombaState(this);
            this.positionOnScreen = positionOnScreen;
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

        public void SetState(IGoombaState newState)
        {
            this.state = newState;
        }

        public void Update()
        {
            Sprite.Update();
        }

        [Obsolete]
        public void Draw(SpriteBatch spriteBatch)
        {
            var spriteTextureAndRectangle = Sprite.GetSprite();

            spriteBatch.Draw(texture: spriteTextureAndRectangle.Item1, position: positionOnScreen,
                sourceRectangle: spriteTextureAndRectangle.Item2);

        }


    }
}
