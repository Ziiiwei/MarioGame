using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace
{
    class Sprite : ISprite
    {
        private Texture2D texture;
        private int totalFrames;
        private int currentFrame;
        private List<Rectangle> rectangles;
        private readonly int delayBound = 5;
        private int delayCounter = 0;

        public Sprite(Texture2D texture, int totalFrames)
        {
            this.texture = texture;
            this.totalFrames = totalFrames;

            int width = texture.Width / totalFrames;
            int height = texture.Height;

            rectangles = new List<Rectangle>();

            for (int i = 0; i < totalFrames; i++)
            {
                rectangles.Add(new Rectangle(width * i, 0, width, height));
            }

        }
        public void Update()
        {
            delayCounter += 1;

            if (delayCounter % delayBound == 0)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
            }
        }
        public void Update(int f)
        {
            currentFrame = f;
        }

        public Tuple<Texture2D, Rectangle> GetSprite()
        {
            return new Tuple<Texture2D, Rectangle>(texture, rectangles[currentFrame]);
        }

        public Texture2D GetTexture()
        {
            return texture;
        }


        public int FrameCount()
        {
            return totalFrames;
        }

        public Rectangle GetRectangle()
        {
            return rectangles[currentFrame];
        }
    }
}
