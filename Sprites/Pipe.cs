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

        public Pipe(rows, columns, Texture2D pipeTexture, Vector2 pipeLocation)
        {
            texture = pipeTexture;
            location = pipeLocation;
            Rows = Rows;
            Columns = Columns;
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
        
    }
}
