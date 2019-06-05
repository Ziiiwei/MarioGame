using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;
using Gamespace.States;
using Gamespace.Movement;

namespace Gamespace
{
    public class Mario : IMario
    {
        public ISprite Sprite { get; set; }
        public IMarioState State { get; set; }
        public IMarioPowerUpState PowerUpState { get; set; }
        private Vector2 positionOnScreen;
        private IPhysics Physics;
        public Mario(Vector2 positionOnScreen)
        {
            State = new RightStandingMarioState();
            PowerUpState = new MarioSmallState();
            Sprite = SpriteFactory.Instance.GetSprite(State, PowerUpState);
            this.positionOnScreen = positionOnScreen;
            Physics = new MarioPhysics();
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
            State.Jump(this);
            Physics.Jump();
        }

        public void MoveRight()
        {
            State.MoveRight(this);
            Physics.MoveRight();
        }

        public void MoveLeft()
        {
            State.MoveLeft(this);
            Physics.MoveLeft();
        }

        public void Crouch()
        {
            State.Crouch(this);
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
        }

        public void PowerUp()
        {
            PowerUpState.PowerUp(this);
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(State, PowerUpState);
        }
    }
}
