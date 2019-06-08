﻿using Microsoft.Xna.Framework;
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
       
        Tuple<Texture2D, Rectangle> GetSprite();
        Texture2D GetTexture();
        Rectangle GetRectangle();//return corrent frame
        int FrameCount();
        int Width { get; }
        int Height { get; }
    }
}
