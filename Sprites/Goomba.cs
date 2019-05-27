using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Goomba : ISprite
    {
        private Texture2D texture;
        private Vector2 location;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public Goomba(int rows, int columns, Texture2D goombaTexture, Vector2 Location)
        {
            texture = goombaTexture;
            location = Location;
            Rows = Rows;
            Columns = Columns;
            totalFrames = Rows * Columns;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
