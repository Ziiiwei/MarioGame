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
            
            GameObjectPhysics.Update();
            GameObjectPhysics.FrictionStop(Side.Right);
            PositionOnScreen = GameObjectPhysics.GetPosition();
            base.Update();
        }
        public void Crouch()
        {
            State.Crouch();
           
        }

        public void Jump()
        {
            State.Jump();
            GameObjectPhysics.JumpMaxSpeed(Side.Up);
        }

        public void MoveLeft()
        {
            State.MoveLeft();
            GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }

        public void MoveRight()
        {
            State.MoveRight();
            GameObjectPhysics.MoveMaxSpeed(Side.Right);
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
