using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class Mario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public IMarioPowerUpState PowerUpState { get; set; }
        ISprite IMario.Sprite { get; set; }

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();
        }

        public override void Update()
        {
            base.Update();
            GameObjectPhysics.Update();
            PositionOnScreen = GameObjectPhysics.GetPosition();
        }
        public void Crouch()
        {
            State.Crouch();
            GameObjectPhysics.MoveDown();
        }

        public void Jump()
        {
            State.Jump();
            GameObjectPhysics.MoveUp();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
            GameObjectPhysics.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
            GameObjectPhysics.MoveRight();
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public void PowerUp()
        {
            PowerUpState.PowerUp(this);
            UpdateArt();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }
    }
}
