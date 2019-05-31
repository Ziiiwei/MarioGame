using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FireFlower : IGameObject
    {
        public ISprite Sprite { get; set; }
        private Vector2 positionOnScreen;


        public FireFlower(Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite("Flower");
            this.positionOnScreen = positionOnScreen;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var spriteTextureAndRectangle = Sprite.GetSprite();

            spriteBatch.Draw(texture: spriteTextureAndRectangle.Item1, position: positionOnScreen,
                sourceRectangle: spriteTextureAndRectangle.Item2);
        }

        public void Update()
        {

        }
    }
}