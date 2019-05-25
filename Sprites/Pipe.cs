using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Pipe : ISprite
    {
        private Texture2D texture;
        private Vector2 location;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public Pipe(rows, columns, Texture2D pipeTexture, Vector2 pipeLocation)
        {
            texture = pipeTexture;
            location = pipeLocation;
            Rows = Rows;
            Columns = Columns;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw()
        {
            int width = texture.Width / Columns;
            int height = texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        
    }
}
