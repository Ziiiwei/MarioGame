using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Sprites
{
    public interface ISprite
    {
        void Update();

        Vector2 Position{ get; set;}
        void Draw(SpriteBatch spriteBatch, Vector2 positionOnScreen);
        Tuple<Texture2D, Rectangle> GetSprite();
        Rectangle GetRectangle();
        int Width { get; }
        int Height { get; }
    }
}
