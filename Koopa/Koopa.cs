using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Koopa : IGameObject
    {
        public ISprite Sprite { get; set; }
        private IKoopaState state { get; set; }
        private Vector2 positionOnScreen;

        public Koopa(Vector2 positionOnScreen)
        {
            state = new KoopaMovingLeftState(this);
            Sprite = SpriteFactory.Instance.GetSprite(this);
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

        public void IsFlipped()
        {
            state.IsFlipped();
        }

        public void SetState(IKoopaState newState)
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

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
        }


    }
}
