using System;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.States;
using Gamespace.Sprites;

namespace Gamespace.Goombas
{
    public class Goomba : IGameObject
    {
        public ISprite Sprite { get; set; }
        private IGoombaState state;
        private Vector2 positionOnScreen;

        public Goomba (Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
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

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
        }

    }
}
