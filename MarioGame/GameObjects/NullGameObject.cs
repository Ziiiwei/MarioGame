using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace
{
    public class NullGameObject : AbstractGameObject
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        protected override void SetSprite()
        {
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
        }

        public override void CollideRight(Rectangle collisionArea)
        {
        }

        public override void CollideUp(Rectangle collisionArea)
        {
        }

        public override void CollideDown(Rectangle collisionArea)
        {
        }
    }
}