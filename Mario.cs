using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Mario : IMario
    {
        public ISprite Sprite { get; set; }
        private IMarioState state;
        public IMarioPowerUpState PowerUpState { get; set; }
        private Vector2 positionOnScreen;
        
        public Mario(Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.CreateRightStandingMario();
            state = new RightFacingStandingMarioState();
            this.positionOnScreen = positionOnScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var spriteTextureAndRectangle = Sprite.GetSprite();

            spriteBatch.Draw(texture: spriteTextureAndRectangle.Item1, position: positionOnScreen, 
                sourceRectangle: spriteTextureAndRectangle.Item2);

        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Jump()
        {
            state.Jump(this);
        }

        public void MoveRight()
        {
            state.MoveRight(this);
        }

        public void MoveLeft()
        {
            state.MoveLeft(this);
        }

        public void Crouch()
        {
            state.Crouch(this);
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
        }

        public void PowerUp()
        {
            PowerUpState.PowerUp(this);
        }

        public void SetState(IMarioState newState)
        {
            this.state = newState;
        }
    }
}
