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
        public Vector2 PositionOnScreen { get; }


        public AbstractGameObject(Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
            this.PositionOnScreen = positionOnScreen;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture: Sprite.GetTexture(), position: PositionOnScreen,
                sourceRectangle: Sprite.GetRectangle(), color: Color.White);
        }

        public void Update()
        {
            Sprite.Update();
        }

        public Rectangle GetCollisionBoundary()
        {
            return new Rectangle((int)PositionOnScreen.X, (int)PositionOnScreen.Y, Sprite.Width, Sprite.Height);
        }

        public Vector2 GetCenter()
        {
            float height = Sprite.Height / 2;
            float width = Sprite.Width / 2;

            return new Vector2(PositionOnScreen.X + width, PositionOnScreen.Y + height);
        }

    }
}
