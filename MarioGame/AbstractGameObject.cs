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
        protected static int counter = 0;
        public int Uid { get; protected set; }
        public ISprite Sprite { get; protected set; }
        public Vector2 PositionOnScreen { get; protected set; }


        public AbstractGameObject()
        {
            Uid = counter;
            counter++;
        }

        public AbstractGameObject(Vector2 positionOnScreen)
        {
            SetSprite();
            this.PositionOnScreen = positionOnScreen;
            Uid = counter;
            counter++;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture: Sprite.GetTexture(), position: PositionOnScreen,
                sourceRectangle: Sprite.GetRectangle(), color: Color.Red);
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

        protected virtual void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

    }
}
