using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;
using Gamespace.States;

namespace Gamespace
{
    public class Mario : IMario
    {
        public int Uid { get; }
        public ISprite Sprite { get; set; }
        public IMarioState State { get; set; }
        public IMarioPowerUpState PowerUpState { get; set; }
        public IPhysics Physics { get; set; }

        public Vector2 PositionOnScreen { get; private set; }
        public Mario(Vector2 positionOnScreen)
        {
            State = new RightStandingMarioState();
            PowerUpState = new MarioSmallState();
            Sprite = SpriteFactory.Instance.GetSprite(State, PowerUpState);
            Physics = new Physics(this, positionOnScreen);
            Uid = -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var spriteTextureAndRectangle = Sprite.GetSprite();

            spriteBatch.Draw(texture: Sprite.GetTexture(), position: Physics.GetPosition(), 
                sourceRectangle:Sprite.GetRectangle(),color : Color.White);

        }

        public void Update()
        {
            Sprite.Update();
            Physics.Update();
            PositionOnScreen = Physics.GetPosition();
              
        }

        public void Jump()
        {
            State.Jump(this);
            Physics.MoveUp();
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
            Physics.MoveDown();
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

        public Rectangle GetCollisionBoundary()
        {
            return new Rectangle((int)PositionOnScreen.X, (int)PositionOnScreen.Y, Sprite.Width, Sprite.Height);
        }

        public void CollideLeft(Rectangle collisionArea)
        {
            Physics.LeftStop(collisionArea);
        }

        public void CollideRight(Rectangle collisionArea)
        {
            Physics.RightStop(collisionArea);
        }

        public void CollideUp(Rectangle collisionArea)
        {
            Physics.UpStop(collisionArea);
        }
        public void CollideDown(Rectangle collisionArea)
        {
            Physics.DownStop(collisionArea);
        }

        public Vector2 GetCenter()
        {
            float height = Sprite.Height / 2;
            float width = Sprite.Width / 2;

            return new Vector2(PositionOnScreen.X + width, PositionOnScreen.Y + height);
        }

    }
}
