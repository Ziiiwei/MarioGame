using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Animaiton
{
    interface IKeyFrame
    {
        IKeyFrame Previous { get; set; }
        IKeyFrame Next { get; set; }
        Vector2 FramePoint { get; set; }

     
        void ToNext();
    }
}
