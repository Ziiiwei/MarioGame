using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;
using Gamespace.States;
using System.Timers;

namespace Gamespace
{
    public class StarMario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public new int Uid { get; }
        public new ISprite Sprite { get; set; }
        new IMarioState State { get; set; }
        new Vector2 PositionOnScreen { get; }

        public  IMarioPowerUpState PowerUpState { get; set; }
        public IMarioPowerUpState PreviousState { get; set; }

        public int score { get; set; }

        public Timer timer { get; }
        public Scoreboard scoreboard { get; }
        internal IPhysics Physics { get; set; }

        int Timer = 1000;
        private IMario mario;

        public StarMario(IMario mario, Vector2 positionOnScreen) : base(positionOnScreen)
        {
            this.mario = mario;
            timer = new Timer(1000);
        }
        
        public new void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);

        }

        public new void Update()
        {
            Timer--;
            if (Timer == 0)
            {
                this.mario.PowerUpState = this.PreviousState;
                this.mario.UpdateArt();
                World.Instance.Replace(this, this.mario);
            }
            this.mario.Update();
        }

        public void Jump()
        {
           mario.Jump();
        }

        public void MoveRight()
        {
            mario.MoveRight();
        }

        public void MoveLeft()
        {
            mario.MoveLeft();
        }

        public void Crouch()
        {
            mario.Crouch();
        }

        public void PowerDown()
        {
            // Star mario doesn't ever power down
        }

        public void PowerUp()
        {
            this.mario.PowerUpState.PowerUp(this.mario);
        }

        public void UpdateArt()
        {
            mario.UpdateArt();
        }

        public new Rectangle GetCollisionBoundary()
        {
           return mario.GetCollisionBoundary();
        }

        public new void CollideLeft(Rectangle collisionArea)
        {
            mario.CollideLeft(collisionArea);
        }

        public new void CollideRight(Rectangle collisionArea)
        {
            mario.CollideRight(collisionArea);
        }

        public new void CollideUp(Rectangle collisionArea)
        {
            mario.CollideUp(collisionArea);
        }
        public new void CollideDown(Rectangle collisionArea)
        {
            mario.CollideDown(collisionArea);
        }

        public new Vector2 GetCenter()
        {
            return mario.GetCenter();
        }

        public void Bounce()
        {
            Physics.MoveMaxSpeed(Side.Up);
        }

        public void Die()
        {
            // Star Mario cannot die.
        }

        public void Fire()
        {
            throw new NotImplementedException();
        }

    }
}
