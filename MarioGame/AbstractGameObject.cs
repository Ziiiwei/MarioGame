using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AbstractGameObject : IGameObject
    {
        public ISprite Sprite { get; set; }
        private Vector2 positionOnScreen;


        public AbstractGameObject(Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
            this.positionOnScreen = positionOnScreen;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture: Sprite.GetTexture(), position: positionOnScreen,
                sourceRectangle: Sprite.GetRectangle(), color: Color.White);
        }

        public void Update()
        {
            Sprite.Update();
        }

      
    }
}
