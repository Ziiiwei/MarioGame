using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface ISprite
    {
        void Update();
        void Update(int f); //Freeze to certain frame
        Tuple<Texture2D, Rectangle> GetSprite();
        Texture2D GetTexture();
        Rectangle GetRectangle();//return corrent frame
        int FrameCount();
    }
}
