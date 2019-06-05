using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework;


namespace Gamespace.Movement
{
    class MarioPhysics : IPhysics
    {
        private Vector2 Position { get; set; }
        private Vector2 Velocity { get; set; }
        private int Acceleration{ get; set; }
        public MarioPhysics()
        {

        }
        public void MoveLeft()
        {
            Position.X -= Velocity.X;
        }
        public void MoveRight()
        {
            Position += Velocity.X;
        }
        public void FreeFall()
        {
            Position.Y -= Velocity.Y;
        }
        public void Jump()
        {
            Position.Y += Velocity.Y;
        }
        public void SpeedUp()
        {

        }
        public void SlowDown()
        {

        }
        public void Stop()
        {

        }
        public void Update()
        {

        }
    }
}
