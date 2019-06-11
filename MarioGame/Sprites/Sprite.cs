﻿using System;
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

        private readonly int delayBound;

        private int delayCounter = 0;
        public int Width { get; }
        public int Height { get; }

        public Sprite(Texture2D texture, int totalFrames, int delayBound)
        {
            this.texture = texture;
            this.totalFrames = totalFrames;

            Width = texture.Width / totalFrames;
            Height = texture.Height;

            rectangles = new List<Rectangle>();

            for (int i = 0; i < totalFrames; i++)
            {
                rectangles.Add(new Rectangle(Width * i, 0, Width, Height));
            }

            this.delayBound = delayBound;

        }
        public void Update()
        {
            delayCounter += 1;

            if (delayCounter % delayBound == 0)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
            }
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
