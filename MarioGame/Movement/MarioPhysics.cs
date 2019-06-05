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
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int Acceleration{ get; set; }
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
