using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Animation
{
    public interface IKeyFrame<T>
    {
        T AnimatedObj { get;}
        Vector2 FramePoint { get;}
        Type ComandToCall { get; }
        void FrameFinished();
        void Update();

    }
}
