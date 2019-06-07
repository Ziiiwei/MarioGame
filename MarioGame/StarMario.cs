using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace
{
    public class StarMario : IMario
    {
        private IMario decoratedMario;

        public StarMario(IMario mario)
        {
            decoratedMario = mario;
        }

        public void CollideDown(Rectangle collisionArea)
        {
            decoratedMario.CollideDown(collisionArea);
        }

        public void CollideLeft(Rectangle collisionArea)
        {
            throw new NotImplementedException();
        }

        public void CollideRight(Rectangle collisionArea)
        {
            throw new NotImplementedException();
        }

        public void CollideUp(Rectangle collisionArea)
        {
            throw new NotImplementedException();
        }

        public void Crouch()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetCenter()
        {
            throw new NotImplementedException();
        }

        public Rectangle GetCollisionBoundary()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void PowerDown()
        {
            
        }

        public void PowerUp()
        {
            
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void UpdateArt()
        {
            throw new NotImplementedException();
        }
    }
}
