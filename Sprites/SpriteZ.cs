using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class SpriteZ : ISprite
    {
        private Texture2D texture;
        private int columns;
        private int totalFrames;
        private int currentFrame;
        private List<Rectangle> rectangles;
        private readonly int delayBound = 5;
        private int delayCounter = 0;

        public SpriteZ(Texture2D texture, int columns, int initialFrame)
        {
            this.texture = texture;
            this.columns = columns;
            this.currentFrame = initialFrame;
            this.totalFrames = columns;

            int width = texture.Width / columns;
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

        public Rectangle GetRectangle()
        {
            return rectangles[currentFrame];
        }

        public int FrameCount()
        {
            return totalFrames;
        }
    }
}
