using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public interface IGameObject
    {
        int Uid { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        Vector2 PositionOnScreen { get; }
        Rectangle GetCollisionBoundary();
        Vector2 GetCenter();
       
    }
}
 