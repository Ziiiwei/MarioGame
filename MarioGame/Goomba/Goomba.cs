using System;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.States;
using Gamespace.Sprites;

namespace Gamespace.Goombas
{
    public class Goomba : AbstractGameObject
    {
        private IGoombaState state;


        public Goomba (Vector2 positionOnScreen) : base(positionOnScreen)
        {
            state = new RightMovingGoombaState(this);
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

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
        }

    }
}
