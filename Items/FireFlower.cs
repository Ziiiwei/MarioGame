using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class FireFlower : IItem
    {
        private ISprite sprite;
        private Vector2 location;

        public FireFlower(ISprite Sprite, Vector2 Location)
        {
            sprite = Sprite;
            location = Location;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update()
        {

        }
    }
}
