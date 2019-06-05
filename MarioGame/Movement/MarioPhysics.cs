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
        public MarioPhysics(Vector2 position, Vector2 velocity, int acceleration)
        {
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void FreeFall()
        {

        }
        public void Jump()
        {

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
