using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Views
{
    internal interface IView
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
