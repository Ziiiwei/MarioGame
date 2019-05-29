using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Interfaces;
namespace Sprint2
{
    public class Mario : IMario
    {
        private ISprite sprite;
        private Vector2 location;


        public Mario(Vector2 position)
        {
            sprite = SpriteFactory.CreateMario(position);
            location = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Jump()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void MovingRight()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void MovingLeft()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void FacingLeft()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void FacingRight()
        {
            sprite = SpriteFactory.CreateMario(location);
        }

        public void CrouchRight()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void CrouchLeft()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void TakeDamage()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
        public void Upgrade()
        {
            sprite = SpriteFactory.CreateMario(location);
        }
    }
}
